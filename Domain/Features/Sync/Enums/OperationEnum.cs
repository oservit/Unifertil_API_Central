using System.ComponentModel;

namespace Domain.Features.Sync.Enums
{
    public enum OperationEnum
    {
        [Description("Inclusão")]
        Insert = 1,
        [Description("Alteração")]
        Update = 2,
        [Description("Remoção")]
        Delete = 3
    }
}
