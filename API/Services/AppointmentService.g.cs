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
    /// The appointmentService responsible for managing appointment related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting appointment information.
    /// </remarks>
    public interface IAppointmentService
    {
        /// <summary>Retrieves a specific appointment by its primary key</summary>
        /// <param name="id">The primary key of the appointment</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The appointment data</returns>
        Task<dynamic> GetById(Guid id, string fields);

        /// <summary>Retrieves a list of appointments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of appointments</returns>
        Task<List<Appointment>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc");

        /// <summary>Adds a new appointment</summary>
        /// <param name="model">The appointment data to be added</param>
        /// <returns>The result of the operation</returns>
        Task<Guid> Create(Appointment model);

        /// <summary>Updates a specific appointment by its primary key</summary>
        /// <param name="id">The primary key of the appointment</param>
        /// <param name="updatedEntity">The appointment data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Update(Guid id, Appointment updatedEntity);

        /// <summary>Updates a specific appointment by its primary key</summary>
        /// <param name="id">The primary key of the appointment</param>
        /// <param name="updatedEntity">The appointment data to be updated</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Patch(Guid id, JsonPatchDocument<Appointment> updatedEntity);

        /// <summary>Deletes a specific appointment by its primary key</summary>
        /// <param name="id">The primary key of the appointment</param>
        /// <returns>The result of the operation</returns>
        Task<bool> Delete(Guid id);
    }

    /// <summary>
    /// The appointmentService responsible for managing appointment related operations.
    /// </summary>
    /// <remarks>
    /// This service for adding, retrieving, updating, and deleting appointment information.
    /// </remarks>
    public class AppointmentService : IAppointmentService
    {
        private readonly TestProjSept27Context _dbContext;
        private readonly IFieldMapperService _mapper;

        /// <summary>
        /// Initializes a new instance of the Appointment class.
        /// </summary>
        /// <param name="dbContext">dbContext value to set.</param>
        /// <param name="mapper">mapper value to set.</param>
        public AppointmentService(TestProjSept27Context dbContext, IFieldMapperService mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Retrieves a specific appointment by its primary key</summary>
        /// <param name="id">The primary key of the appointment</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The appointment data</returns>
        public async Task<dynamic> GetById(Guid id, string fields)
        {
            var query = _dbContext.Appointment.AsQueryable();
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

            string[] navigationProperties = ["PatientId_Patient"];
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

        /// <summary>Retrieves a list of appointments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of appointments</returns>/// <exception cref="Exception"></exception>
        public async Task<List<Appointment>> Get(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            var result = await GetAppointment(filters, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return result;
        }

        /// <summary>Adds a new appointment</summary>
        /// <param name="model">The appointment data to be added</param>
        /// <returns>The result of the operation</returns>
        public async Task<Guid> Create(Appointment model)
        {
            model.Id = await CreateAppointment(model);
            return model.Id;
        }

        /// <summary>Updates a specific appointment by its primary key</summary>
        /// <param name="id">The primary key of the appointment</param>
        /// <param name="updatedEntity">The appointment data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Update(Guid id, Appointment updatedEntity)
        {
            await UpdateAppointment(id, updatedEntity);
            return true;
        }

        /// <summary>Updates a specific appointment by its primary key</summary>
        /// <param name="id">The primary key of the appointment</param>
        /// <param name="updatedEntity">The appointment data to be updated</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Patch(Guid id, JsonPatchDocument<Appointment> updatedEntity)
        {
            await PatchAppointment(id, updatedEntity);
            return true;
        }

        /// <summary>Deletes a specific appointment by its primary key</summary>
        /// <param name="id">The primary key of the appointment</param>
        /// <returns>The result of the operation</returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> Delete(Guid id)
        {
            await DeleteAppointment(id);
            return true;
        }
        #region
        private async Task<List<Appointment>> GetAppointment(List<FilterCriteria> filters = null, string searchTerm = "", int pageNumber = 1, int pageSize = 1, string sortField = null, string sortOrder = "asc")
        {
            if (pageSize < 1)
            {
                throw new ApplicationException("Page size invalid!");
            }

            if (pageNumber < 1)
            {
                throw new ApplicationException("Page mumber invalid!");
            }

            var query = _dbContext.Appointment.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<Appointment>.ApplyFilter(query, filters, searchTerm);
            if (!string.IsNullOrEmpty(sortField))
            {
                var parameter = Expression.Parameter(typeof(Appointment), "b");
                var property = Expression.Property(parameter, sortField);
                var lambda = Expression.Lambda<Func<Appointment, object>>(Expression.Convert(property, typeof(object)), parameter);
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

        private async Task<Guid> CreateAppointment(Appointment model)
        {
            _dbContext.Appointment.Add(model);
            await _dbContext.SaveChangesAsync();
            return model.Id;
        }

        private async Task UpdateAppointment(Guid id, Appointment updatedEntity)
        {
            _dbContext.Appointment.Update(updatedEntity);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<bool> DeleteAppointment(Guid id)
        {
            var entityData = _dbContext.Appointment.FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                throw new ApplicationException("No data found!");
            }

            _dbContext.Appointment.Remove(entityData);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task PatchAppointment(Guid id, JsonPatchDocument<Appointment> updatedEntity)
        {
            if (updatedEntity == null)
            {
                throw new ApplicationException("Patch document is missing!");
            }

            var existingEntity = _dbContext.Appointment.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new ApplicationException("No data found!");
            }

            updatedEntity.ApplyTo(existingEntity);
            _dbContext.Appointment.Update(existingEntity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}