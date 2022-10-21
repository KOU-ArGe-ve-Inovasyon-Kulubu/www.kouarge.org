using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            //kaynak_sınıf -> donusturulecek sınıf --- reverse map -> tam tersi donusturme işlemi yap

            //appuser
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AppUserRegisterDto, AppUser>();


            //departmen
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentWithFacultyDto>();
            CreateMap<DepartmentUpdateDto, Department>();


            //faculty
            CreateMap<Faculty, FacultyDto>().ReverseMap();
            CreateMap<Faculty,FacultyWithDepartmentsDto>();
            
         
            
            //redirect
            CreateMap<Redirect, RedirectDto>().ReverseMap();


            //generalassembly
            CreateMap<GeneralAssembly, GeneralAssemblyDto>().ReverseMap();

            //generalassemblyapply
            CreateMap<GeneralAssemblyApply, GeneralAssemblyApplyDto>().ReverseMap();

            //generalassemblyteam
            CreateMap<GeneralAssemblyTeam, GeneralAssemblyTeamDto>().ReverseMap();

            //teammember
            CreateMap<TeamMember, TeamMemberDto>().ReverseMap();

            //team
            CreateMap<Team, TeamDto>().ReverseMap();

        }
    }
}
