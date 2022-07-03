using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyIND.Domain.BaseModel.BaseEntity;
using EasyIND.Domain.BaseModel.BaseEntityDto;

namespace EasyIND.Application.Common.Interfaces
{
    public interface IEntityCRUDService<TEntity, TEntityDto> where TEntity : class, IBaseEntity
       where TEntityDto : class, IBaseEntityDto
    {
        Task<TEntityDto> GetById(int id);
        Task<TEntityDto> Save(TEntityDto entityDto);
        Task<TEntityDto> Update(int id, TEntityDto entityDto);
        Task<TEntityDto> Delete(int id);
        IQueryable<TEntity> Get();
    }
}
