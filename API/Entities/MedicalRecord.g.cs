using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medicalrecord entity with essential details
    /// </summary>
    public class MedicalRecord
    {
        /// <summary>
        /// TenantId of the MedicalRecord 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the MedicalRecord 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the MedicalRecord 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the MedicalRecord belongs 
        /// </summary>
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }
        /// <summary>
        /// Foreign key referencing the Appointment to which the MedicalRecord belongs 
        /// </summary>
        public Guid? AppointmentId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Appointment
        /// </summary>
        [ForeignKey("AppointmentId")]
        public Appointment? AppointmentId_Appointment { get; set; }
        /// <summary>
        /// Notes of the MedicalRecord 
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// CreatedOn of the MedicalRecord 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the MedicalRecord 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the MedicalRecord 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the MedicalRecord 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}