using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Mapping
{
    public class MapProfile : Profile
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
            CreateMap<Faculty, FacultyWithDepartmentsDto>();


            //redirect
            CreateMap<Redirect, RedirectDto>().ReverseMap();


            //generalassembly
            CreateMap<GeneralAssembly, GeneralAssemblyDto>().ReverseMap();

            //generalassemblyapply
            CreateMap<GeneralAssemblyApply, GeneralAssemblyApplyDto>().ReverseMap();

            //generalassemblyteam
            CreateMap<GeneralAssemblyTeam, GeneralAssemblyTeamDto>().ReverseMap();
            CreateMap<GeneralAssemblyTeam, GeneralAssemblyTeamWithGeneralAssemblyDto>();

            //teammember
            CreateMap<TeamMember, TeamMemberDto>().ReverseMap();

            //team
            CreateMap<Team, TeamDto>().ReverseMap();


            //socialMedia
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<SocialMediaUpdateDto, SocialMedia>();

            //socialMediaType
            CreateMap<SocialMediaType, SocialMediaTypeDto>().ReverseMap();
            CreateMap<SocialMediaTypeUpdateDto, SocialMediaType>();

            //sponsorAndPartner
            CreateMap<SponsorsAndPartners, SponsorAndPartnersDto>().ReverseMap();
            CreateMap<SponsorAndPartnersUpdateDto, SponsorsAndPartners>();

            //event
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<EventUpdateDto, Event>();

            //event participant
            CreateMap<EventParticipant, EventParticipantDto>().ReverseMap();
            CreateMap<EventParticipantUpdateDto, EventParticipant>();


            //event picture
            CreateMap<EventPicture, EventPictureDto>().ReverseMap();
            CreateMap<EventPictureUpdateDto, EventPicture>();


            //Semester
            CreateMap<Semester, SemesterDto>().ReverseMap();
            CreateMap<SemesterUpdateDto, Semester>();


            //Ourformat
            CreateMap<OurFormat, OurFormatDto>().ReverseMap();
            CreateMap<OurFormatUpdateDto, OurFormat>();

        }
    }
}
