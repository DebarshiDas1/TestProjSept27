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
    /// The billableitemsService responsible for managing billableitems related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting billableitems information.
    /// </remarks>
    public interface IBillableItemsService
    {
        /// <summary>Retrieves a specific billableitems by its primary key</summary>
        /// <param name="id">The primary key of the billableitems</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The billableitems data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of billableitemss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of billableitemss</returns>
        Task<List<BillableItems>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new billableitems</summary>
        /// <param name="model">The billableitems data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(BillableItems model);

        /// <summary>Updates a specific billableitems by its primary key</summary>
        /// <param name="id">The primary key of the billableitems</param>
        /// <param name="updatedEntity">The billableitems data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, BillableItems updatedEntity);

        /// <summary>Updates a specific billableitems by its primary key</summary>
        /// <param name="id">The primary key of the billableitems</param>
        /// <param name="updatedEntity">The billableitems data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<BillableItems> updatedEntity);

        /// <summary>Deletes a specific billableitems by its primary key</summary>
        /// <param name="id">The primary key of the billableitems</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The billableitemsService responsible for managing billableitems related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting billableitems information.
    /// </remarks>
    public class BillableItemsService : IBillableItemsService
    {
        private readonly TestProjSept27Context _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the BillableItems class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public BillableItemsService(TestProjSept27Context dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific billableitems by its primary key</summary>
        /// <param name="id">The primary key of the billableitems</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The billableitems data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.BillableItems.AsQueryable();
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

        /// <summary>Retrieves a list of billableitemss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of billableitemss</returns>/// <exception cref="Exception"></exception>
        public async Task<List<BillableItems>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetBillableItems(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new billableitems</summary>
        /// <param name="model">The billableitems data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(BillableItems model)
        {
            model.Id = await CreateBillableItems(model);
            return model.Id;
        }

        /// <summary>Updates a specific billableitems by its primary key</summary>
        /// <param name="id">The primary key of the billableitems</param>
        /// <param name="updatedEntity">The billableitems data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, BillableItems updatedEntity)
        {
            await UpdateBillableItems(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific billableitems by its primary key</summary>
        /// <param name="id">The primary key of the billableitems</param>
        /// <param name="updatedEntity">The billableitems data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<BillableItems> updatedEntity)
        {
            await PatchBillableItems(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific billableitems by its primary key</summary>
        /// <param name="id">The primary key of the billableitems</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteBillableItems(id);
            return true;
        }
        #region
        private async Task<List<BillableItems>> GetBillableItems(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.BillableItems.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<BillableItems>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(BillableItems), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<BillableItems, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateBillableItems(BillableItems model)
        {
            _dbContext.BillableItems.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateBillableItems(Guid id, BillableItems updatedEntity)
        {
            _dbContext.BillableItems.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteBillableItems(Guid id)
        {
            var entityData = _dbContext.BillableItems.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.BillableItems.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchBillableItems(Guid id, JsonPatchDocument<BillableItems> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.BillableItems.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.BillableItems.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}