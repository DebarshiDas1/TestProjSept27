using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a allergy entity with essential details
    /// </summary>
    public class Allergy
    {
        /// <summary>
        /// TenantId of the Allergy 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Allergy 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Allergy 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Allergy 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Allergen of the Allergy 
        /// </summary>
        public string? Allergen { get; set; }
        /// <summary>
        /// Reaction of the Allergy 
        /// </summary>
        public string? Reaction { get; set; }
        /// <summary>
        /// Severity of the Allergy 
        /// </summary>
        public string? Severity { get; set; }
        /// <summary>
        /// Notes of the Allergy 
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// CreatedOn of the Allergy 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Allergy 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Allergy 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Allergy 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}