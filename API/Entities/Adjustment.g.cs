using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a adjustment entity with essential details
    /// </summary>
    public class Adjustment
    {
        /// <summary>
        /// TenantId of the Adjustment 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Adjustment 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Adjustment 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Adjustment 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Claim to which the Adjustment belongs 
        /// </summary>
        public Guid? ClaimId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Claim
        /// </summary>
        [ForeignKey("ClaimId")]
        public Claim? ClaimId_Claim { get; set; }
        /// <summary>
        /// AdjustmentType of the Adjustment 
        /// </summary>
        public string? AdjustmentType { get; set; }
        /// <summary>
        /// Description of the Adjustment 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// AdjustmentAmount of the Adjustment 
        /// </summary>
        public int? AdjustmentAmount { get; set; }

        /// <summary>
        /// CreatedOn of the Adjustment 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Adjustment 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Adjustment 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Adjustment 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}