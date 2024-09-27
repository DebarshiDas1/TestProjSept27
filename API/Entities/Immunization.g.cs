using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a immunization entity with essential details
    /// </summary>
    public class Immunization
    {
        /// <summary>
        /// TenantId of the Immunization 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Immunization 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Immunization 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Immunization 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Vaccine of the Immunization 
        /// </summary>
        public string? Vaccine { get; set; }

        /// <summary>
        /// Required field DateAdministered of the Immunization 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DateAdministered { get; set; }
        /// <summary>
        /// Notes of the Immunization 
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// CreatedOn of the Immunization 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Immunization 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Immunization 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Immunization 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}