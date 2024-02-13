using AutoMapper;
using NoteApp.Data.Data.Models;
using NoteApp.DataAccess.Data.Models;
using WebNote.ViewModels;

namespace WebNote.Common.Mappings
{
    public class NoteMapProfile : Profile
    {
        public NoteMapProfile()
        {
            CreateMap<Note, NoteViewModels>().ReverseMap();
            CreateMap<User, UserViewModel>()
                .ReverseMap()
                .ForMember(m => m.PasswordHash, n => n.MapFrom(u => u.Password));
        }
    }

}
