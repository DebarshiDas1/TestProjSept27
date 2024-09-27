using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a writeoffs entity with essential details
    /// </summary>
    public class WriteOffs
    {
        /// <summary>
        /// TenantId of the WriteOffs 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the WriteOffs 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the WriteOffs 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the WriteOffs 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Required field Date of the WriteOffs 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Required field Amount of the WriteOffs 
        /// </summary>
        [Required]
        public int Amount { get; set; }
        /// <summary>
        /// Description of the WriteOffs 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Foreign key referencing the Statement to which the WriteOffs belongs 
        /// </summary>
        public Guid? StatementId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Statement
        /// </summary>
        [ForeignKey("StatementId")]
        public Statement? StatementId_Statement { get; set; }

        /// <summary>
        /// CreatedOn of the WriteOffs 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the WriteOffs 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the WriteOffs 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the WriteOffs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}