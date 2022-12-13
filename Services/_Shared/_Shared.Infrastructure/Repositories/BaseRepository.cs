namespace _Shared.Infrastructure.Repositories;

public abstract class BaseRepository<TAggregateRoot, TQueryModel> : IRepository<TAggregateRoot, TQueryModel>
    where TAggregateRoot : class, IAggregateRoot
    where TQueryModel : class, IQueryModel
{
    protected readonly BaseContext Context;
    protected readonly IConnectionDapperManager ConnectionDapper;

    public IDbContextUnitOfWork UnitOfWork => Context;


    protected BaseRepository(BaseContext context, IConnectionDapperManager connectionDapper)
    {
        Context = context;
        ConnectionDapper = connectionDapper;
    }

    protected abstract string GetFilter(IBaseParamModel? paramModel);

    protected abstract string GetBaseSql();

    private static void GetWhereClauseConcat(ref string fullFilter, WhereClauseOperatorEnum whereClauseOperator)
    {
        if (!string.IsNullOrEmpty(fullFilter))
        {
            fullFilter += whereClauseOperator switch
            {
                WhereClauseOperatorEnum.And => " and ",
                WhereClauseOperatorEnum.Or => " or ",
                _ => throw new InvalidEnumArgumentException($"InvalidParamOperator {whereClauseOperator}")
            };
        }
    }

    protected void AddStringFilter(
        ref string fullFilter,
        string field,
        string value,
        StringParamsEnum operation = StringParamsEnum.Equal,
        WhereClauseOperatorEnum whereClauseOperator = WhereClauseOperatorEnum.And
        )
    {
        if (string.IsNullOrEmpty(value))
            return;

        GetWhereClauseConcat(ref fullFilter, whereClauseOperator);

        fullFilter += operation switch
        {
            StringParamsEnum.Equal => $" {field}='{value}' ",
            StringParamsEnum.Different => $" {field}<>'{value}' ",
            StringParamsEnum.Contains => $" {field} like '%{value}%' ",
            StringParamsEnum.StartingWith => $" {field} like '{value}%' ",
            StringParamsEnum.EndingWith => $" {field} like '%{value}' ",
            _ => throw new InvalidEnumArgumentException($"InvalidParamOperator {field}")
        };
    }

    protected void AddNumericFilter(
        ref string fullFilter,
        string field,
        float value,
        NumericParamsEnum operation = NumericParamsEnum.Equal,
        WhereClauseOperatorEnum whereClauseOperator = WhereClauseOperatorEnum.And
        )
    {
        if (value == 0)
            return;

        GetWhereClauseConcat(ref fullFilter, whereClauseOperator);

        fullFilter += operation switch
        {
            NumericParamsEnum.Equal => $" {field} = {value} ",
            NumericParamsEnum.Different => $" {field} <> {value} ",
            NumericParamsEnum.GreaterThan => $" {field} > {value} ",
            NumericParamsEnum.GreaterThanOrEqual => $" {field} >= {value} ",
            NumericParamsEnum.LessThanOrEqual => $" {field} <= {value} ",
            NumericParamsEnum.LessThan => $" {field} < {value} ",
            _ => throw new InvalidEnumArgumentException($"InvalidParamOperator {field}")
        };
    }

    private string GetFullSql(IBaseParamModel? paramModel, int? pageSize, int? pageNumber)
    {
        var sql = GetBaseSql();
        var filter = GetFilter(paramModel);

        var pagination = pageSize.HasValue && pageNumber.HasValue
            ? $" limit {pageSize} offset {(pageNumber - 1) * pageSize} "
            : "";

        return
            sql
            + (!string.IsNullOrEmpty(filter) ? $" where {filter}" : "")
            + (!string.IsNullOrEmpty(pagination) ? $" {pagination}" : "");
    }

    public virtual async Task<List<TQueryModel>> GetAllAsync(CancellationToken cancellation, int? pageSize, int? pageNumber, IBaseParamModel? paramModel)
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        var generatedSql = GetFullSql(paramModel, pageSize, pageNumber);

        using var connection = await ConnectionDapper.GetConnectionAsync();

        var results = await connection.QueryAsync<TQueryModel>(generatedSql);

        return results.ToList();
    }

    public virtual async Task<TAggregateRoot?> GetByIdAsync(Guid id, CancellationToken cancellation)
    {
        var entity = await Context.Set<TAggregateRoot>().FirstOrDefaultAsync(m => m.Id == id);

        if (entity is null)
            throw new ArgumentNullException($"{id} not found");

        return entity;
    }

    public virtual async Task<TAggregateRoot> InsertAsync(TAggregateRoot entity, CancellationToken cancellation)
    {
        return (await Context.Set<TAggregateRoot>().AddAsync(entity)).Entity;
    }

    public virtual async Task<TAggregateRoot> UpdateAsync(Guid id, TAggregateRoot entity, CancellationToken cancellation)
    {
        var entityFromDb = await GetByIdAsync(id, cancellation);

        if (entityFromDb is null)
            throw new ArgumentNullException($"{id} not found");

        Context.Update(entity);

        return entity;
    }

    public virtual async Task<bool> DeleteAsync(Guid id, CancellationToken cancellation)
    {
        var entity = await GetByIdAsync(id, cancellation);

        if (entity == null)
            throw new ArgumentNullException($"{id} not found");

        Context.Remove(entity);

        return true;
    }

    public virtual async Task CommitAsync(CancellationToken cancellation)
    {
        await UnitOfWork.SaveChangesAsync();
    }
}
