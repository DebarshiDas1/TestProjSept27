using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a collectionagency entity with essential details
    /// </summary>
    public class CollectionAgency
    {
        /// <summary>
        /// TenantId of the CollectionAgency 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the CollectionAgency 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the CollectionAgency 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the CollectionAgency 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// ContactPerson of the CollectionAgency 
        /// </summary>
        public string? ContactPerson { get; set; }
        /// <summary>
        /// Phone of the CollectionAgency 
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// Email of the CollectionAgency 
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Address of the CollectionAgency 
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// CreatedOn of the CollectionAgency 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the CollectionAgency 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the CollectionAgency 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the CollectionAgency 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}