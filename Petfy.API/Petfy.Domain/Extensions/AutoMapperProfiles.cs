using AutoMapper;
using Petfy.Data.Models;
using Petfy.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Domain.Extensions
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDTO, AppUser>();
            CreateMap<RegisterDTO, Owner>();
            CreateMap<Owner, OwnerDTO>();
            CreateMap<AppUser, UserDTO>();
            CreateMap<Pet, PetDTO>()
                .ForMember(
                    dest => dest.MainPhotoUrl,
                    opt => opt.MapFrom(
                                p => p.Photos.Where(p => p.IsMain).FirstOrDefault().URL
                            )
                    );
        }
    }
}
