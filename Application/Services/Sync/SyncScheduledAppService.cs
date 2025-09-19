using Application.Services.Auth;
using Application.Services.Core;
using Domain.Features.Sync;
using Domain.Features.Sync.Enums;
using Infrastructure.Http;
using Libs.Common;
using Service.Features.Sync;
using System;
using System.Text.Json;

namespace Application.Services.Sync
{
    public class SyncScheduledAppService : AuthenticatedAppService, ISyncScheduledAppService
    {
        private readonly ISyncLogService _logService;
        private readonly ISyncHashService _hashService;
        private readonly ISyncScheduledEventService _scheduledEventService;

        public SyncScheduledAppService(
            IApiClient apiClient,
            ITokenService tokenService,
            ISyncLogService logService,
            ISyncHashService hashService,
            ISyncScheduledEventService scheduledEventService)
            : base(apiClient, tokenService)
        {
            _scheduledEventService = scheduledEventService;
            _logService = logService;
            _hashService = hashService;
        }

        public async Task ProcessScheduledAsync()
        {
            var scheduledEvents = await _scheduledEventService.GetList();

            foreach (var ev in scheduledEvents)
            {
                var credentials = new RemoteCredentials(ev.AuthUsername, "1234", ev.AuthUrl);
                var payload = JsonSerializer.Deserialize<object>(ev.Payload);

                try
                {
                    var result = await PostAsync<DataResult>(ev.ServiceUrl, payload, credentials);

                    if (result != null && result.Success)
                        await MarkSuccessAsync(ev, result.Message);
                    else
                        await MarkErrorAsync(ev, result?.Message ?? "Falha desconhecida na API");
                }
                catch (Exception ex)
                {
                    await MarkErrorAsync(ev, ex.Message, saveLog: true);
                }
            }
        }

        private async Task MarkSuccessAsync(SyncScheduledEvent ev, string? message)
        {
            ev.Status = StatusEnum.Success;
            ev.AttemptsCount++;

            if (!string.IsNullOrEmpty(ev.HashValue))
            {
                var syncHash = new SyncHash
                {
                    HashValue = ev.HashValue,
                    Entity = ev.Entity,
                    RecordId = ev.RecordId,
                    Operation = ev.Operation
                };
                await _hashService.SaveOrUpdate(syncHash);
            }

            await _scheduledEventService.Save(ev);
        }

        private async Task MarkErrorAsync(SyncScheduledEvent ev, string message, bool saveLog = false)
        {
            ev.Status = StatusEnum.Error;
            ev.AttemptsCount++;

            await _scheduledEventService.Save(ev);

            if (saveLog)
            {
                var log = new SyncLog
                {
                    Entity = ev.Entity,
                    RecordId = ev.RecordId,
                    Operation = ev.Operation,
                    Status = StatusEnum.Error,
                    Message = message,
                    LogDateTime = DateTime.Now,
                    Payload = ev.Payload,
                    HashValue = ev.HashValue
                };
                await TrySaveLog(log);
            }
        }

        private async Task TrySaveLog(SyncLog log)
        {
            try { await _logService.Save(log); }
            catch { /* swallow exception */ }
        }
    }
}
