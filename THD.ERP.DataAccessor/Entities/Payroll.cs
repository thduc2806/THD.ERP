namespace THD.ERP.DataAccessor.Entities;

public class Payroll
{
    public long PayrollId { get; set; }
    
    public long EmployeeId { get; set; }
    
    public DateTime PayPeriod { get; set; }
    
    public decimal GrossSalary { get; set; }
    
    public decimal NetSalary { get; set; }
    
    public decimal Deductions { get; set; }
    
    public decimal? Bonuses { get; set; }

    // Navigation property
    public virtual Employee Employee { get; set; } = null!;
}