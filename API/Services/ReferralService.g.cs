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
    /// The referralService responsible for managing referral related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting referral information.
    /// </remarks>
    public interface IReferralService
    {
        /// <summary>Retrieves a specific referral by its primary key</summary>
        /// <param name="id">The primary key of the referral</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The referral data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of referrals based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of referrals</returns>
        Task<List<Referral>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new referral</summary>
        /// <param name="model">The referral data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(Referral model);

        /// <summary>Updates a specific referral by its primary key</summary>
        /// <param name="id">The primary key of the referral</param>
        /// <param name="updatedEntity">The referral data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, Referral updatedEntity);

        /// <summary>Updates a specific referral by its primary key</summary>
        /// <param name="id">The primary key of the referral</param>
        /// <param name="updatedEntity">The referral data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<Referral> updatedEntity);

        /// <summary>Deletes a specific referral by its primary key</summary>
        /// <param name="id">The primary key of the referral</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The referralService responsible for managing referral related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting referral information.
    /// </remarks>
    public class ReferralService : IReferralService
    {
        private readonly TestProjSept27Context _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the Referral class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public ReferralService(TestProjSept27Context dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific referral by its primary key</summary>
        /// <param name="id">The primary key of the referral</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The referral data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.Referral.AsQueryable();
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

        /// <summary>Retrieves a list of referrals based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of referrals</returns>/// <exception cref="Exception"></exception>
        public async Task<List<Referral>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetReferral(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new referral</summary>
        /// <param name="model">The referral data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(Referral model)
        {
            model.Id = await CreateReferral(model);
            return model.Id;
        }

        /// <summary>Updates a specific referral by its primary key</summary>
        /// <param name="id">The primary key of the referral</param>
        /// <param name="updatedEntity">The referral data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, Referral updatedEntity)
        {
            await UpdateReferral(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific referral by its primary key</summary>
        /// <param name="id">The primary key of the referral</param>
        /// <param name="updatedEntity">The referral data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<Referral> updatedEntity)
        {
            await PatchReferral(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific referral by its primary key</summary>
        /// <param name="id">The primary key of the referral</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteReferral(id);
            return true;
        }
        #region
        private async Task<List<Referral>> GetReferral(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Referral.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Referral>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Referral), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Referral, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateReferral(Referral model)
        {
            _dbContext.Referral.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateReferral(Guid id, Referral updatedEntity)
        {
            _dbContext.Referral.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteReferral(Guid id)
        {
            var entityData = _dbContext.Referral.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Referral.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchReferral(Guid id, JsonPatchDocument<Referral> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Referral.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Referral.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}