namespace efAdventures.Program.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using EntityConfigurations;
    using Model;
    using Microsoft.EntityFrameworkCore.Design;

    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CourseEntityTypeConfiguration());
            builder.ApplyConfiguration(new StudentEntityTypeConfiguration());
        }
    }

    public class SchoolContextDesignFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        
        public SchoolContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>().UseInMemoryDatabase("InMemoryDB");//UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
            return new SchoolContext(optionsBuilder.Options);
        }
    }
}