using Domain.Common;
using Domain.Features.Sync.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Features.Sync
{
    [Table("SYNC_HASHES")]
    public class SyncHash : EntityBase
    {
        [Key]
        [Column("ID")]
        public override long? Id { get; set; }

        [Column("HASH_VALUE")]
        [Required]
        [MaxLength(256)]
        public string HashValue { get; set; } = string.Empty;

        [Column("ENTITY_ID")]
        [Required]
        public EntityEnum Entity { get; set; }

        [Column("RECORD_ID")]
        [Required]
        public long RecordId { get; set; }

        [Column("OPERATION_ID")]
        [Required]
        public OperationEnum Operation { get; set; }


    [Column("OPERATION_DATE")]
        public DateTime OperationDate { get; set; } = DateTime.Now;
    }
}
