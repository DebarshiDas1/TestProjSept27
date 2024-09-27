using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a labresult entity with essential details
    /// </summary>
    public class LabResult
    {
        /// <summary>
        /// TenantId of the LabResult 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the LabResult 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the LabResult 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the LabResult 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Test of the LabResult 
        /// </summary>
        public string? Test { get; set; }
        /// <summary>
        /// Result of the LabResult 
        /// </summary>
        public string? Result { get; set; }

        /// <summary>
        /// Required field DatePerformed of the LabResult 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DatePerformed { get; set; }
        /// <summary>
        /// Notes of the LabResult 
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// CreatedOn of the LabResult 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the LabResult 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the LabResult 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the LabResult 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}