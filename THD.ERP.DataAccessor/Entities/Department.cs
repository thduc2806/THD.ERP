namespace THD.ERP.DataAccessor.Entities;

public class Department
{
    public long DepartmentId { get; set; }
    
    public string DepartmentName { get; set; } = null!;
    
    // Navigation property
    public virtual List<Employee> Employees { get; set; } = null!;
}