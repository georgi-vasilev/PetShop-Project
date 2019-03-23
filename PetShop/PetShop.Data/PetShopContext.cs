using Microsoft.EntityFrameworkCore;
using PetShop.Data.Models;

namespace PetShop.Data
{
    public partial class PetShopContext : DbContext
    {
        public PetShopContext()
        {
        }

        public PetShopContext(DbContextOptions<PetShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Cage> Cages { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.ConnectionString)
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("Animals", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Breed)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CageId).HasColumnName("CageID");

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.FoodId).HasColumnName("FoodID");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Specie)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cage)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.CageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_animals_cages");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_animals_food");
            });

            modelBuilder.Entity<Cage>(entity =>
            {
                entity.ToTable("Cages", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CageType)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Clients", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClientAddress)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasColumnName("SSN")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JobType)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasColumnName("SSN")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FoodType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.ToTable("Sales", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnimalId).HasColumnName("AnimalID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.SaleDate).HasColumnType("date");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sales_animals");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sales_clients");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sales_employees");
            });
        }
    }
}
