﻿using AutoMapper;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Models
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(destination => destination.EmailConfirm,
                           option => option.MapFrom(source => source.Email));
            CreateMap<EditEmployeeModel, Employee>();
        }
    }
}
