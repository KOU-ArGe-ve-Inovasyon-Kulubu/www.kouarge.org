using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Models;

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
            CreateMap<AppUserUpdateDto, AppUser>();
            CreateMap<AppUser, AppUserBasicDto>();
            CreateMap<TeamMember, AppUserWithTeamDto>();
            CreateMap<GeneralAssemblyApply, AppUserWithApplyDto>();
            CreateMap<Certificate, AppUserWithCertificas>();


            //departmen
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentWithFacultyDto>();
            CreateMap<DepartmentUpdateDto, Department>();


            //faculty
            CreateMap<Faculty, FacultyDto>().ReverseMap();
            CreateMap<Faculty, FacultyWithDepartmentsDto>();
            CreateMap<FacultyUpdateDto, Faculty>();


            //redirect
            CreateMap<Redirect, RedirectDto>().ReverseMap();
            CreateMap<RedirectUpdateDto, Redirect>();

            //generalassembly
            //CreateMap<GeneralAssembly, GeneralAssemblyDto>().ReverseMap();

            //generalassemblyapply
            CreateMap<GeneralAssemblyApply, GeneralAssemblyApplyDto>().ReverseMap();
            CreateMap<GeneralAssemblyApplyUpdateDto, GeneralAssemblyApply>();

            //generalassemblyteam
            //CreateMap<GeneralAssemblyTeam, GeneralAssemblyTeamDto>().ReverseMap();
            //CreateMap<GeneralAssemblyTeam, GeneralAssemblyTeamWithGeneralAssemblyDto>();

            //teammember
            CreateMap<TeamMember, TeamMemberDto>().ReverseMap();
            CreateMap<TeamMemberUpdateDto, TeamMember>();

            //team
            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<TeamUpdateDto, Team>();


            //socialMedia
            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaPostDto>().ReverseMap();

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
            CreateMap<Event, EventWithSpeakersDto>().ReverseMap();

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


            //CustomEvent
            CreateMap<Event, EventWithPictureDto>();

            //Speaker
            CreateMap<Speaker, SpeakerDto>().ReverseMap();


            //title
            CreateMap<Title, TitleDto>().ReverseMap();

            //certificate
            CreateMap<Certificate, CertificateDto>().ReverseMap();
            CreateMap<CertificateTokenDto, Certificate>();
            CreateMap<CertificateUpdateDto, Certificate>();
        }
    }
}
