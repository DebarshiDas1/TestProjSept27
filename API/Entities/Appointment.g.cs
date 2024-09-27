using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a appointment entity with essential details
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// TenantId of the Appointment 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Appointment 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Appointment 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the Appointment belongs 
        /// </summary>
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }

        /// <summary>
        /// Required field Date of the Appointment 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        /// <summary>
        /// Reason of the Appointment 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// Notes of the Appointment 
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// CreatedOn of the Appointment 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Appointment 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Appointment 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Appointment 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}