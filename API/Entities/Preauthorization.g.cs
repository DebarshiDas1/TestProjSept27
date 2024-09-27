using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a preauthorization entity with essential details
    /// </summary>
    public class Preauthorization
    {
        /// <summary>
        /// TenantId of the Preauthorization 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Preauthorization 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Preauthorization 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Preauthorization 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Required field PatientId of the Preauthorization 
        /// </summary>
        [Required]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Required field ProviderId of the Preauthorization 
        /// </summary>
        [Required]
        public Guid ProviderId { get; set; }
        /// <summary>
        /// AuthorizationNumber of the Preauthorization 
        /// </summary>
        public string? AuthorizationNumber { get; set; }

        /// <summary>
        /// AuthorizationDate of the Preauthorization 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? AuthorizationDate { get; set; }

        /// <summary>
        /// ExpirationDate of the Preauthorization 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }
        /// <summary>
        /// Status of the Preauthorization 
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// CreatedOn of the Preauthorization 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Preauthorization 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Preauthorization 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Preauthorization 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}