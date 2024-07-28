namespace THD.ERP.DataAccessor.Entities;

public class Attendance
{
    public long AttendanceId { get; set; }
    
    public long EmployeeId { get; set; }
    
    public DateTime Date { get; set; }
    
    public TimeSpan? TimeIn { get; set; }
    
    public TimeSpan? TimeOut { get; set; }
    
    // Navigation property
    public virtual Employee Employee { get; set; } = null!;
}