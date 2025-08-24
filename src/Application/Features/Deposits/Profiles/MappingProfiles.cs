using Application.Features.Deposits.Dtos;
using Application.Features.Deposits.Queries.GetByIdDeposit;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Deposits.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()  
        {
            CreateMap<Deposit, CreatedDepositDto>()
                .ForMember(dest => dest.TenantFullName,
                           opt => opt.MapFrom(src => src.Tenant.FirstName + " " + src.Tenant.LastName))
                .ForMember(dest => dest.LandlordFullName,
                           opt => opt.MapFrom(src => src.Landlord.FirstName + " " + src.Landlord.LastName))
                .ReverseMap();

            CreateMap<Deposit, GetByIdDepositQuery>().ReverseMap();

        }
        
        

    }
}
