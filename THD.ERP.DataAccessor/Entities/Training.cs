namespace THD.ERP.DataAccessor.Entities;

public class Training
{
    public long TrainingId { get; set; }
    
    public string TrainingName { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    // Navigation property
    public virtual List<EmployeeTraining> EmployeeTrainings { get; set; } = null!;
}