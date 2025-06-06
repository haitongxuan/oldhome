using OldHome.DTO.Base;
using OldHome.Entities.Base;

namespace OldHome.Service.Endpoints
{
    public abstract class BaseEndpoints<TDto, TSample, TCreate, TModify, TEntity>
        where TDto : BaseDto
        where TSample : BaseDto
        where TCreate : BaseDto
        where TModify : BaseDto
        where TEntity : BaseEntity
    {
        private string _group = string.Empty;
        public BaseEndpoints(string group)
        {
            _group = group;
        }

        public virtual void MapEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup(_group);

        }
    }
}
