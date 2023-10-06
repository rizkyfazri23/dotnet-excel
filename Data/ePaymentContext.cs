using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIMDEmployee.Data
{
    public partial class ePaymentContext : DbContext
    {
        public ePaymentContext()
        {
        }

        public ePaymentContext(DbContextOptions<ePaymentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bank> Banks { get; set; } = null!;
        public virtual DbSet<Bank1> Banks1 { get; set; } = null!;
        public virtual DbSet<CategoryExpense> CategoryExpenses { get; set; } = null!;
        public virtual DbSet<CategoryExpense1> CategoryExpenses1 { get; set; } = null!;
        public virtual DbSet<Coa> Coas { get; set; } = null!;
        public virtual DbSet<Coa1> Coas1 { get; set; } = null!;
        public virtual DbSet<CostCenter> CostCenters { get; set; } = null!;
        public virtual DbSet<CostCenter1> CostCenters1 { get; set; } = null!;
        public virtual DbSet<Currency> Currencies { get; set; } = null!;
        public virtual DbSet<Currency1> Currencies1 { get; set; } = null!;
        public virtual DbSet<DebitBank> DebitBanks { get; set; } = null!;
        public virtual DbSet<DebitBank1> DebitBanks1 { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Department1> Departments1 { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Employee1> Employees1 { get; set; } = null!;
        public virtual DbSet<PlanPaymentDate> PlanPaymentDates { get; set; } = null!;
        public virtual DbSet<Pvnumber> Pvnumbers { get; set; } = null!;
        public virtual DbSet<Rpvvendor> Rpvvendors { get; set; } = null!;
        public virtual DbSet<RunningNumber> RunningNumbers { get; set; } = null!;
        public virtual DbSet<TransactionExpense> TransactionExpenses { get; set; } = null!;
        public virtual DbSet<TransactionExpense1> TransactionExpenses1 { get; set; } = null!;
        public virtual DbSet<Whtarticle> Whtarticles { get; set; } = null!;
        public virtual DbSet<Whtarticle1> Whtarticles1 { get; set; } = null!;
        public virtual DbSet<Whttype> Whttypes { get; set; } = null!;
        public virtual DbSet<Whttype1> Whttypes1 { get; set; } = null!;
        public virtual DbSet<WorkflowRole> WorkflowRoles { get; set; } = null!;
        public virtual DbSet<WorkflowRole1> WorkflowRoles1 { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_MasterData_Bank");

                entity.ToTable("Bank", "MasterData");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusWf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StatusWF");

                entity.Property(e => e.SwiftCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bank1>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_Bank");

                entity.ToTable("Bank", "Transactions");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.K2wfprocessInstanceId).HasColumnName("K2WFProcessInstanceId");

                entity.Property(e => e.MdbankRowId).HasColumnName("MDBankRowId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SwiftCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.MdbankRow)
                    .WithMany(p => p.Bank1s)
                    .HasForeignKey(d => d.MdbankRowId)
                    .HasConstraintName("FK_Bank_Bank");
            });

            modelBuilder.Entity<CategoryExpense>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_MasterData_CategoryExpense");

                entity.ToTable("CategoryExpense", "MasterData");

                entity.Property(e => e.CategoryExpense1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CategoryExpense");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ExpenseType)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusWf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StatusWF");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryExpense1>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_CategoryExpense");

                entity.ToTable("CategoryExpense", "Transactions");

                entity.Property(e => e.CategoryExpense)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ExpenseType)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.K2wfprocessInstanceId).HasColumnName("K2WFProcessInstanceId");

                entity.Property(e => e.MdcategoryExpenseRowId).HasColumnName("MDCategoryExpenseRowId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.MdcategoryExpenseRow)
                    .WithMany(p => p.CategoryExpense1s)
                    .HasForeignKey(d => d.MdcategoryExpenseRowId)
                    .HasConstraintName("FK_CategoryExpense_CategoryExpense");
            });

            modelBuilder.Entity<Coa>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_MasterData_COA");

                entity.ToTable("COA", "MasterData");

                entity.Property(e => e.Code)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('([dbo].[GetDefaultModifiedBy]())')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("('True')");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StatusWf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StatusWF");
            });

            modelBuilder.Entity<Coa1>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_COA");

                entity.ToTable("COA", "Transactions");

                entity.Property(e => e.Code)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('([dbo].[GetDefaultModifiedBy]())')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("('True')");

                entity.Property(e => e.K2wfprocessInstanceId).HasColumnName("K2WFProcessInstanceId");

                entity.Property(e => e.MdcoarowId).HasColumnName("MDCOARowId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Mdcoarow)
                    .WithMany(p => p.Coa1s)
                    .HasForeignKey(d => d.MdcoarowId)
                    .HasConstraintName("FK_COA_COA");
            });

            modelBuilder.Entity<CostCenter>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_MasterData_CostCenter");

                entity.ToTable("CostCenter", "MasterData");

                entity.Property(e => e.BusinessUnit)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CostCenterCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CostCenterName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('([dbo].[GetDefaultModifiedBy]())')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpenseType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("('True')");

                entity.Property(e => e.Level1WfroleId).HasColumnName("Level1WFRoleId");

                entity.Property(e => e.Level2WfroleId).HasColumnName("Level2WFRoleId");

                entity.Property(e => e.Level3WfroleId).HasColumnName("Level3WFRoleId");

                entity.Property(e => e.Level4WfroleId).HasColumnName("Level4WFRoleId");

                entity.Property(e => e.Level5WfroleId).HasColumnName("Level5WFRoleId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusWf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StatusWF");

                entity.HasOne(d => d.DepartmentRow)
                    .WithMany(p => p.CostCenters)
                    .HasForeignKey(d => d.DepartmentRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CostCenter_Department");

                entity.HasOne(d => d.Level1Wfrole)
                    .WithMany(p => p.CostCenterLevel1Wfroles)
                    .HasForeignKey(d => d.Level1WfroleId)
                    .HasConstraintName("FK_CostCenter_Level1WFRole");

                entity.HasOne(d => d.Level2Wfrole)
                    .WithMany(p => p.CostCenterLevel2Wfroles)
                    .HasForeignKey(d => d.Level2WfroleId)
                    .HasConstraintName("FK_CostCenter_Level2WFRole");

                entity.HasOne(d => d.Level3Wfrole)
                    .WithMany(p => p.CostCenterLevel3Wfroles)
                    .HasForeignKey(d => d.Level3WfroleId)
                    .HasConstraintName("FK_CostCenter_Level3WFRole");

                entity.HasOne(d => d.Level4Wfrole)
                    .WithMany(p => p.CostCenterLevel4Wfroles)
                    .HasForeignKey(d => d.Level4WfroleId)
                    .HasConstraintName("FK_CostCenter_Level4WFRole");

                entity.HasOne(d => d.Level5Wfrole)
                    .WithMany(p => p.CostCenterLevel5Wfroles)
                    .HasForeignKey(d => d.Level5WfroleId)
                    .HasConstraintName("FK_CostCenter_Level5WFRole");
            });

            modelBuilder.Entity<CostCenter1>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_CostCenter");

                entity.ToTable("CostCenter", "Transactions");

                entity.Property(e => e.CostCenterCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CostCenterName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('([dbo].[GetDefaultModifiedBy]())')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpenseType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("('True')");

                entity.Property(e => e.K2wfprocessInstanceId).HasColumnName("K2WFProcessInstanceId");

                entity.Property(e => e.Level1WfroleId).HasColumnName("Level1WFRoleId");

                entity.Property(e => e.Level2WfroleId).HasColumnName("Level2WFRoleId");

                entity.Property(e => e.Level3WfroleId).HasColumnName("Level3WFRoleId");

                entity.Property(e => e.Level4WfroleId).HasColumnName("Level4WFRoleId");

                entity.Property(e => e.Level5WfroleId).HasColumnName("Level5WFRoleId");

                entity.Property(e => e.MdcostCenterRowId).HasColumnName("MDCostCenterRowId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.DepartmentRow)
                    .WithMany(p => p.CostCenter1s)
                    .HasForeignKey(d => d.DepartmentRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CostCenter_Department");

                entity.HasOne(d => d.Level1Wfrole)
                    .WithMany(p => p.CostCenter1Level1Wfroles)
                    .HasForeignKey(d => d.Level1WfroleId)
                    .HasConstraintName("FK_CostCenter_Level1WFRole");

                entity.HasOne(d => d.Level2Wfrole)
                    .WithMany(p => p.CostCenter1Level2Wfroles)
                    .HasForeignKey(d => d.Level2WfroleId)
                    .HasConstraintName("FK_CostCenter_Level2WFRole");

                entity.HasOne(d => d.Level3Wfrole)
                    .WithMany(p => p.CostCenter1Level3Wfroles)
                    .HasForeignKey(d => d.Level3WfroleId)
                    .HasConstraintName("FK_CostCenter_Level3WFRole");

                entity.HasOne(d => d.Level4Wfrole)
                    .WithMany(p => p.CostCenter1Level4Wfroles)
                    .HasForeignKey(d => d.Level4WfroleId)
                    .HasConstraintName("FK_CostCenter_Level4WFRole");

                entity.HasOne(d => d.Level5Wfrole)
                    .WithMany(p => p.CostCenter1Level5Wfroles)
                    .HasForeignKey(d => d.Level5WfroleId)
                    .HasConstraintName("FK_CostCenter_Level5WFRole");

                entity.HasOne(d => d.MdcostCenterRow)
                    .WithMany(p => p.CostCenter1s)
                    .HasForeignKey(d => d.MdcostCenterRowId)
                    .HasConstraintName("FK_CostCenter_CostCenter");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_MasterData_Currency");

                entity.ToTable("Currency", "MasterData");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('([dbo].[GetDefaultModifiedBy]())')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("('True')");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusWf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StatusWF");
            });

            modelBuilder.Entity<Currency1>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_Currency");

                entity.ToTable("Currency", "Transactions");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('([dbo].[GetDefaultModifiedBy]())')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("('True')");

                entity.Property(e => e.K2wfprocessInstanceId).HasColumnName("K2WFProcessInstanceId");

                entity.Property(e => e.MdcurrencyRowId).HasColumnName("MDCurrencyRowId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.MdcurrencyRow)
                    .WithMany(p => p.Currency1s)
                    .HasForeignKey(d => d.MdcurrencyRowId)
                    .HasConstraintName("FK_Currency_Currency");
            });

            modelBuilder.Entity<DebitBank>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_MasterData_DebitBank");

                entity.ToTable("DebitBank", "MasterData");

                entity.Property(e => e.BankAccountCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccountName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccountNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BankCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusWf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StatusWF");

                entity.HasOne(d => d.BankRow)
                    .WithMany(p => p.DebitBanks)
                    .HasForeignKey(d => d.BankRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DebitBank_Bank");

                entity.HasOne(d => d.CurrencyRow)
                    .WithMany(p => p.DebitBanks)
                    .HasForeignKey(d => d.CurrencyRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DebitBank_Currency");
            });

            modelBuilder.Entity<DebitBank1>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_DebitBank");

                entity.ToTable("DebitBank", "Transactions");

                entity.Property(e => e.BankAccountCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccountName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccountNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BankCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.K2wfprocessInstanceId).HasColumnName("K2WFProcessInstanceId");

                entity.Property(e => e.MddebitBankRowId).HasColumnName("MDDebitBankRowId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.BankRow)
                    .WithMany(p => p.DebitBank1s)
                    .HasForeignKey(d => d.BankRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DebitBank_Bank");

                entity.HasOne(d => d.CurrencyRow)
                    .WithMany(p => p.DebitBank1s)
                    .HasForeignKey(d => d.CurrencyRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DebitBank_Currency");

                entity.HasOne(d => d.MddebitBankRow)
                    .WithMany(p => p.DebitBank1s)
                    .HasForeignKey(d => d.MddebitBankRowId)
                    .HasConstraintName("FK_DebitBank_DebitBank");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_MasterData_Departments");

                entity.ToTable("Department", "MasterData");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('([dbo].[GetDefaultModifiedBy]())')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("('True')");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusWf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StatusWF");
            });

            modelBuilder.Entity<Department1>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_Departments");

                entity.ToTable("Department", "Transactions");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('([dbo].[GetDefaultModifiedBy]())')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("('True')");

                entity.Property(e => e.K2wfprocessInstanceId).HasColumnName("K2WFProcessInstanceId");

                entity.Property(e => e.MddepartmentRowId).HasColumnName("MDDepartmentRowId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.MddepartmentRow)
                    .WithMany(p => p.Department1s)
                    .HasForeignKey(d => d.MddepartmentRowId)
                    .HasConstraintName("FK_Department_Department");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_MasterData.Employee");

                entity.ToTable("Employee", "MasterData");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusWf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StatusWF");

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.BankRow)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.BankRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Bank");

                entity.HasOne(d => d.CostCenterRow)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CostCenterRowId)
                    .HasConstraintName("FK_Employee_CostCenter");

                entity.HasOne(d => d.DepartmentRow)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");
            });

            modelBuilder.Entity<Employee1>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_Employee");

                entity.ToTable("Employee", "Transactions");

                entity.Property(e => e.AccountName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Grade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.K2wfprocessInstanceId).HasColumnName("K2WFProcessInstanceId");

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.MdemployeeRowId).HasColumnName("MDEmployeeRowId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.BankRow)
                    .WithMany(p => p.Employee1s)
                    .HasForeignKey(d => d.BankRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Bank");

                entity.HasOne(d => d.CostCenterRow)
                    .WithMany(p => p.Employee1s)
                    .HasForeignKey(d => d.CostCenterRowId)
                    .HasConstraintName("FK_Employee_CostCenter");

                entity.HasOne(d => d.DepartmentRow)
                    .WithMany(p => p.Employee1s)
                    .HasForeignKey(d => d.DepartmentRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");

                entity.HasOne(d => d.MdemployeeRow)
                    .WithMany(p => p.Employee1s)
                    .HasForeignKey(d => d.MdemployeeRowId)
                    .HasConstraintName("FK_Employee_Employee");
            });

            modelBuilder.Entity<PlanPaymentDate>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_PlanPaymentDate");

                entity.ToTable("PlanPaymentDate", "Transactions");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DateTo).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pvnumber>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_PVNumber");

                entity.ToTable("PVNumber", "Transactions");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DocumentId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.PartyId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pvnumber1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PVNumber");

                entity.Property(e => e.RpvrowId).HasColumnName("RPVRowId");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionReferenceNo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.HasOne(d => d.Rpvrow)
                    .WithMany(p => p.Pvnumbers)
                    .HasForeignKey(d => d.RpvrowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PVNumber_RPVVendor");
            });

            modelBuilder.Entity<Rpvvendor>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_RPVVendor");

                entity.ToTable("RPVVendor", "Transactions");

                entity.Property(e => e.BankDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CoddocAttachmentRowId).HasColumnName("CODDocAttachmentRowId");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GrossAmount).HasColumnType("decimal(22, 4)");

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceDueDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsCod).HasColumnName("IsCOD");

                entity.Property(e => e.IsPkp).HasColumnName("IsPKP");

                entity.Property(e => e.IsSkb).HasColumnName("IsSKB");

                entity.Property(e => e.K2wfprocessInstanceId).HasColumnName("K2WFProcessInstanceId");

                entity.Property(e => e.MakerDepartmentName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MakerName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.NetAmount).HasColumnType("decimal(22, 4)");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.RequestPaymentDate).HasColumnType("datetime");

                entity.Property(e => e.RequestPvnumber)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("RequestPVNumber");

                entity.Property(e => e.RequestorName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RevisionNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SkbdocAttachmentRowId).HasColumnName("SKBDocAttachmentRowId");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Vatamount)
                    .HasColumnType("decimal(22, 4)")
                    .HasColumnName("VATAmount");

                entity.Property(e => e.Whtamount)
                    .HasColumnType("decimal(22, 4)")
                    .HasColumnName("WHTAmount");

                entity.Property(e => e.Whtrate)
                    .HasColumnType("decimal(22, 4)")
                    .HasColumnName("WHTRate");

                entity.HasOne(d => d.CurrencyRow)
                    .WithMany(p => p.Rpvvendors)
                    .HasForeignKey(d => d.CurrencyRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RPVVendor_Currency");

                entity.HasOne(d => d.MakerEmployeeRow)
                    .WithMany(p => p.RpvvendorMakerEmployeeRows)
                    .HasForeignKey(d => d.MakerEmployeeRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RPVVendorMaker_Employee");

                entity.HasOne(d => d.RequestorEmployeeRow)
                    .WithMany(p => p.RpvvendorRequestorEmployeeRows)
                    .HasForeignKey(d => d.RequestorEmployeeRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RPVVendorRequestor_Employee");
            });

            modelBuilder.Entity<RunningNumber>(entity =>
            {
                entity.HasKey(e => e.KeyUsed)
                    .HasName("PK_Transactions_RunningNumber");

                entity.ToTable("RunningNumber", "Transactions");

                entity.Property(e => e.KeyUsed)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TransactionExpense>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_MasterData_TransactionExpense");

                entity.ToTable("TransactionExpense", "MasterData");

                entity.Property(e => e.CoarowId).HasColumnName("COARowId");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusWf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StatusWF");

                entity.Property(e => e.TransactionExpense1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TransactionExpense");

                entity.HasOne(d => d.CategoryExpenseRow)
                    .WithMany(p => p.TransactionExpenses)
                    .HasForeignKey(d => d.CategoryExpenseRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionExpense_CategoryExpense");

                entity.HasOne(d => d.Coarow)
                    .WithMany(p => p.TransactionExpenses)
                    .HasForeignKey(d => d.CoarowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionExpense_COA");
            });

            modelBuilder.Entity<TransactionExpense1>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_TransactionExpense");

                entity.ToTable("TransactionExpense", "Transactions");

                entity.Property(e => e.CoarowId).HasColumnName("COARowId");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.K2wfprocessInstanceId).HasColumnName("K2WFProcessInstanceId");

                entity.Property(e => e.MdtransactionExpenseRowId).HasColumnName("MDTransactionExpenseRowId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionExpense)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryExpenseRow)
                    .WithMany(p => p.TransactionExpense1s)
                    .HasForeignKey(d => d.CategoryExpenseRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionExpense_CategoryExpense");

                entity.HasOne(d => d.Coarow)
                    .WithMany(p => p.TransactionExpense1s)
                    .HasForeignKey(d => d.CoarowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionExpense_COA");

                entity.HasOne(d => d.MdtransactionExpenseRow)
                    .WithMany(p => p.TransactionExpense1s)
                    .HasForeignKey(d => d.MdtransactionExpenseRowId)
                    .HasConstraintName("FK_TransactionExpense_TransactionExpense");
            });

            modelBuilder.Entity<Whtarticle>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_MasterData_WHTArticle");

                entity.ToTable("WHTArticle", "MasterData");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.StatusWf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StatusWF");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Whtarticle1>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_WHTArticle");

                entity.ToTable("WHTArticle", "Transactions");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.K2wfprocessInstanceId).HasColumnName("K2WFProcessInstanceId");

                entity.Property(e => e.MdwhtarticleRowId).HasColumnName("MDWHTArticleRowId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.MdwhtarticleRow)
                    .WithMany(p => p.Whtarticle1s)
                    .HasForeignKey(d => d.MdwhtarticleRowId)
                    .HasConstraintName("FK_WHTArticle_WHTArticle");
            });

            modelBuilder.Entity<Whttype>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_MasterData_WHTType");

                entity.ToTable("WHTType", "MasterData");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.RateWithOutTaxId).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.RateWithTaxId).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.StatusWf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StatusWF");

                entity.Property(e => e.SubType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WhtarticleRowId).HasColumnName("WHTArticleRowId");

                entity.HasOne(d => d.WhtarticleRow)
                    .WithMany(p => p.Whttypes)
                    .HasForeignKey(d => d.WhtarticleRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WHTType_WHTArticle");
            });

            modelBuilder.Entity<Whttype1>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_Transactions_WHTType");

                entity.ToTable("WHTType", "Transactions");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.K2wfprocessInstanceId).HasColumnName("K2WFProcessInstanceId");

                entity.Property(e => e.MdwhttypeRowId).HasColumnName("MDWHTTypeRowId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.RateWithOutTaxId).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.RateWithTaxId).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SubType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WhtarticleRowId).HasColumnName("WHTArticleRowId");

                entity.HasOne(d => d.MdwhttypeRow)
                    .WithMany(p => p.Whttype1s)
                    .HasForeignKey(d => d.MdwhttypeRowId)
                    .HasConstraintName("FK_WHTType_WHTType");

                entity.HasOne(d => d.WhtarticleRow)
                    .WithMany(p => p.Whttype1s)
                    .HasForeignKey(d => d.WhtarticleRowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WHTType_WHTArticle");
            });

            modelBuilder.Entity<WorkflowRole>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_MasterData_WorkflowRole");

                entity.ToTable("WorkflowRole", "MasterData");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StatusWf)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StatusWF");
            });

            modelBuilder.Entity<WorkflowRole1>(entity =>
            {
                entity.HasKey(e => e.RowId);

                entity.ToTable("WorkflowRole", "Transactions");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.K2wfprocessInstanceId).HasColumnName("K2WFProcessInstanceId");

                entity.Property(e => e.MdwfroleRowId).HasColumnName("MDWFRoleRowId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.MdwfroleRow)
                    .WithMany(p => p.WorkflowRole1s)
                    .HasForeignKey(d => d.MdwfroleRowId)
                    .HasConstraintName("FK_WorkflowRole_WorkflowRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
