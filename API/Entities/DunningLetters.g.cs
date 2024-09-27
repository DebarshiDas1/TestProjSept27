using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a dunningletters entity with essential details
    /// </summary>
    public class DunningLetters
    {
        /// <summary>
        /// TenantId of the DunningLetters 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the DunningLetters 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the DunningLetters 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the DunningLetters 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Required field Date of the DunningLetters 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        /// <summary>
        /// Description of the DunningLetters 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Foreign key referencing the Statement to which the DunningLetters belongs 
        /// </summary>
        public Guid? StatementId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Statement
        /// </summary>
        [ForeignKey("StatementId")]
        public Statement? StatementId_Statement { get; set; }

        /// <summary>
        /// CreatedOn of the DunningLetters 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the DunningLetters 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the DunningLetters 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the DunningLetters 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}