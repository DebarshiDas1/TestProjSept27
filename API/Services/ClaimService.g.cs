using TestProjSept27.Models;
using TestProjSept27.Data;
using TestProjSept27.Filter;
using TestProjSept27.Entities;
using TestProjSept27.Logger;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using Task = System.Threading.Tasks.Task;

namespace TestProjSept27.Services
{
    /// <summary>
    /// The claimService responsible for managing claim related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting claim information.
    /// </remarks>
    public interface IClaimService
    {
        /// <summary>Retrieves a specific claim by its primary key</summary>
        /// <param name="id">The primary key of the claim</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The claim data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of claims based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of claims</returns>
        Task<List<Claim>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new claim</summary>
        /// <param name="model">The claim data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(Claim model);

        /// <summary>Updates a specific claim by its primary key</summary>
        /// <param name="id">The primary key of the claim</param>
        /// <param name="updatedEntity">The claim data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, Claim updatedEntity);

        /// <summary>Updates a specific claim by its primary key</summary>
        /// <param name="id">The primary key of the claim</param>
        /// <param name="updatedEntity">The claim data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<Claim> updatedEntity);

        /// <summary>Deletes a specific claim by its primary key</summary>
        /// <param name="id">The primary key of the claim</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The claimService responsible for managing claim related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting claim information.
    /// </remarks>
    public class ClaimService : IClaimService
    {
        private readonly TestProjSept27Context _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the Claim class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ClaimService(TestProjSept27Context dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific claim by its primary key</summary>
        /// <param name="id">The primary key of the claim</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The claim data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.Claim.AsQueryable();
            List<string> allfields = new List<string>();
            if (!string.IsNullOrEmpty(fields))
            {
                allfields.AddRange(fields.Split(","));
                fields = $"Id,{fields}";
            }
            else
            {
                fields = "Id";
            }

            string[] navigationProperties = [];
            foreach (var navigationProperty in navigationProperties)
            {
                if (allfields.Any(field => field.StartsWith(navigationProperty + ".", StringComparison.OrdinalIgnoreCase)))
                {
                    query = query.Include(navigationProperty);
                }
            }

            query = query.Where(entity => entity.Id == id);
            return _mapper.MapToFields(await query.FirstOrDefaultAsync(),fields);
        }

        /// <summary>Retrieves a list of claims based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of claims</returns>/// <exception cref="Exception"></exception>
        public async Task<List<Claim>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetClaim(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new claim</summary>
        /// <param name="model">The claim data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(Claim model)
        {
            model.Id = await CreateClaim(model);
            return model.Id;
        }

        /// <summary>Updates a specific claim by its primary key</summary>
        /// <param name="id">The primary key of the claim</param>
        /// <param name="updatedEntity">The claim data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, Claim updatedEntity)
        {
            await UpdateClaim(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific claim by its primary key</summary>
        /// <param name="id">The primary key of the claim</param>
        /// <param name="updatedEntity">The claim data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<Claim> updatedEntity)
        {
            await PatchClaim(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific claim by its primary key</summary>
        /// <param name="id">The primary key of the claim</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteClaim(id);
            return true;
        }
        #region
        private async Task<List<Claim>> GetClaim(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Claim.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Claim>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Claim), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Claim, object>>(Expression.Convert(property, typeof(object)), parameter);
                if (sortOrder.Equals("asc", StringComparison.OrdinalIgnoreCase))
                {
                    result = result.OrderBy(lambda);
                }
                else if (sortOrder.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    result = result.OrderByDescending(lambda);
                }
                else
                {
                    throw new ApplicationException("Invalid sort order. Use 'asc' or 'desc'");
                }
            }

            var paginatedResult = await result.Skip(skip).Take(pageSize).ToListAsync();
            return paginatedResult;
        }

        private async Task<Guid> CreateClaim(Claim model)
        {
            _dbContext.Claim.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateClaim(Guid id, Claim updatedEntity)
        {
            _dbContext.Claim.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteClaim(Guid id)
        {
            var entityData = _dbContext.Claim.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Claim.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchClaim(Guid id, JsonPatchDocument<Claim> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Claim.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Claim.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}