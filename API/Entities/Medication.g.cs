using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medication entity with essential details
    /// </summary>
    public class Medication
    {
        /// <summary>
        /// TenantId of the Medication 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Medication 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Medication 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Medication 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Description of the Medication 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Manufacturer of the Medication 
        /// </summary>
        public string? Manufacturer { get; set; }

        /// <summary>
        /// CreatedOn of the Medication 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Medication 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Medication 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Medication 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}