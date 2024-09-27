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
    /// The medicalservicesService responsible for managing medicalservices related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicalservices information.
    /// </remarks>
    public interface IMedicalServicesService
    {
        /// <summary>Retrieves a specific medicalservices by its primary key</summary>
        /// <param name="id">The primary key of the medicalservices</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The medicalservices data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of medicalservicess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicalservicess</returns>
        Task<List<MedicalServices>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new medicalservices</summary>
        /// <param name="model">The medicalservices data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(MedicalServices model);

        /// <summary>Updates a specific medicalservices by its primary key</summary>
        /// <param name="id">The primary key of the medicalservices</param>
        /// <param name="updatedEntity">The medicalservices data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, MedicalServices updatedEntity);

        /// <summary>Updates a specific medicalservices by its primary key</summary>
        /// <param name="id">The primary key of the medicalservices</param>
        /// <param name="updatedEntity">The medicalservices data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<MedicalServices> updatedEntity);

        /// <summary>Deletes a specific medicalservices by its primary key</summary>
        /// <param name="id">The primary key of the medicalservices</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The medicalservicesService responsible for managing medicalservices related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting medicalservices information.
    /// </remarks>
    public class MedicalServicesService : IMedicalServicesService
    {
        private readonly TestProjSept27Context _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the MedicalServices class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public MedicalServicesService(TestProjSept27Context dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific medicalservices by its primary key</summary>
        /// <param name="id">The primary key of the medicalservices</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The medicalservices data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.MedicalServices.AsQueryable();
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

        /// <summary>Retrieves a list of medicalservicess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of medicalservicess</returns>/// <exception cref="Exception"></exception>
        public async Task<List<MedicalServices>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetMedicalServices(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new medicalservices</summary>
        /// <param name="model">The medicalservices data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(MedicalServices model)
        {
            model.Id = await CreateMedicalServices(model);
            return model.Id;
        }

        /// <summary>Updates a specific medicalservices by its primary key</summary>
        /// <param name="id">The primary key of the medicalservices</param>
        /// <param name="updatedEntity">The medicalservices data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, MedicalServices updatedEntity)
        {
            await UpdateMedicalServices(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific medicalservices by its primary key</summary>
        /// <param name="id">The primary key of the medicalservices</param>
        /// <param name="updatedEntity">The medicalservices data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<MedicalServices> updatedEntity)
        {
            await PatchMedicalServices(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific medicalservices by its primary key</summary>
        /// <param name="id">The primary key of the medicalservices</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteMedicalServices(id);
            return true;
        }
        #region
        private async Task<List<MedicalServices>> GetMedicalServices(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.MedicalServices.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<MedicalServices>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(MedicalServices), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<MedicalServices, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateMedicalServices(MedicalServices model)
        {
            _dbContext.MedicalServices.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateMedicalServices(Guid id, MedicalServices updatedEntity)
        {
            _dbContext.MedicalServices.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteMedicalServices(Guid id)
        {
            var entityData = _dbContext.MedicalServices.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.MedicalServices.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchMedicalServices(Guid id, JsonPatchDocument<MedicalServices> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.MedicalServices.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.MedicalServices.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}