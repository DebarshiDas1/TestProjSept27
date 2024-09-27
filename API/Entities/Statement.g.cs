using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a statement entity with essential details
    /// </summary>
    public class Statement
    {
        /// <summary>
        /// TenantId of the Statement 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Statement 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the Statement 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Statement 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Required field Date of the Statement 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        /// <summary>
        /// Description of the Statement 
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Required field TotalAmount of the Statement 
        /// </summary>
        [Required]
        public int TotalAmount { get; set; }

        /// <summary>
        /// CreatedOn of the Statement 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the Statement 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the Statement 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the Statement 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}