using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a prescription entity with essential details
    /// </summary>
    public class Prescription
    {
        /// <summary>
        /// TenantId of the Prescription 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Prescription 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Prescription 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the Diagnosis to which the Prescription belongs 
        /// </summary>
        public Guid? DiagnosisId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Diagnosis
        /// </summary>
        [ForeignKey("DiagnosisId")]
        public Diagnosis? DiagnosisId_Diagnosis { get; set; }
        /// <summary>
        /// Foreign key referencing the Medication to which the Prescription belongs 
        /// </summary>
        public Guid? MedicationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Medication
        /// </summary>
        [ForeignKey("MedicationId")]
        public Medication? MedicationId_Medication { get; set; }
        /// <summary>
        /// Dosage of the Prescription 
        /// </summary>
        public string? Dosage { get; set; }
        /// <summary>
        /// Frequency of the Prescription 
        /// </summary>
        public string? Frequency { get; set; }
        /// <summary>
        /// Duration of the Prescription 
        /// </summary>
        public string? Duration { get; set; }
        /// <summary>
        /// Instructions of the Prescription 
        /// </summary>
        public string? Instructions { get; set; }

        /// <summary>
        /// CreatedOn of the Prescription 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Prescription 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Prescription 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Prescription 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}