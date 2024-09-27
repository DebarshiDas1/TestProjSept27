using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProjSept27.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a insurancecompanies entity with essential details
    /// </summary>
    public class InsuranceCompanies
    {
        /// <summary>
        /// TenantId of the InsuranceCompanies 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the InsuranceCompanies 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Code of the InsuranceCompanies 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the InsuranceCompanies 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Address of the InsuranceCompanies 
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// Phone of the InsuranceCompanies 
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// Email of the InsuranceCompanies 
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// CreatedOn of the InsuranceCompanies 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// CreatedBy of the InsuranceCompanies 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the InsuranceCompanies 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// UpdatedBy of the InsuranceCompanies 
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}