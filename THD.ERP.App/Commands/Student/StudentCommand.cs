using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THD.ERP.App.Models;

namespace THD.ERP.App.Commands.Student
{
    public class StudentCommand : IRequest<List<StudentModel>>
    {
    }
}
