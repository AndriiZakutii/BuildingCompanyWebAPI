using BuildingCompanyModel;
using Microsoft.EntityFrameworkCore;

namespace BuildingCompanyWebAPI
{
    public class BuildingCompanyContext : DbContext
    {
        public BuildingCompanyContext(DbContextOptions<BuildingCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectType> ProjectTypes { get; set; }
        public virtual DbSet<Investor> Investors { get; set; }
        public virtual DbSet<Investment> Investments { get; set; }
        public virtual DbSet<ProjectStage> ProjectStages { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
    }
}
