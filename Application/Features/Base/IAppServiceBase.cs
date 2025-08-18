using Domain.Base;
using Libs.Base;

namespace Application.Features.Base
{
    public interface IAppServiceBase<T> : IAppSelectService<T>
    {
        Task<DataResult> Save(object model);

        Task<DataResult> Update(long id, IUpdateViewModel model);

        Task<DataResult> Delete(long id);
    }
}