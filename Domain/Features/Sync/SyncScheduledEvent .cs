using Domain.Common;
using Domain.Features.Sync.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Features.Sync
{
    [Table("SYNC_SCHEDULED_EVENTS")]
    public class SyncScheduledEvent : EntityBase
    {
        [Key]
        [Column("ID")]
        public override long? Id { get; set; }

        [Column("ENTITY_ID")]
        [Required]
        public EntityEnum Entity { get; set; }

        [Column("RECORD_ID")]
        [Required]
        public long RecordId { get; set; }

        [Column("OPERATION_ID")]
        [Required]
        public OperationEnum Operation { get; set; }

        [Column("STATUS_ID")]
        [Required]
        public StatusEnum Status { get; set; } = StatusEnum.Pending;

        [Column("PAYLOAD")]
        [Required]
        public string Payload { get; set; } = string.Empty;

        [Column("HASH_VALUE")]
        [Required]
        [MaxLength(256)]
        public string HashValue { get; set; } = string.Empty;

        [Column("ATTEMPTS_COUNT")]
        [Required]
        public int AttemptsCount { get; set; } = 0;

        [Column("CREATED_AT")]
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("SERVICE_URL")]
        [Required]
        [MaxLength(1000)]
        public string ServiceUrl { get; set; } = string.Empty;

        [Column("AUTH_URL")]
        [MaxLength(1000)]
        public string? AuthUrl { get; set; }

        [Column("AUTH_USERNAME")]
        [Required]
        [MaxLength(200)]
        public string AuthUsername { get; set; } = string.Empty;

        [Column("AUTH_PASSWORD")]
        [Required]
        [MaxLength(200)]
        public string AuthPassword { get; set; } = string.Empty;

        [Column("LOG_ID")]
        public long? LogId { get; set; }
    }
}
