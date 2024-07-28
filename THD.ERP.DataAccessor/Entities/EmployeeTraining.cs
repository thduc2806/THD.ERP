namespace THD.ERP.DataAccessor.Entities;

public class EmployeeTraining
{
    public long EmployeeTrainingId { get; set; }
    
    public long EmployeeId { get; set; }
    
    public long TrainingId { get; set; }
    
    // Navigation properties
    public virtual Employee Employee { get; set; } = null!;
    
    public virtual Training Training { get; set; } = null!;
    
}