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
    /// The allergyService responsible for managing allergy related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting allergy information.
    /// </remarks>
    public interface IAllergyService
    {
        /// <summary>Retrieves a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The allergy data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of allergys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of allergys</returns>
        Task<List<Allergy>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new allergy</summary>
        /// <param name="model">The allergy data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(Allergy model);

        /// <summary>Updates a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <param name="updatedEntity">The allergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, Allergy updatedEntity);

        /// <summary>Updates a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <param name="updatedEntity">The allergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<Allergy> updatedEntity);

        /// <summary>Deletes a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The allergyService responsible for managing allergy related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting allergy information.
    /// </remarks>
    public class AllergyService : IAllergyService
    {
        private readonly TestProjSept27Context _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the Allergy class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public AllergyService(TestProjSept27Context dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The allergy data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.Allergy.AsQueryable();
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

        /// <summary>Retrieves a list of allergys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of allergys</returns>/// <exception cref="Exception"></exception>
        public async Task<List<Allergy>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetAllergy(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new allergy</summary>
        /// <param name="model">The allergy data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(Allergy model)
        {
            model.Id = await CreateAllergy(model);
            return model.Id;
        }

        /// <summary>Updates a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <param name="updatedEntity">The allergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, Allergy updatedEntity)
        {
            await UpdateAllergy(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <param name="updatedEntity">The allergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<Allergy> updatedEntity)
        {
            await PatchAllergy(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific allergy by its primary key</summary>
        /// <param name="id">The primary key of the allergy</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteAllergy(id);
            return true;
        }
        #region
        private async Task<List<Allergy>> GetAllergy(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Allergy.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Allergy>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Allergy), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Allergy, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateAllergy(Allergy model)
        {
            _dbContext.Allergy.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateAllergy(Guid id, Allergy updatedEntity)
        {
            _dbContext.Allergy.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteAllergy(Guid id)
        {
            var entityData = _dbContext.Allergy.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Allergy.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchAllergy(Guid id, JsonPatchDocument<Allergy> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Allergy.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Allergy.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}