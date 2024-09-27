using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a examination entity with essential details
    /// </summary>
    public class Examination
    {
        /// <summary>
        /// TenantId of the Examination 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Examination 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Examination 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Examination 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// ExamType of the Examination 
        /// </summary>
        public string? ExamType { get; set; }

        /// <summary>
        /// Required field DatePerformed of the Examination 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DatePerformed { get; set; }
        /// <summary>
        /// Findings of the Examination 
        /// </summary>
        public string? Findings { get; set; }
        /// <summary>
        /// Notes of the Examination 
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// CreatedOn of the Examination 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Examination 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Examination 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Examination 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}