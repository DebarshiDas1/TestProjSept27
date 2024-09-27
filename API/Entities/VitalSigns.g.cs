using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a vitalsigns entity with essential details
    /// </summary>
    public class VitalSigns
    {
        /// <summary>
        /// TenantId of the VitalSigns 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the VitalSigns 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the VitalSigns 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VitalSigns 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Unit of the VitalSigns 
        /// </summary>
        public string? Unit { get; set; }
        /// <summary>
        /// OrderBy of the VitalSigns 
        /// </summary>
        public int? OrderBy { get; set; }

        /// <summary>
        /// CreatedOn of the VitalSigns 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the VitalSigns 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the VitalSigns 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the VitalSigns 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}