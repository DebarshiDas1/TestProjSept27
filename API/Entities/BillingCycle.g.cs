using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a billingcycle entity with essential details
    /// </summary>
    public class BillingCycle
    {
        /// <summary>
        /// TenantId of the BillingCycle 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the BillingCycle 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the BillingCycle 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the BillingCycle 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Required field StartDate of the BillingCycle 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Required field EndDate of the BillingCycle 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Required field ProviderId of the BillingCycle 
        /// </summary>
        [Required]
        public Guid ProviderId { get; set; }
        /// <summary>
        /// Status of the BillingCycle 
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// CreatedOn of the BillingCycle 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the BillingCycle 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the BillingCycle 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the BillingCycle 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}