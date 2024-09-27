using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a explanationofbenefits entity with essential details
    /// </summary>
    public class ExplanationOfBenefits
    {
        /// <summary>
        /// TenantId of the ExplanationOfBenefits 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the ExplanationOfBenefits 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the ExplanationOfBenefits 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the ExplanationOfBenefits 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Claim to which the ExplanationOfBenefits belongs 
        /// </summary>
        public Guid? ClaimId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Claim
        /// </summary>
        [ForeignKey("ClaimId")]
        public Claim? ClaimId_Claim { get; set; }

        /// <summary>
        /// PaymentDate of the ExplanationOfBenefits 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PaymentDate { get; set; }
        /// <summary>
        /// PaymentAmount of the ExplanationOfBenefits 
        /// </summary>
        public int? PaymentAmount { get; set; }

        /// <summary>
        /// CreatedOn of the ExplanationOfBenefits 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the ExplanationOfBenefits 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the ExplanationOfBenefits 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the ExplanationOfBenefits 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}