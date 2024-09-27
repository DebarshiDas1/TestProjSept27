using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medicalservices entity with essential details
    /// </summary>
    public class MedicalServices
    {
        /// <summary>
        /// TenantId of the MedicalServices 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the MedicalServices 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the MedicalServices 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the MedicalServices 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Description of the MedicalServices 
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// CreatedOn of the MedicalServices 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the MedicalServices 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the MedicalServices 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the MedicalServices 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}