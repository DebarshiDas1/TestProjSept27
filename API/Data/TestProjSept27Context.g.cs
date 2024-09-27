using Microsoft.EntityFrameworkCore;
using TestProjSept27.Entities;

namespace TestProjSept27.Data
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class TestProjSept27Context : DbContext
    {
        /// <summary>
        /// Configures the database connection options.
        /// </summary>
        /// <param name="optionsBuilder">The options builder used to configure the database connection.</param>
        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=testprojsept27.database.windows.net;Initial Catalog=T631688_TestProjSept27;Persist Security Info=True;user id=sysad;password=Qwerty_123456@;Integrated Security=false;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true;");
        }

        /// <summary>
        /// Configures the model relationships and entity mappings.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the database model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInRole>().HasKey(a => a.Id);
            modelBuilder.Entity<UserToken>().HasKey(a => a.Id);
            modelBuilder.Entity<RoleEntitlement>().HasKey(a => a.Id);
            modelBuilder.Entity<Entity>().HasKey(a => a.Id);
            modelBuilder.Entity<Tenant>().HasKey(a => a.Id);
            modelBuilder.Entity<User>().HasKey(a => a.Id);
            modelBuilder.Entity<Role>().HasKey(a => a.Id);
            modelBuilder.Entity<RemittanceAdvice>().HasKey(a => a.Id);
            modelBuilder.Entity<Statement>().HasKey(a => a.Id);
            modelBuilder.Entity<CollectionAgency>().HasKey(a => a.Id);
            modelBuilder.Entity<DunningLetters>().HasKey(a => a.Id);
            modelBuilder.Entity<WriteOffs>().HasKey(a => a.Id);
            modelBuilder.Entity<AgingReport>().HasKey(a => a.Id);
            modelBuilder.Entity<Claim>().HasKey(a => a.Id);
            modelBuilder.Entity<ClaimItem>().HasKey(a => a.Id);
            modelBuilder.Entity<Adjustment>().HasKey(a => a.Id);
            modelBuilder.Entity<Preauthorization>().HasKey(a => a.Id);
            modelBuilder.Entity<DenialReason>().HasKey(a => a.Id);
            modelBuilder.Entity<ExplanationOfBenefits>().HasKey(a => a.Id);
            modelBuilder.Entity<BillingCycle>().HasKey(a => a.Id);
            modelBuilder.Entity<VitalSigns>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicalProviders>().HasKey(a => a.Id);
            modelBuilder.Entity<InsuranceCompanies>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicalServices>().HasKey(a => a.Id);
            modelBuilder.Entity<DiagnosisCodes>().HasKey(a => a.Id);
            modelBuilder.Entity<ProcedureCodes>().HasKey(a => a.Id);
            modelBuilder.Entity<BillableItems>().HasKey(a => a.Id);
            modelBuilder.Entity<HealthHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<Allergy>().HasKey(a => a.Id);
            modelBuilder.Entity<Immunization>().HasKey(a => a.Id);
            modelBuilder.Entity<Referral>().HasKey(a => a.Id);
            modelBuilder.Entity<LabResult>().HasKey(a => a.Id);
            modelBuilder.Entity<Radiology>().HasKey(a => a.Id);
            modelBuilder.Entity<Examination>().HasKey(a => a.Id);
            modelBuilder.Entity<Doctor>().HasKey(a => a.Id);
            modelBuilder.Entity<Nurse>().HasKey(a => a.Id);
            modelBuilder.Entity<Clinic>().HasKey(a => a.Id);
            modelBuilder.Entity<Specialty>().HasKey(a => a.Id);
            modelBuilder.Entity<Insurance>().HasKey(a => a.Id);
            modelBuilder.Entity<Billing>().HasKey(a => a.Id);
            modelBuilder.Entity<Payment>().HasKey(a => a.Id);
            modelBuilder.Entity<Patient>().HasKey(a => a.Id);
            modelBuilder.Entity<Appointment>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicalRecord>().HasKey(a => a.Id);
            modelBuilder.Entity<Diagnosis>().HasKey(a => a.Id);
            modelBuilder.Entity<Treatment>().HasKey(a => a.Id);
            modelBuilder.Entity<Prescription>().HasKey(a => a.Id);
            modelBuilder.Entity<Medication>().HasKey(a => a.Id);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.RoleId_Role).WithMany().HasForeignKey(c => c.RoleId);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<UserToken>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserToken>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.RoleId_Role).WithMany().HasForeignKey(c => c.RoleId);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.EntityId_Entity).WithMany().HasForeignKey(c => c.EntityId);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Entity>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Entity>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Entity>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<User>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Role>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Role>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Role>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DunningLetters>().HasOne(a => a.StatementId_Statement).WithMany().HasForeignKey(c => c.StatementId);
            modelBuilder.Entity<WriteOffs>().HasOne(a => a.StatementId_Statement).WithMany().HasForeignKey(c => c.StatementId);
            modelBuilder.Entity<ClaimItem>().HasOne(a => a.ClaimId_Claim).WithMany().HasForeignKey(c => c.ClaimId);
            modelBuilder.Entity<Adjustment>().HasOne(a => a.ClaimId_Claim).WithMany().HasForeignKey(c => c.ClaimId);
            modelBuilder.Entity<ExplanationOfBenefits>().HasOne(a => a.ClaimId_Claim).WithMany().HasForeignKey(c => c.ClaimId);
            modelBuilder.Entity<Doctor>().HasOne(a => a.SpecialtyId_Specialty).WithMany().HasForeignKey(c => c.SpecialtyId);
            modelBuilder.Entity<Doctor>().HasOne(a => a.ClinicId_Clinic).WithMany().HasForeignKey(c => c.ClinicId);
            modelBuilder.Entity<Nurse>().HasOne(a => a.ClinicId_Clinic).WithMany().HasForeignKey(c => c.ClinicId);
            modelBuilder.Entity<Billing>().HasOne(a => a.InsuranceId_Insurance).WithMany().HasForeignKey(c => c.InsuranceId);
            modelBuilder.Entity<Billing>().HasOne(a => a.ClinicId_Clinic).WithMany().HasForeignKey(c => c.ClinicId);
            modelBuilder.Entity<Billing>().HasOne(a => a.DoctorId_Doctor).WithMany().HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<Payment>().HasOne(a => a.BillingId_Billing).WithMany().HasForeignKey(c => c.BillingId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<MedicalRecord>().HasOne(a => a.PatientId_Patient).WithMany().HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<MedicalRecord>().HasOne(a => a.AppointmentId_Appointment).WithMany().HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<Diagnosis>().HasOne(a => a.MedicalRecordId_MedicalRecord).WithMany().HasForeignKey(c => c.MedicalRecordId);
            modelBuilder.Entity<Treatment>().HasOne(a => a.DiagnosisId_Diagnosis).WithMany().HasForeignKey(c => c.DiagnosisId);
            modelBuilder.Entity<Prescription>().HasOne(a => a.DiagnosisId_Diagnosis).WithMany().HasForeignKey(c => c.DiagnosisId);
            modelBuilder.Entity<Prescription>().HasOne(a => a.MedicationId_Medication).WithMany().HasForeignKey(c => c.MedicationId);
        }

        /// <summary>
        /// Represents the database set for the UserInRole entity.
        /// </summary>
        public DbSet<UserInRole> UserInRole { get; set; }

        /// <summary>
        /// Represents the database set for the UserToken entity.
        /// </summary>
        public DbSet<UserToken> UserToken { get; set; }

        /// <summary>
        /// Represents the database set for the RoleEntitlement entity.
        /// </summary>
        public DbSet<RoleEntitlement> RoleEntitlement { get; set; }

        /// <summary>
        /// Represents the database set for the Entity entity.
        /// </summary>
        public DbSet<Entity> Entity { get; set; }

        /// <summary>
        /// Represents the database set for the Tenant entity.
        /// </summary>
        public DbSet<Tenant> Tenant { get; set; }

        /// <summary>
        /// Represents the database set for the User entity.
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Represents the database set for the Role entity.
        /// </summary>
        public DbSet<Role> Role { get; set; }

        /// <summary>
        /// Represents the database set for the RemittanceAdvice entity.
        /// </summary>
        public DbSet<RemittanceAdvice> RemittanceAdvice { get; set; }

        /// <summary>
        /// Represents the database set for the Statement entity.
        /// </summary>
        public DbSet<Statement> Statement { get; set; }

        /// <summary>
        /// Represents the database set for the CollectionAgency entity.
        /// </summary>
        public DbSet<CollectionAgency> CollectionAgency { get; set; }

        /// <summary>
        /// Represents the database set for the DunningLetters entity.
        /// </summary>
        public DbSet<DunningLetters> DunningLetters { get; set; }

        /// <summary>
        /// Represents the database set for the WriteOffs entity.
        /// </summary>
        public DbSet<WriteOffs> WriteOffs { get; set; }

        /// <summary>
        /// Represents the database set for the AgingReport entity.
        /// </summary>
        public DbSet<AgingReport> AgingReport { get; set; }

        /// <summary>
        /// Represents the database set for the Claim entity.
        /// </summary>
        public DbSet<Claim> Claim { get; set; }

        /// <summary>
        /// Represents the database set for the ClaimItem entity.
        /// </summary>
        public DbSet<ClaimItem> ClaimItem { get; set; }

        /// <summary>
        /// Represents the database set for the Adjustment entity.
        /// </summary>
        public DbSet<Adjustment> Adjustment { get; set; }

        /// <summary>
        /// Represents the database set for the Preauthorization entity.
        /// </summary>
        public DbSet<Preauthorization> Preauthorization { get; set; }

        /// <summary>
        /// Represents the database set for the DenialReason entity.
        /// </summary>
        public DbSet<DenialReason> DenialReason { get; set; }

        /// <summary>
        /// Represents the database set for the ExplanationOfBenefits entity.
        /// </summary>
        public DbSet<ExplanationOfBenefits> ExplanationOfBenefits { get; set; }

        /// <summary>
        /// Represents the database set for the BillingCycle entity.
        /// </summary>
        public DbSet<BillingCycle> BillingCycle { get; set; }

        /// <summary>
        /// Represents the database set for the VitalSigns entity.
        /// </summary>
        public DbSet<VitalSigns> VitalSigns { get; set; }

        /// <summary>
        /// Represents the database set for the MedicalProviders entity.
        /// </summary>
        public DbSet<MedicalProviders> MedicalProviders { get; set; }

        /// <summary>
        /// Represents the database set for the InsuranceCompanies entity.
        /// </summary>
        public DbSet<InsuranceCompanies> InsuranceCompanies { get; set; }

        /// <summary>
        /// Represents the database set for the MedicalServices entity.
        /// </summary>
        public DbSet<MedicalServices> MedicalServices { get; set; }

        /// <summary>
        /// Represents the database set for the DiagnosisCodes entity.
        /// </summary>
        public DbSet<DiagnosisCodes> DiagnosisCodes { get; set; }

        /// <summary>
        /// Represents the database set for the ProcedureCodes entity.
        /// </summary>
        public DbSet<ProcedureCodes> ProcedureCodes { get; set; }

        /// <summary>
        /// Represents the database set for the BillableItems entity.
        /// </summary>
        public DbSet<BillableItems> BillableItems { get; set; }

        /// <summary>
        /// Represents the database set for the HealthHistory entity.
        /// </summary>
        public DbSet<HealthHistory> HealthHistory { get; set; }

        /// <summary>
        /// Represents the database set for the Allergy entity.
        /// </summary>
        public DbSet<Allergy> Allergy { get; set; }

        /// <summary>
        /// Represents the database set for the Immunization entity.
        /// </summary>
        public DbSet<Immunization> Immunization { get; set; }

        /// <summary>
        /// Represents the database set for the Referral entity.
        /// </summary>
        public DbSet<Referral> Referral { get; set; }

        /// <summary>
        /// Represents the database set for the LabResult entity.
        /// </summary>
        public DbSet<LabResult> LabResult { get; set; }

        /// <summary>
        /// Represents the database set for the Radiology entity.
        /// </summary>
        public DbSet<Radiology> Radiology { get; set; }

        /// <summary>
        /// Represents the database set for the Examination entity.
        /// </summary>
        public DbSet<Examination> Examination { get; set; }

        /// <summary>
        /// Represents the database set for the Doctor entity.
        /// </summary>
        public DbSet<Doctor> Doctor { get; set; }

        /// <summary>
        /// Represents the database set for the Nurse entity.
        /// </summary>
        public DbSet<Nurse> Nurse { get; set; }

        /// <summary>
        /// Represents the database set for the Clinic entity.
        /// </summary>
        public DbSet<Clinic> Clinic { get; set; }

        /// <summary>
        /// Represents the database set for the Specialty entity.
        /// </summary>
        public DbSet<Specialty> Specialty { get; set; }

        /// <summary>
        /// Represents the database set for the Insurance entity.
        /// </summary>
        public DbSet<Insurance> Insurance { get; set; }

        /// <summary>
        /// Represents the database set for the Billing entity.
        /// </summary>
        public DbSet<Billing> Billing { get; set; }

        /// <summary>
        /// Represents the database set for the Payment entity.
        /// </summary>
        public DbSet<Payment> Payment { get; set; }

        /// <summary>
        /// Represents the database set for the Patient entity.
        /// </summary>
        public DbSet<Patient> Patient { get; set; }

        /// <summary>
        /// Represents the database set for the Appointment entity.
        /// </summary>
        public DbSet<Appointment> Appointment { get; set; }

        /// <summary>
        /// Represents the database set for the MedicalRecord entity.
        /// </summary>
        public DbSet<MedicalRecord> MedicalRecord { get; set; }

        /// <summary>
        /// Represents the database set for the Diagnosis entity.
        /// </summary>
        public DbSet<Diagnosis> Diagnosis { get; set; }

        /// <summary>
        /// Represents the database set for the Treatment entity.
        /// </summary>
        public DbSet<Treatment> Treatment { get; set; }

        /// <summary>
        /// Represents the database set for the Prescription entity.
        /// </summary>
        public DbSet<Prescription> Prescription { get; set; }

        /// <summary>
        /// Represents the database set for the Medication entity.
        /// </summary>
        public DbSet<Medication> Medication { get; set; }
    }
}