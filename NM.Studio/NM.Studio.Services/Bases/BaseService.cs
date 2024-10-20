using AutoMapper;
using NM.Studio.Domain.Contracts.Repositories.Bases;
using NM.Studio.Domain.Contracts.Services.Bases;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.CQRS.Queries.Base;
using NM.Studio.Domain.Entities.Bases;
using NM.Studio.Domain.Models;
using NM.Studio.Domain.Models.Responses;
using NM.Studio.Domain.Models.Results.Bases;
using NM.Studio.Domain.Utilities;

namespace NM.Studio.Services.Bases;

public abstract class BaseService
{
}

public abstract class BaseService<TEntity> : BaseService, IBaseService
    where TEntity : BaseEntity
{
    private readonly IBaseRepository<TEntity> _baseRepository;
    protected readonly IMapper _mapper;
    protected readonly IUnitOfWork _unitOfWork;

    protected BaseService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _baseRepository = _unitOfWork.GetRepositoryByEntity<TEntity>();
    }

    public async Task<ItemResponse<TResult>> GetById<TResult>(Guid id) where TResult : BaseResult
    {
        var entity = await _baseRepository.GetById(id);

        var result = _mapper.Map<TResult>(entity);
        var msgResult = ResponseHelper.CreateItem(result);

        return msgResult;
    }

    public async Task<ItemListResponse<TResult>> GetAll<TResult>() where TResult : BaseResult
    {
        var entities = await _baseRepository.GetAll();

        var results = _mapper.Map<List<TResult>>(entities);
        var msgResults = ResponseHelper.CreateItemList(results);

        return msgResults;
    }

    public async Task<TableResponse<TResult>> GetAll<TResult>(GetQueryableQuery x) where TResult : BaseResult
    {
        var entityAndInt = x.IsPagination
            ? await _baseRepository.GetAll(x)
            : (await _baseRepository.GetAll(), (int?)null);
        var results = _mapper.Map<List<TResult>?>(entityAndInt.Item1);
        var resultsWithTotal = (results, entityAndInt.Item2);

        return ResponseHelper.CreateTable(resultsWithTotal, x);
    }

    public async Task<MessageResponse> CreateOrUpdate(CreateOrUpdateCommand createOrUpdateCommand)
    {
        var entity = await CreateOrUpdateEntity(createOrUpdateCommand);

        var message = entity != null ? ConstantHelper.Success : ConstantHelper.Fail;
        var msg = ResponseHelper.CreateMessage(message, entity != null);

        return msg;
    }

    public async Task<MessageResponse> DeleteById(Guid id)
    {
        if (id == Guid.Empty) return ResponseHelper.CreateMessage(ConstantHelper.NotFound, false);

        var entity = await DeleteEntity(id);

        var message = entity != null ? ConstantHelper.Success : ConstantHelper.Fail;
        var msg = ResponseHelper.CreateMessage(message, entity != null);

        return msg;
    }

    private async Task<TEntity?> CreateOrUpdateEntity(CreateOrUpdateCommand createOrUpdateCommand)
    {
        TEntity? entity;
        if (createOrUpdateCommand is UpdateCommand updateCommand)
        {
            entity = await _baseRepository.GetById(updateCommand.Id);
            if (entity == null) return null;
            _mapper.Map(updateCommand, entity);
            SetBaseEntityUpdate(entity);
            _baseRepository.Update(entity);
        }
        else
        {
            entity = _mapper.Map<TEntity>(createOrUpdateCommand);
            if (entity == null) return null;
            entity.Id = Guid.NewGuid();
            SetBaseEntityCreate(entity);
            _baseRepository.Add(entity);
        }

        var saveChanges = await _unitOfWork.SaveChanges();
        return saveChanges ? entity : default;
    }


    private static void SetBaseEntityCreate(TEntity? entity)
    {
        if (entity == null) return;

        var user = InformationUser.User;

        entity.CreatedDate = DateTime.Now;
        entity.LastUpdatedDate = DateTime.Now;
        entity.IsDeleted = false;

        if (user == null) return;
        entity.CreatedBy = user.Email;
        entity.LastUpdatedBy = user.Email;
    }

    private static void SetBaseEntityUpdate(TEntity? entity)
    {
        if (entity == null) return;

        var user = InformationUser.User;

        entity.LastUpdatedDate = DateTime.Now;

        if (user == null) return;
        entity.LastUpdatedBy = user.Email;
    }

    private async Task<TEntity?> DeleteEntity(Guid id)
    {
        var entity = await _baseRepository.GetById(id);
        if (entity == null) return null;

        _baseRepository.Delete(entity);

        var saveChanges = await _unitOfWork.SaveChanges();
        return saveChanges ? entity : default;
    }
}