using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a insurance entity with essential details
    /// </summary>
    public class Insurance
    {
        /// <summary>
        /// TenantId of the Insurance 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Insurance 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Insurance 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Insurance 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Address of the Insurance 
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// Phone of the Insurance 
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// Email of the Insurance 
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// CreatedOn of the Insurance 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Insurance 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Insurance 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Insurance 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}