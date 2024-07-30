using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THD.ERP.App.Models;
using THD.ERP.DataAccessor.Entities;

namespace THD.ERP.App
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Student, StudentModel>();
            CreateMap<StudentModel, Student>();
        }
    }
}
