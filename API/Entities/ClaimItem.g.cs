using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a claimitem entity with essential details
    /// </summary>
    public class ClaimItem
    {
        /// <summary>
        /// TenantId of the ClaimItem 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the ClaimItem 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the ClaimItem 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the ClaimItem 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the Claim to which the ClaimItem belongs 
        /// </summary>
        public Guid? ClaimId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Claim
        /// </summary>
        [ForeignKey("ClaimId")]
        public Claim? ClaimId_Claim { get; set; }

        /// <summary>
        /// Required field ServiceId of the ClaimItem 
        /// </summary>
        [Required]
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Required field Quantity of the ClaimItem 
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Required field UnitCost of the ClaimItem 
        /// </summary>
        [Required]
        public int UnitCost { get; set; }
        /// <summary>
        /// TotalCost of the ClaimItem 
        /// </summary>
        public int? TotalCost { get; set; }

        /// <summary>
        /// CreatedOn of the ClaimItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the ClaimItem 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the ClaimItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the ClaimItem 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}