using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Features.Sync.Integrator
{
    /// <summary>
    /// Classe base para todas as views de sincronização, já implementa os campos padrão do sync
    /// </summary>
    public abstract class SyncViewRegisterBase : ISyncViewRegister
    {
        [Column("ID")]
        public long Id { get; set; }

        [Column("OPERATION_ID")]
        public int OperationId { get; set; }

        [Column("HASH_VALUE")]
        public string HashValue { get; set; } = string.Empty;

        [Column("ENTITY_ID")]
        public int EntityId { get; set; }
    }
}
