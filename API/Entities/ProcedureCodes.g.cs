using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a procedurecodes entity with essential details
    /// </summary>
    public class ProcedureCodes
    {
        /// <summary>
        /// TenantId of the ProcedureCodes 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the ProcedureCodes 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the ProcedureCodes 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the ProcedureCodes 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Description of the ProcedureCodes 
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// CreatedOn of the ProcedureCodes 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the ProcedureCodes 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the ProcedureCodes 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the ProcedureCodes 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}