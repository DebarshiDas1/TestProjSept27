using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a billableitems entity with essential details
    /// </summary>
    public class BillableItems
    {
        /// <summary>
        /// TenantId of the BillableItems 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the BillableItems 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the BillableItems 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the BillableItems 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Description of the BillableItems 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// UnitPrice of the BillableItems 
        /// </summary>
        public int? UnitPrice { get; set; }

        /// <summary>
        /// CreatedOn of the BillableItems 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the BillableItems 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the BillableItems 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the BillableItems 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}