using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using THD.ERP.DataAccessor.Entities;

namespace THD.ERP.DataAccessor.Data;

public class HRMDbContext : IdentityDbContext<Employee, ApplicationRole, long>
{
    public HRMDbContext(DbContextOptions<HRMDbContext> options) : base(options)
    {
    }
    
    public DbSet<Department> Departments { get; set; }
    
    public DbSet<Attendance> Attendances { get; set; }
    
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    
    public DbSet<Payroll> Payrolls { get; set; }
    
    public DbSet<Training> Trainings { get; set; }
    
    public DbSet<EmployeeTraining> EmployeeTrainings { get; set; }
    
    public DbSet<PerformanceReview> PerformanceReviews { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>(e => e.ToTable(name: "Employees"));
        modelBuilder.Entity<ApplicationRole>(e => e.ToTable(name: "Roles"));
        modelBuilder.Entity<Employee>()
            .HasOne(u => u.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(u => u.DepartmentId);
        
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Attendances)
            .WithOne(a => a.Employee)
            .HasForeignKey(a => a.EmployeeId);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.LeaveRequests)
            .WithOne(lr => lr.Employee)
            .HasForeignKey(lr => lr.EmployeeId);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Payrolls)
            .WithOne(p => p.Employee)
            .HasForeignKey(p => p.EmployeeId);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.EmployeeTrainings)
            .WithOne(et => et.Employee)
            .HasForeignKey(et => et.EmployeeId);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.PerformanceReviews)
            .WithOne(pr => pr.Employee)
            .HasForeignKey(pr => pr.EmployeeId);
    }
}