using AutoMapper;
using GameZone.DTOs;
using GameZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameZone.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to DTO
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Game, GameDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();

            //DTO to Domain
            Mapper.CreateMap<CustomerDTO, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<GameDTO, Game>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}