using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THD.ERP.DataAccessor.Data;
using THD.ERP.DataAccessor.Entities;

namespace THD.ERP.Infrastructure.Repositories.Departments
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(HRMDbContext context) : base(context) { }
    }
}
