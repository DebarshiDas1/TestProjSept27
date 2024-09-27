using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medicalproviders entity with essential details
    /// </summary>
    public class MedicalProviders
    {
        /// <summary>
        /// TenantId of the MedicalProviders 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the MedicalProviders 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the MedicalProviders 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the MedicalProviders 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Specialty of the MedicalProviders 
        /// </summary>
        public string? Specialty { get; set; }
        /// <summary>
        /// Address of the MedicalProviders 
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// Phone of the MedicalProviders 
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// Email of the MedicalProviders 
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// CreatedOn of the MedicalProviders 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the MedicalProviders 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the MedicalProviders 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the MedicalProviders 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}