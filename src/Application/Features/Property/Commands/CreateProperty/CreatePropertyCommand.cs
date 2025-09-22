using Application.Features.Property.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Property.Commands.CreateProperty
{
    public class CreatePropertyCommand:IRequest<CreatedPropertyDto>
    {
        public Guid LandlordId { get; set; }   // Landlord referansı
        public CreatePropertyDto PropertyDto { get; set; }

        public class CreatePropertCommandHandler : IRequestHandler<CreatePropertyCommand, CreatedPropertyDto>
        {
            private readonly IPropertyRepository _propertyRepository;
            private readonly ILandlordRepository _landlordRepository;
            private readonly IMapper _mapper;
            public CreatePropertCommandHandler(IPropertyRepository propertyRepository, ILandlordRepository landlordRepository, IMapper mapper )
            {
             _propertyRepository = propertyRepository;
                _landlordRepository = landlordRepository;
                _mapper = mapper;
            }
            public async Task<CreatedPropertyDto> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
            {
                // DTO --> entity
                var property = _mapper.Map<Domain.Entities.Property>(request.PropertyDto);  
                property.LandlordId = request.LandlordId;

                var createdProperty = await _propertyRepository.AddAsync(property); //kayıt

                var landlord = await _landlordRepository.GetAsync(l=> l.Id == request.LandlordId);
                if (landlord == null) throw new Exception("Landlord bulunamadı");

                


                // Entity → DTO
                var createdDto = _mapper.Map<CreatedPropertyDto>(createdProperty);
                createdDto.LandlordFullName = landlord.FirstName + " " + landlord.LastName;

                return createdDto;


            }
        }
    }
}
