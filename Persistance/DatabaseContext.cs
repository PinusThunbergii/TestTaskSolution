using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using Persistence.Entities.CarOptions;

namespace Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cars
            modelBuilder.Entity<Car>()
                .Property(c => c.ModelCode)
                .IsRequired()
                .HasColumnType("nvarchar(10)").IsUnicode();
            modelBuilder.Entity<Car>()
                .Property(c => c.CarComplectationsCodes)
                .IsRequired()
                .HasColumnType("nvarchar(100)").IsUnicode();

            modelBuilder.Entity<Car>()
                .HasIndex(c => new { c.ModelName, c.ModelCode })
                .IsUnique();

            //CarComplectations
            modelBuilder.Entity<CarComplectation>()
                .Property(cc => cc.CarCompectationCode)
                .HasColumnType("nvarchar(50)").IsUnicode()
                .IsRequired();


            modelBuilder.Entity<CarComplectation>()
                .HasIndex(cc => cc.CarCompectationCode)
                .IsUnique();
            modelBuilder.Entity<CarComplectation>()
                .HasOne(cc => cc.Destination1)
                .WithMany(d => d.CarComplectations1)
                .IsRequired();

            modelBuilder.Entity<CarComplectation>()
                .HasOne(cc => cc.Destination2)
                .WithMany(d => d.CarComplectations2)
                .IsRequired(false);

            //CarDetailGroup
            modelBuilder.Entity<CarDetailGroup>()
                .Property(cdg => cdg.Name)
                .IsRequired()
                .HasColumnType("nvarchar(200)").IsUnicode();

            //CarDetailSubGroup
            modelBuilder.Entity<CarDetailSubGroup>()
                .Property(cdsg => cdsg.Name)
                .IsRequired()
                .HasColumnType("nvarchar(400)").IsUnicode();

            //CarDetail
            modelBuilder.Entity<CarDetail>()
                .Property(cd => cd.CarDetailCode)
                .IsRequired()
                .HasColumnType("nvarchar(30)").IsUnicode();

            modelBuilder.Entity<CarDetail>()
                .Property(cd => cd.TreeCode)
                .IsRequired()
                .HasColumnType("nvarchar(10)").IsUnicode();

            modelBuilder.Entity<CarDetail>()
                .Property(cd => cd.TreeName)
                .IsRequired()
                .HasColumnType("nvarchar(300)").IsUnicode();

            modelBuilder.Entity<CarDetail>()
                .Property(cd => cd.ReplacmentCode)
                .IsRequired(false)
                .HasColumnType("nvarchar(30)").IsUnicode();

            modelBuilder.Entity<CarDetail>()
                .Property(cd => cd.ImageGUID)
                .IsRequired()
                .HasColumnType("nvarchar(36)").IsUnicode();

            //Body
            modelBuilder.Entity<Body>()
                .Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .IsUnicode()
                .IsRequired();

            //Destination
            modelBuilder.Entity<Destination>()
                .Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .IsUnicode()
                .IsRequired();

            //DriversPosition
            modelBuilder.Entity<DriversPosition>()
                .Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .IsUnicode()
                .IsRequired();

            //Engine
            modelBuilder.Entity<Engine>()
                .Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .IsUnicode()
                .IsRequired();

            //GearShiftType
            modelBuilder.Entity<GearShiftType>()
                .Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .IsUnicode()
                .IsRequired();

            //Grade
            modelBuilder.Entity<Grade>()
                .Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .IsUnicode()
                .IsRequired();

            //NoOfDoors
            modelBuilder.Entity<NoOfDoors>()
                .Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .IsUnicode()
                .IsRequired();

            //Transmission
            modelBuilder.Entity<Transmission>()
                .Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .IsUnicode()
                .IsRequired();
        }

        public DbSet<Car> Cars => Set<Car>();
        public DbSet<CarComplectation> CarComplectations => Set<CarComplectation>();
        public DbSet<CarDetailGroup> CarDetailGroups => Set<CarDetailGroup>();
        public DbSet<CarDetailSubGroup> CarDetailSubGroups => Set<CarDetailSubGroup>();
        public DbSet<CarDetail> CarDetails => Set<CarDetail>();
        public DbSet<Body> Bodies => Set<Body>();
        public DbSet<Destination> Destinations => Set<Destination>();
        public DbSet<DriversPosition> DriversPositions => Set<DriversPosition>();
        public DbSet<Engine> Engines => Set<Engine>();
        public DbSet<GearShiftType> GearShiftTypes => Set<GearShiftType>();
        public DbSet<Grade> Grades => Set<Grade>();
        public DbSet<NoOfDoors> NoOfDoors => Set<NoOfDoors>();
        public DbSet<Transmission> Transmissions => Set<Transmission>();
    }
}
