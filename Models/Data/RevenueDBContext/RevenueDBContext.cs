using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RevenueApp.Models.Data.ViewModel;

#nullable disable

namespace RevenueApp.Models.Data.RevenueDBContext
{
    public partial class RevenueDBContext :IdentityDbContext<ApplicationUser>
    {
        public RevenueDBContext()
        {
        }

        public RevenueDBContext(DbContextOptions<RevenueDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assembly> Assemblies { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<BusinessBill> BusinessBills { get; set; }
        public virtual DbSet<BusinessCategory> BusinessCategories { get; set; }
        public virtual DbSet<BusinessDailyPayment> BusinessDailyPayments { get; set; }
        public virtual DbSet<BusinessRate> BusinessRates { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<HouseBill> HouseBills { get; set; }
        public virtual DbSet<HouseCategory> HouseCategories { get; set; }
        public virtual DbSet<HouseDailyPayment> HouseDailyPayments { get; set; }
        public virtual DbSet<HouseRate> HouseRates { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<OfficeRank> OfficeRanks { get; set; }
        public virtual DbSet<OfficerAdmin> OfficerAdmins { get; set; }
        public virtual DbSet<Relation> Relations { get; set; }
        public virtual DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=Conn");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            //copy this code here
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .IsClustered(false);
                entity.ToTable(name: "Users");
            });
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .IsClustered(false);
                entity.ToTable(name: "Role");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId })
                   .IsClustered(false);
                entity.ToTable("UserRoles");
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .IsClustered(false);
                entity.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => e.LoginProvider)
                   .IsClustered(false);
                entity.ToTable("UserLogins");

            });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.HasKey(e => e.Id)
                   .IsClustered(false);
                entity.ToTable("RoleClaims");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(e => e.LoginProvider)
                   .IsClustered(false);
                entity.ToTable("UserTokens");
            });

            //ends here





            modelBuilder.Entity<Assembly>(entity =>
            {
                entity.HasKey(e => e.AssemblyId)
                    .IsClustered(false);

                entity.ToTable("Assembly");

                entity.Property(e => e.AssemblyId).HasColumnName("AssemblyID");

                entity.Property(e => e.AssemblyName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasKey(e => e.BusId)
                    .IsClustered(false);

                entity.ToTable("Business");

                entity.Property(e => e.BusId).HasColumnName("BusID");

                entity.Property(e => e.BusBlockNumber)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.BusCatId).HasColumnName("BusCatID");

                entity.Property(e => e.BusDigitalAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BusLocation)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.BusName).HasMaxLength(200);

                entity.Property(e => e.BusRegDate).HasColumnType("date");

                entity.Property(e => e.BusTelNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.BusCat)
                    .WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.BusCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessCategory_Business");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Businesses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Business");
            });

            modelBuilder.Entity<BusinessBill>(entity =>
            {
                entity.HasKey(e => e.BusBillNumber)
                    .IsClustered(false);

                entity.ToTable("BusinessBill");

                entity.Property(e => e.BusArrears)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BusBillDate).HasColumnType("date");

                entity.Property(e => e.BusCurrentBill)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BusId).HasColumnName("BusID");

                entity.Property(e => e.BusPrevPayment)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BusRateId).HasColumnName("BusRateID");

                entity.Property(e => e.BusTotalAmtDue)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.YearBill)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.BusinessBills)
                    .HasForeignKey(d => d.BusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Business_BusinessBill");

                entity.HasOne(d => d.BusRate)
                    .WithMany(p => p.BusinessBills)
                    .HasForeignKey(d => d.BusRateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessRate_BusinessBill");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BusinessBills)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_BusinessBill");
            });

            modelBuilder.Entity<BusinessCategory>(entity =>
            {
                entity.HasKey(e => e.BusCatId)
                    .IsClustered(false);

                entity.ToTable("BusinessCategory");

                entity.Property(e => e.BusCatId).HasColumnName("BusCatID");

                entity.Property(e => e.BusCatName)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BusinessDailyPayment>(entity =>
            {
                entity.HasKey(e => e.BusPaymentId)
                    .IsClustered(false);

                entity.ToTable("BusinessDailyPayment");

                entity.Property(e => e.BusPaymentId).HasColumnName("BusPaymentID");

                entity.Property(e => e.BusAmount)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.BusId).HasColumnName("BusID");

                entity.Property(e => e.BusPaymentDate).HasColumnType("date");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.BusBillNumberNavigation)
                    .WithMany(p => p.BusinessDailyPayments)
                    .HasForeignKey(d => d.BusBillNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessDailyPayment_BusinessBill");

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.BusinessDailyPayments)
                    .HasForeignKey(d => d.BusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Business_BusinessDailyPayment");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BusinessDailyPayments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_BusinessDailyPayment");
            });

            modelBuilder.Entity<BusinessRate>(entity =>
            {
                entity.HasKey(e => e.BusRateId)
                    .IsClustered(false);

                entity.ToTable("BusinessRate");

                entity.Property(e => e.BusRateId).HasColumnName("BusRateID");

                entity.Property(e => e.BusCatId).HasColumnName("BusCatID");

                entity.Property(e => e.BusRate)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.BusCat)
                    .WithMany(p => p.BusinessRates)
                    .HasForeignKey(d => d.BusCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BusinessCategory_BusinessRate");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .IsClustered(false);

                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerContact)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustomerDigitalAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerDoB).HasColumnType("date");

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerFname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CustomerFName");

                entity.Property(e => e.CustomerLname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CustomerLName");

                entity.Property(e => e.CustomerNationality)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerNextOfKin)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerNextOfKinContact)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustomerResidentialAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerSsn)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CustomerSSN");

                entity.Property(e => e.CustomerTinNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.GhanaCardNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RelationId).HasColumnName("RelationID");

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gender_Customer");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Image_Customer");

                entity.HasOne(d => d.Relation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.RelationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Relation_Customer");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Title_Customer");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.GenderId)
                    .IsClustered(false);

                entity.ToTable("Gender");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.GenderType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.HasKey(e => e.HseId)
                    .IsClustered(false);

                entity.ToTable("House");

                entity.Property(e => e.HseId).HasColumnName("HseID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.HseBlockNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HseCatId).HasColumnName("HseCatID");

                entity.Property(e => e.HseDigitalAddress)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.HseLocation)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.HseName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HseNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HseRegDate).HasColumnType("date");

                entity.Property(e => e.HseTelNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_House");

                entity.HasOne(d => d.HseCat)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.HseCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HouseCategory_House");
            });

            modelBuilder.Entity<HouseBill>(entity =>
            {
                entity.HasKey(e => e.HseBillNumber)
                    .IsClustered(false);

                entity.ToTable("HouseBill");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.HseArrears)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HseBillDate).HasColumnType("date");

                entity.Property(e => e.HseCurrentBill)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HseId).HasColumnName("HseID");

                entity.Property(e => e.HsePrevPayment)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HseRateId).HasColumnName("HseRateID");

                entity.Property(e => e.HseTotalAmtDue)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.YearBill)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.HouseBills)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_HouseBill");

                entity.HasOne(d => d.Hse)
                    .WithMany(p => p.HouseBills)
                    .HasForeignKey(d => d.HseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_House_HouseBill");

                entity.HasOne(d => d.HseRate)
                    .WithMany(p => p.HouseBills)
                    .HasForeignKey(d => d.HseRateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HouseRate_HouseBill");
            });

            modelBuilder.Entity<HouseCategory>(entity =>
            {
                entity.HasKey(e => e.HseCatId)
                    .IsClustered(false);

                entity.ToTable("HouseCategory");

                entity.Property(e => e.HseCatId).HasColumnName("HseCatID");

                entity.Property(e => e.HseCatName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HouseDailyPayment>(entity =>
            {
                entity.HasKey(e => e.HsePaymentId)
                    .IsClustered(false);

                entity.ToTable("HouseDailyPayment");

                entity.Property(e => e.HsePaymentId).HasColumnName("HsePaymentID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.HseAmount)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.HseId).HasColumnName("HseID");

                entity.Property(e => e.HsePaymentDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.HouseDailyPayments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_HouseDailyPayment");

                entity.HasOne(d => d.Hse)
                    .WithMany(p => p.HouseDailyPayments)
                    .HasForeignKey(d => d.HseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_House_HouseDailyPayment");
            });

            modelBuilder.Entity<HouseRate>(entity =>
            {
                entity.HasKey(e => e.HseRateId)
                    .IsClustered(false);

                entity.ToTable("HouseRate");

                entity.Property(e => e.HseRateId).HasColumnName("HseRateID");

                entity.Property(e => e.HseCatId).HasColumnName("HseCatID");

                entity.Property(e => e.HseRate)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.HseCat)
                    .WithMany(p => p.HouseRates)
                    .HasForeignKey(d => d.HseCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HouseCategory_HouseRate");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .IsClustered(false);

                entity.ToTable("Image");

                entity.Property(e => e.Photo).IsRequired();
            });

            modelBuilder.Entity<OfficeRank>(entity =>
            {
                entity.HasKey(e => e.RankId)
                    .IsClustered(false);

                entity.ToTable("OfficeRank");

                entity.Property(e => e.RankId).HasColumnName("RankID");

                entity.Property(e => e.RankName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<OfficerAdmin>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .IsClustered(false);

                entity.ToTable("OfficerAdmin");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.AssemblyId).HasColumnName("AssemblyID");

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.OfficerContact)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.OfficerDigitalAddress)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.OfficerDoB).HasColumnType("date");

                entity.Property(e => e.OfficerEmail)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.OfficerFname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("OfficerFName");

                entity.Property(e => e.OfficerLname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("OfficerLName");

                entity.Property(e => e.OfficerNextOfKin)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OfficerNextOfKinContact)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.OfficerResidentialAddress)
                    .IsRequired()
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.RankId).HasColumnName("RankID");

                entity.Property(e => e.RelationId).HasColumnName("RelationID");

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.HasOne(d => d.Assembly)
                    .WithMany(p => p.OfficerAdmins)
                    .HasForeignKey(d => d.AssemblyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assembly_OfficerAdmin");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.OfficerAdmins)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gender_OfficerAdmin");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.OfficerAdmins)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Image_OfficerAdmin");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.OfficerAdmins)
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfficeRank_OfficerAdmin");

                entity.HasOne(d => d.Relation)
                    .WithMany(p => p.OfficerAdmins)
                    .HasForeignKey(d => d.RelationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Relation_OfficerAdmin");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.OfficerAdmins)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Title_OfficerAdmin");
            });

            modelBuilder.Entity<Relation>(entity =>
            {
                entity.HasKey(e => e.RelationId)
                    .IsClustered(false);

                entity.ToTable("Relation");

                entity.Property(e => e.RelationId).HasColumnName("RelationID");

                entity.Property(e => e.RelationType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.HasKey(e => e.TitleId)
                    .IsClustered(false);

                entity.ToTable("Title");

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.Property(e => e.TitleName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<RevenueApp.Models.Data.ViewModel.AccountViewModel> AccountViewModel { get; set; }

        public DbSet<RevenueApp.Models.Data.ViewModel.LoginViewModel> LoginViewModel { get; set; }

        public DbSet<RevenueApp.Models.Data.ViewModel.TitleViewModel> TitleViewModel { get; set; }

        public DbSet<RevenueApp.Models.Data.ViewModel.OfficerAdminViewModel> OfficerAdminViewModel { get; set; }

        public DbSet<RevenueApp.Models.Data.ViewModel.HouseDailyPaymentViewModel> HouseDailyPaymentViewModel { get; set; }

     
    }
}
