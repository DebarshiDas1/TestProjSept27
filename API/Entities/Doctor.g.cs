using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a doctor entity with essential details
    /// </summary>
    public class Doctor
    {
        /// <summary>
        /// TenantId of the Doctor 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Doctor 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Doctor 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Doctor 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Specialty to which the Doctor belongs 
        /// </summary>
        public Guid? SpecialtyId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Specialty
        /// </summary>
        [ForeignKey("SpecialtyId")]
        public Specialty? SpecialtyId_Specialty { get; set; }
        /// <summary>
        /// Foreign key referencing the Clinic to which the Doctor belongs 
        /// </summary>
        public Guid? ClinicId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Clinic
        /// </summary>
        [ForeignKey("ClinicId")]
        public Clinic? ClinicId_Clinic { get; set; }
        /// <summary>
        /// Email of the Doctor 
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Phone of the Doctor 
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// Address of the Doctor 
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// CreatedOn of the Doctor 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Doctor 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Doctor 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Doctor 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}