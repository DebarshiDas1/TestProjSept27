using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a clinic entity with essential details
    /// </summary>
    public class Clinic
    {
        /// <summary>
        /// TenantId of the Clinic 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Clinic 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Clinic 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Clinic 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Address of the Clinic 
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// Phone of the Clinic 
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// CreatedOn of the Clinic 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Clinic 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Clinic 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Clinic 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}