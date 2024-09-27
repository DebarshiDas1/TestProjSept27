using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a referral entity with essential details
    /// </summary>
    public class Referral
    {
        /// <summary>
        /// TenantId of the Referral 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Referral 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Referral 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Referral 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// ReferredTo of the Referral 
        /// </summary>
        public string? ReferredTo { get; set; }

        /// <summary>
        /// Required field DateReferred of the Referral 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DateReferred { get; set; }
        /// <summary>
        /// Reason of the Referral 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// Notes of the Referral 
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// CreatedOn of the Referral 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Referral 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Referral 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Referral 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}