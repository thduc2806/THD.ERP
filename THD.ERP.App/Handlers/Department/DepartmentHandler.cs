using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THD.ERP.App.Commands.Department;
using THD.ERP.App.Models;
using THD.ERP.Infrastructure.Repositories.Departments;

namespace THD.ERP.App.Handlers.Department
{
    public class DepartmentHandler : IRequestHandler<DepartmentCommand, DepartmentModel>
    {
        private readonly IDepartmentRepository _departmentsRepository;
        private readonly IMapper _mapper;

        public DepartmentHandler(IDepartmentRepository departmentsRepository, IMapper mapper)
        {
            _departmentsRepository = departmentsRepository;
            _mapper = mapper;
        }

        public async Task<DepartmentModel> Handle(DepartmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _departmentsRepository.GetAllAsync();
            return _mapper.Map<DepartmentModel>(result);
        }
    }
}
