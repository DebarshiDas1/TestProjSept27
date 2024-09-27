using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a billing entity with essential details
    /// </summary>
    public class Billing
    {
        /// <summary>
        /// TenantId of the Billing 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Billing 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Billing 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the Insurance to which the Billing belongs 
        /// </summary>
        public Guid? InsuranceId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Insurance
        /// </summary>
        [ForeignKey("InsuranceId")]
        public Insurance? InsuranceId_Insurance { get; set; }
        /// <summary>
        /// Foreign key referencing the Clinic to which the Billing belongs 
        /// </summary>
        public Guid? ClinicId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Clinic
        /// </summary>
        [ForeignKey("ClinicId")]
        public Clinic? ClinicId_Clinic { get; set; }
        /// <summary>
        /// Foreign key referencing the Doctor to which the Billing belongs 
        /// </summary>
        public Guid? DoctorId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Doctor
        /// </summary>
        [ForeignKey("DoctorId")]
        public Doctor? DoctorId_Doctor { get; set; }
        /// <summary>
        /// Amount of the Billing 
        /// </summary>
        public int? Amount { get; set; }
        /// <summary>
        /// Status of the Billing 
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// CreatedOn of the Billing 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Billing 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Billing 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Billing 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}