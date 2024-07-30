using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THD.ERP.DataAccessor.Data;
using THD.ERP.DataAccessor.Entities;

namespace THD.ERP.Infrastructure.Repositories.Students
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(IDbConnection connection) : base(connection) 
        {

        }
    }
}
