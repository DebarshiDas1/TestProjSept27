using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patient entity with essential details
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// TenantId of the Patient 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Patient 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Patient 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Patient 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Required field BirthDate of the Patient 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Gender of the Patient 
        /// </summary>
        public string? Gender { get; set; }
        /// <summary>
        /// Address of the Patient 
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// PhoneNumber of the Patient 
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// Email of the Patient 
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// CreatedOn of the Patient 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Patient 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Patient 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Patient 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}