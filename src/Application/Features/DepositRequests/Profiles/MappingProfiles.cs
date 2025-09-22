using Application.Features.DepositRequests.Commands.CreateDepositRequest;
using Application.Features.DepositRequests.Dtos;
using Application.Features.Property.Commands.CreateProperty;
using Application.Features.Property.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DepositRequests.Profiles
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateDepositRequestCommand,CreateDepositRequestDto>().ReverseMap();
            CreateMap<DepositRequest,CreateDepositRequestCommand>().ReverseMap();
            // DepositRequest -> UpdateDepositRequestStatusDto
            CreateMap<DepositRequest, UpdateDepositRequestStatusDto>()
                .ForMember(dest => dest.IsAccepted, opt => opt.MapFrom(src => src.IsAccepted))
                .ReverseMap(); // DTO -> Entity
            CreateMap<CreatePropertyDto, Domain.Entities.Property>().ReverseMap();
            CreateMap<Domain.Entities.Property, CreatedPropertyDto>().ReverseMap();
            CreateMap<DepositRequest, CreateDepositRequestDto>().ReverseMap();

        }
    }
}
