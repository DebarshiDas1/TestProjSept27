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
    /// The medicalprovidersService responsible for managing medicalproviders related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicalproviders information.
    /// </remarks>
    public interface IMedicalProvidersService
    {
        /// <summary>Retrieves a specific medicalproviders by its primary key</summary>
        /// <param name="id">The primary key of the medicalproviders</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The medicalproviders data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of medicalproviderss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicalproviderss</returns>
        Task<List<MedicalProviders>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new medicalproviders</summary>
        /// <param name="model">The medicalproviders data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(MedicalProviders model);

        /// <summary>Updates a specific medicalproviders by its primary key</summary>
        /// <param name="id">The primary key of the medicalproviders</param>
        /// <param name="updatedEntity">The medicalproviders data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, MedicalProviders updatedEntity);

        /// <summary>Updates a specific medicalproviders by its primary key</summary>
        /// <param name="id">The primary key of the medicalproviders</param>
        /// <param name="updatedEntity">The medicalproviders data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<MedicalProviders> updatedEntity);

        /// <summary>Deletes a specific medicalproviders by its primary key</summary>
        /// <param name="id">The primary key of the medicalproviders</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The medicalprovidersService responsible for managing medicalproviders related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicalproviders information.
    /// </remarks>
    public class MedicalProvidersService : IMedicalProvidersService
    {
        private readonly TestProjSept27Context _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the MedicalProviders class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public MedicalProvidersService(TestProjSept27Context dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific medicalproviders by its primary key</summary>
        /// <param name="id">The primary key of the medicalproviders</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The medicalproviders data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.MedicalProviders.AsQueryable();
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

        /// <summary>Retrieves a list of medicalproviderss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicalproviderss</returns>/// <exception cref="Exception"></exception>
        public async Task<List<MedicalProviders>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetMedicalProviders(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new medicalproviders</summary>
        /// <param name="model">The medicalproviders data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(MedicalProviders model)
        {
            model.Id = await CreateMedicalProviders(model);
            return model.Id;
        }

        /// <summary>Updates a specific medicalproviders by its primary key</summary>
        /// <param name="id">The primary key of the medicalproviders</param>
        /// <param name="updatedEntity">The medicalproviders data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, MedicalProviders updatedEntity)
        {
            await UpdateMedicalProviders(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific medicalproviders by its primary key</summary>
        /// <param name="id">The primary key of the medicalproviders</param>
        /// <param name="updatedEntity">The medicalproviders data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<MedicalProviders> updatedEntity)
        {
            await PatchMedicalProviders(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific medicalproviders by its primary key</summary>
        /// <param name="id">The primary key of the medicalproviders</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteMedicalProviders(id);
            return true;
        }
        #region
        private async Task<List<MedicalProviders>> GetMedicalProviders(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MedicalProviders.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MedicalProviders>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MedicalProviders), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MedicalProviders, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateMedicalProviders(MedicalProviders model)
        {
            _dbContext.MedicalProviders.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateMedicalProviders(Guid id, MedicalProviders updatedEntity)
        {
            _dbContext.MedicalProviders.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteMedicalProviders(Guid id)
        {
            var entityData = _dbContext.MedicalProviders.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MedicalProviders.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchMedicalProviders(Guid id, JsonPatchDocument<MedicalProviders> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MedicalProviders.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MedicalProviders.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}