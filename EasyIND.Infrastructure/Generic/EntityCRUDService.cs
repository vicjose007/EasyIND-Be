using AutoMapper;
using EasyIND.Application.Common.Interfaces;
using EasyIND.Domain.BaseModel.BaseEntity;
using EasyIND.Domain.BaseModel.BaseEntityDto;
using EasyIND.Infrastructure.Contexts.EasyIND;
using EasyIND.Infrastructure.Repositories;
using EasyIND.Infrastructure.UnitOfWorks;

namespace EasyIND.Infrastructure.Generic
{
    public class EntityCRUDService<TEntity, TEntityDto> : IEntityCRUDService<TEntity, TEntityDto> where TEntity : class, IBaseEntity
      where TEntityDto : class, IBaseEntityDto
    {

        public IMapper _mapper { get; set; }
        public IUnitOfWork<IEasyINDDbContext> _uow { get; set; }
        public readonly IRepository<TEntity> _repository;

        public EntityCRUDService(IMapper mapper, IUnitOfWork<IEasyINDDbContext> uow)
        {
            _mapper = mapper;
            _uow = uow;
            _repository = _uow.GetRepository<TEntity>();
        }

        public virtual IQueryable<TEntity> Get()
        {
            var list = _repository.GetAll();
            return list;
        }
        public virtual async Task<TEntityDto> GetById(int id)
        {
            TEntity entity = _repository.GetByIdAsNoTracking(id);

            if (entity is null)
                return null;

            //TEntity result =  Task.FromResult(entity);

            TEntityDto dto = _mapper.Map<TEntityDto>(entity);

            return dto;
        }
        public virtual async Task<TEntityDto> Save(TEntityDto entityDto)
        {
            TEntity entity = _mapper.Map<TEntity>(entityDto);
            _repository.Add(entity);
            await _uow.Commit();

            entityDto = _mapper.Map<TEntityDto>(entity);

            return entityDto;
        }
        public virtual async Task<TEntityDto> Update(int id, TEntityDto entityDto)
        {
            TEntity entity = _repository.GetById(id);
            if (entity is null)
                return null;

            _mapper.Map(entityDto, entity);

            _repository.Update(entity);

            await _uow.Commit();

            entityDto = _mapper.Map(entity, entityDto);

            return entityDto;
        }
        public virtual async Task<TEntityDto> Delete(int id)
        {
            TEntity entity = _repository.GetById(id);

            if (entity is null)
                return null;

            _repository.Delete(entity);
            await _uow.Commit();

            TEntityDto entityDto = _mapper.Map<TEntityDto>(entity);

            return entityDto;
        }
    }
}
