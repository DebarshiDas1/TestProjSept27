using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a diagnosiscodes entity with essential details
    /// </summary>
    public class DiagnosisCodes
    {
        /// <summary>
        /// TenantId of the DiagnosisCodes 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the DiagnosisCodes 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the DiagnosisCodes 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the DiagnosisCodes 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Description of the DiagnosisCodes 
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// CreatedOn of the DiagnosisCodes 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the DiagnosisCodes 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the DiagnosisCodes 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the DiagnosisCodes 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}