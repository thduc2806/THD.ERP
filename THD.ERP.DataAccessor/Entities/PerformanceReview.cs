using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace THD.ERP.DataAccessor.Entities;

public class PerformanceReview
{
    [Key]
    public long ReviewId { get; set; }
    
    public long EmployeeId { get; set; }
    
    public DateTime ReviewDate { get; set; }
    
    public long? ReviewerId { get; set; }
    
    public int Rating { get; set; }
    
    public string Comments { get; set; } = null!;
    
    // Navigation properties
    public virtual Employee Employee { get; set; } = null!;

    public virtual Employee Reviewer { get; set; } = null!;
}