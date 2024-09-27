using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a treatment entity with essential details
    /// </summary>
    public class Treatment
    {
        /// <summary>
        /// TenantId of the Treatment 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Treatment 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Treatment 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the Diagnosis to which the Treatment belongs 
        /// </summary>
        public Guid? DiagnosisId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Diagnosis
        /// </summary>
        [ForeignKey("DiagnosisId")]
        public Diagnosis? DiagnosisId_Diagnosis { get; set; }
        /// <summary>
        /// Name of the Treatment 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Description of the Treatment 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Type of the Treatment 
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// CreatedOn of the Treatment 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Treatment 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Treatment 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Treatment 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}