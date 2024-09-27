using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a nurse entity with essential details
    /// </summary>
    public class Nurse
    {
        /// <summary>
        /// TenantId of the Nurse 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Nurse 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Nurse 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Nurse 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Clinic to which the Nurse belongs 
        /// </summary>
        public Guid? ClinicId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Clinic
        /// </summary>
        [ForeignKey("ClinicId")]
        public Clinic? ClinicId_Clinic { get; set; }
        /// <summary>
        /// Email of the Nurse 
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Phone of the Nurse 
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// Address of the Nurse 
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// CreatedOn of the Nurse 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Nurse 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Nurse 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Nurse 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}