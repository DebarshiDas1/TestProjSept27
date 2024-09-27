using Microsoft.AspNetCore.Mvc;
using TestProjSept27.Models;
using TestProjSept27.Services;
using TestProjSept27.Entities;
using TestProjSept27.Filter;
using TestProjSept27.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Task = System.Threading.Tasks.Task;
using TestProjSept27.Authorization;

namespace TestProjSept27.Controllers
{
    /// <summary>
    /// Controller responsible for managing remittanceadvice related operations.
    /// </summary>
    /// <remarks>
    /// This Controller provides endpoints for adding, retrieving, updating, and deleting remittanceadvice information.
    /// </remarks>
    [Route("api/remittanceadvice")]
    [Authorize]
    public class RemittanceAdviceController : BaseApiController
    {
        private readonly IRemittanceAdviceService _remittanceAdviceService;

        /// <summary>
        /// Initializes a new instance of the RemittanceAdviceController class with the specified context.
        /// </summary>
        /// <param name="iremittanceadviceservice">The iremittanceadviceservice to be used by the controller.</param>
        public RemittanceAdviceController(IRemittanceAdviceService iremittanceadviceservice)
        {
            _remittanceAdviceService = iremittanceadviceservice;
        }

        /// <summary>Adds a new remittanceadvice</summary>
        /// <param name="model">The remittanceadvice data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("RemittanceAdvice", Entitlements.Create)]
        public async Task<IActionResult> Post([FromBody] RemittanceAdvice model)
        {
            model.TenantId = TenantId;
            model.CreatedOn = DateTime.UtcNow;
            model.CreatedBy = UserId;
            var id = await _remittanceAdviceService.Create(model);
            return Ok(new { id });
        }

        /// <summary>Retrieves a list of remittanceadvices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="searchTerm">To searching data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sortField">The entity's field name to sort.</param>
        /// <param name="sortOrder">The sort order asc or desc.</param>
        /// <returns>The filtered list of remittanceadvices</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("RemittanceAdvice", Entitlements.Read)]
        public async Task<IActionResult> Get([FromQuery] string filters, string searchTerm, int pageNumber = 1, int pageSize = 10, string sortField = null, string sortOrder = "asc")
        {
            List<FilterCriteria> filterCriteria = null;
            if (pageSize < 1)
            {
                return BadRequest("Page size invalid.");
            }

            if (pageNumber < 1)
            {
                return BadRequest("Page mumber invalid.");
            }

            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var result = await _remittanceAdviceService.Get(filterCriteria, searchTerm, pageNumber, pageSize, sortField, sortOrder);
            return Ok(result);
        }

        /// <summary>Retrieves a specific remittanceadvice by its primary key</summary>
        /// <param name="id">The primary key of the remittanceadvice</param>
        /// <param name="fields">The fields is fetch data of selected fields</param>
        /// <returns>The remittanceadvice data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        [UserAuthorize("RemittanceAdvice", Entitlements.Read)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, string fields = null)
        {
            var result = await _remittanceAdviceService.GetById( id, fields);
            return Ok(result);
        }

        /// <summary>Deletes a specific remittanceadvice by its primary key</summary>
        /// <param name="id">The primary key of the remittanceadvice</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [Route("{id:Guid}")]
        [UserAuthorize("RemittanceAdvice", Entitlements.Delete)]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var status = await _remittanceAdviceService.Delete(id);
            return Ok(new { status });
        }

        /// <summary>Updates a specific remittanceadvice by its primary key</summary>
        /// <param name="id">The primary key of the remittanceadvice</param>
        /// <param name="updatedEntity">The remittanceadvice data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("RemittanceAdvice", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] RemittanceAdvice updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            updatedEntity.TenantId = TenantId;
            updatedEntity.UpdatedOn = DateTime.UtcNow;
            updatedEntity.UpdatedBy = UserId;
            var status = await _remittanceAdviceService.Update(id, updatedEntity);
            return Ok(new { status });
        }

        /// <summary>Updates a specific remittanceadvice by its primary key</summary>
        /// <param name="id">The primary key of the remittanceadvice</param>
        /// <param name="updatedEntity">The remittanceadvice data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [UserAuthorize("RemittanceAdvice", Entitlements.Update)]
        public async Task<IActionResult> UpdateById(Guid id, [FromBody] JsonPatchDocument<RemittanceAdvice> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var status = await _remittanceAdviceService.Patch(id, updatedEntity);
            return Ok(new { status });
        }
    }
}