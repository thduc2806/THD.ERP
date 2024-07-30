using AutoMapper;
using MediatR;
using THD.ERP.App.Commands.Student;
using THD.ERP.App.Models;
using THD.ERP.Infrastructure.Repositories.Students;

namespace THD.ERP.App.Handlers.Student
{
    public class StudentHandler : IRequestHandler<StudentCommand, List<StudentModel>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentModel>> Handle(StudentCommand request, CancellationToken cancellationToken)
        {
            string sql = "SELECT * FROM Studens";
            var result = await _studentRepository.GetAllAsync(sql);
            return _mapper.Map<List<StudentModel>>(result);
        }
    }
}
