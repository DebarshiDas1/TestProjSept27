using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a healthhistory entity with essential details
    /// </summary>
    public class HealthHistory
    {
        /// <summary>
        /// TenantId of the HealthHistory 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the HealthHistory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the HealthHistory 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the HealthHistory 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Description of the HealthHistory 
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// CreatedOn of the HealthHistory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the HealthHistory 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the HealthHistory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the HealthHistory 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}