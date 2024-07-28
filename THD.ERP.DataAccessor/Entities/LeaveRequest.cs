namespace THD.ERP.DataAccessor.Entities;

public class LeaveRequest
{
    public long LeaveRequestId { get; set; }
    
    public long EmployeeId { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public string LeaveType { get; set; } = null!;

    public string Status { get; set; } = null!;
    
    // Navigation property
    public virtual Employee Employee { get; set; } = null!;
}