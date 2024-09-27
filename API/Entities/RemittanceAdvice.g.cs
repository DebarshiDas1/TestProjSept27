using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a remittanceadvice entity with essential details
    /// </summary>
    public class RemittanceAdvice
    {
        /// <summary>
        /// TenantId of the RemittanceAdvice 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the RemittanceAdvice 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the RemittanceAdvice 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the RemittanceAdvice 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Required field Date of the RemittanceAdvice 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        /// <summary>
        /// Description of the RemittanceAdvice 
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Required field Amount of the RemittanceAdvice 
        /// </summary>
        [Required]
        public int Amount { get; set; }

        /// <summary>
        /// CreatedOn of the RemittanceAdvice 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the RemittanceAdvice 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the RemittanceAdvice 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the RemittanceAdvice 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}