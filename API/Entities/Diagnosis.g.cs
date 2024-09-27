using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a diagnosis entity with essential details
    /// </summary>
    public class Diagnosis
    {
        /// <summary>
        /// TenantId of the Diagnosis 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Diagnosis 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Diagnosis 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the MedicalRecord to which the Diagnosis belongs 
        /// </summary>
        public Guid? MedicalRecordId { get; set; }

        /// <summary>
        /// Navigation property representing the associated MedicalRecord
        /// </summary>
        [ForeignKey("MedicalRecordId")]
        public MedicalRecord? MedicalRecordId_MedicalRecord { get; set; }
        /// <summary>
        /// Description of the Diagnosis 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Status of the Diagnosis 
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// CreatedOn of the Diagnosis 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Diagnosis 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Diagnosis 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Diagnosis 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}