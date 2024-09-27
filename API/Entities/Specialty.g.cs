using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a specialty entity with essential details
    /// </summary>
    public class Specialty
    {
        /// <summary>
        /// TenantId of the Specialty 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Specialty 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Specialty 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Specialty 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Description of the Specialty 
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// CreatedOn of the Specialty 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Specialty 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Specialty 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Specialty 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}