namespace Domain.Features.Sync.Integrator
{
    public interface ISyncViewRegister
    {
        long Id { get; }
        int OperationId { get; }
        string HashValue { get; }
        int EntityId { get; }
    }
}
