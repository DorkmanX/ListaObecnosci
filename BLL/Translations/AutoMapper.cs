using AutoMapper;
using DLL.EntityFramework;
using BLL.Views;

namespace BLL.Translations
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<StudentDTO, StudentView>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));

        }
    }
//comments
/*
CreateMap<User, UserNameViewModel>()
                .ForMember(dest => dest.FName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Description, opt => opt.Ignore())
                .AfterMap((_, dest) =>
                {
                    dest.DateCreated = DateTime.Now;
                })
                .ReverseMap();
*/

}
