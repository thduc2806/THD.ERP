using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THD.ERP.App.Commands.Student;
using THD.ERP.Infrastructure.Repositories.Students;

namespace THD.ERP.App.Handlers.Student
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            string sql = "INSERT INTO Users (FirstName, LastName, DOB, Address, Gender) VALUES (@FirstName, @LastName, @DOB, @Address, @Gender)";
            var result = await _studentRepository.ExecuteAsync(sql, request);
            return result;
        }
    }
}
