using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a agingreport entity with essential details
    /// </summary>
    public class AgingReport
    {
        /// <summary>
        /// TenantId of the AgingReport 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the AgingReport 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the AgingReport 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the AgingReport 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Required field Date of the AgingReport 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Required field ZeroToThirtyDays of the AgingReport 
        /// </summary>
        [Required]
        public int ZeroToThirtyDays { get; set; }

        /// <summary>
        /// Required field ThirtyOneToSixtyDays of the AgingReport 
        /// </summary>
        [Required]
        public int ThirtyOneToSixtyDays { get; set; }

        /// <summary>
        /// Required field SixtyOneToNinetyDays of the AgingReport 
        /// </summary>
        [Required]
        public int SixtyOneToNinetyDays { get; set; }

        /// <summary>
        /// Required field OverNinetyDays of the AgingReport 
        /// </summary>
        [Required]
        public int OverNinetyDays { get; set; }

        /// <summary>
        /// CreatedOn of the AgingReport 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the AgingReport 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the AgingReport 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the AgingReport 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}