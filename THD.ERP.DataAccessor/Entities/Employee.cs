using Microsoft.AspNetCore.Identity;

namespace THD.ERP.DataAccessor.Entities;

public class Employee : IdentityUser<long>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }
    
    public string Position { get; set; } = null!;

    public long? DepartmentId { get; set; }
    
    public DateTime DateHired { get; set; }
    
    public decimal Salary { get; set; }
    
    public long? ManagerId { get; set; }
    
    public string? RefreshToken { get; set; }
    
    public DateTime? RefreshTokenExpiryTime { get; set; }
    
    // Navigation properties
    public virtual Department Department { get; set; } = null!;

    public virtual List<Attendance> Attendances { get; set; } = null!;

    public virtual List<LeaveRequest> LeaveRequests { get; set; } = null!;

    public virtual List<Payroll> Payrolls { get; set; } = null!;

    public virtual List<EmployeeTraining> EmployeeTrainings { get; set; } = null!;

    public virtual List<PerformanceReview> PerformanceReviews { get; set; } = null!;
}