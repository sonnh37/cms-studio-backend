using AutoMapper;
using Serilog;
using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Entities.Bases;
using NM.Studio.Domain.Models.Base;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Results.Bases;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Utilities;
using NM.Studio.Domain.Contracts.Repositories.Users;
using NM.Studio.Domain.Entities;
using NM.Studio.Domain.Contracts.Services.Outfits;
using NM.Studio.Domain.Contracts.Services.Users;
using NM.Studio.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace NM.Studio.Services.Bases
{
    public abstract class BaseService
    {
        
    }
    public abstract class BaseService<TEntity> : BaseService, IBaseService
        where TEntity : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseRepository<TEntity> _baseRepository;
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _baseRepository = _unitOfWork.GetRepositoryByEntity<TEntity>();
        }

        public async Task<MessageView<TView>> CreateOrUpdate<TView>(CreateOrUpdateCommand<TView> createOrUpdateCommand) where TView : BaseView
        {
            // call repo 
            var result = await CreareOrUpdateEntity(createOrUpdateCommand);
            // map 
            var content = _mapper.Map<TEntity, TView>(result);
            var msgViews = AppMessage.GetMessageView<TView>(content);
            // return
            return msgViews;
        }

        private async Task<TEntity> CreareOrUpdateEntity<TView>(CreateOrUpdateCommand<TView> createOrUpdateCommand)
            where TView : BaseView
        {
            TEntity entity;
            if(createOrUpdateCommand is UpdateCommand<TView> updateCommand)
            {
                // Update
                entity = await _baseRepository.GetById(updateCommand.Id);
                if(entity == null)
                {
                    return null;
                }
                _mapper.Map(updateCommand, entity);
                SetBaseEntityUpdate(entity);
                _baseRepository.Update(entity);
            }
            else
            {
                // Create
                entity = _mapper.Map<TEntity>(createOrUpdateCommand);
                if (entity == null)
                {
                    return null;
                }
                entity.Id = Guid.NewGuid();
                SetBaseEntityCreate(entity);
                _baseRepository.Add(entity);
            }

            var saveChanges = await _unitOfWork.SaveChanges();
            return saveChanges ? entity : default;
        }

        public TEntity SetBaseEntityCreate(TEntity entity)
        {

            var user = StaticUser.User;
            if (user != null)
            {
                // đã đăng nhập
                entity.Id = Guid.NewGuid();
                entity.CreatedBy = user.Email;
                entity.CreatedDate = DateTime.Now;
                entity.LastUpdatedBy = user.Email;
                entity.LastUpdatedDate = entity.CreatedDate;
                entity.IsDeleted = false;
            }
            else
            {
                entity.Id = Guid.NewGuid();
                entity.CreatedDate = DateTime.Now;
                entity.IsDeleted = false;
            }

            return entity;
        }

        public TEntity SetBaseEntityUpdate(TEntity entity)
        {

            var user = StaticUser.User;
            if (user != null)
            {
                entity.LastUpdatedBy = user.Email;
                entity.LastUpdatedDate = DateTime.Now;
            }

            return entity;
        }
        
        public async Task<MessageResults<TResult>> GetAll<TResult>() where TResult : BaseResult
        {
            // call repo
            var results = await _baseRepository.GetAll();
            // map 
            var content = _mapper.Map<IList<TEntity>, List<TResult>>(results);
            var msgResults = AppMessage.GetMessageResults<TResult>(content);
            // return
            return msgResults;
        }

        public async Task<MessageResult<TResult>> GetById<TResult>(Guid id) where TResult : BaseResult
        {
            // call repo
            var result = await _baseRepository.GetById(id);
            // map  
            var content = _mapper.Map<TEntity, TResult>(result);
            var msgResults = AppMessage.GetMessageResult<TResult>(content);
            // return
            return msgResults;
        }

        public async Task<MessageView<TView>> DeleteById<TView>(Guid id) where TView : BaseView
        {
            // call repo
            var result = await DeleteEntity(id);
            //map
            var content = _mapper.Map<TEntity, TView>(result);
            var msgView = AppMessage.GetMessageView<TView>(content);
            return msgView;
        }

        private async Task<TEntity> DeleteEntity(Guid id)
        {
            TEntity entity;
            entity = await _baseRepository.GetById(id);
            if (entity == null)
            {
                return null;
            }
            _baseRepository.Delete(entity);

            var saveChanges = await _unitOfWork.SaveChanges();
            return saveChanges ? entity : default;
        }


    }
}
