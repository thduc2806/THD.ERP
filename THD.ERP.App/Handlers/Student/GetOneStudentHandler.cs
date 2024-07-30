using AutoMapper;
using MediatR;
using THD.ERP.App.Commands.Student;
using THD.ERP.App.Models;
using THD.ERP.Infrastructure.Repositories.Students;

namespace THD.ERP.App.Handlers.Student
{
    public class GetOneStudentHandler : IRequestHandler<GetOneStudentCommand, StudentModel>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetOneStudentHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentModel> Handle(GetOneStudentCommand request, CancellationToken cancellationToken)
        {
            string sql = "SELECT * FROM Studens WHERE Id = @Id";
            var result = await _studentRepository.GetByIdAsync(sql, new {Id = request.Id});
            return _mapper.Map<StudentModel>(result);
        }
    }
}
