using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a radiology entity with essential details
    /// </summary>
    public class Radiology
    {
        /// <summary>
        /// TenantId of the Radiology 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Radiology 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Radiology 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Radiology 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// ImagingType of the Radiology 
        /// </summary>
        public string? ImagingType { get; set; }

        /// <summary>
        /// Required field DatePerformed of the Radiology 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DatePerformed { get; set; }
        /// <summary>
        /// Notes of the Radiology 
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// CreatedOn of the Radiology 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Radiology 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Radiology 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Radiology 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}