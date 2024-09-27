using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a claim entity with essential details
    /// </summary>
    public class Claim
    {
        /// <summary>
        /// TenantId of the Claim 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Claim 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Claim 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Claim 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Required field PatientId of the Claim 
        /// </summary>
        [Required]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Required field ProviderId of the Claim 
        /// </summary>
        [Required]
        public Guid ProviderId { get; set; }
        /// <summary>
        /// ClaimStatus of the Claim 
        /// </summary>
        public string? ClaimStatus { get; set; }

        /// <summary>
        /// SubmissionDate of the Claim 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SubmissionDate { get; set; }
        /// <summary>
        /// TotalAmount of the Claim 
        /// </summary>
        public int? TotalAmount { get; set; }

        /// <summary>
        /// CreatedOn of the Claim 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Claim 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Claim 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Claim 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}