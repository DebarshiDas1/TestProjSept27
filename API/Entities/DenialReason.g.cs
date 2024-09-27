using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a denialreason entity with essential details
    /// </summary>
    public class DenialReason
    {
        /// <summary>
        /// TenantId of the DenialReason 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the DenialReason 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the DenialReason 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the DenialReason 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Reason of the DenialReason 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// Description of the DenialReason 
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// CreatedOn of the DenialReason 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the DenialReason 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the DenialReason 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the DenialReason 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}