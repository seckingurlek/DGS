using Application.Features.DepositRequests.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DepositRequests.Commands.CreateDepositRequest
{
    public class CreateDepositRequestCommand : IRequest<CreateDepositRequestDto>
    {
        public Guid Id { get; set; }
        public class CreateDepositRequestCommandHandler : IRequestHandler<CreateDepositRequestCommand, CreateDepositRequestDto>
        {

            private readonly IDepositRequestRepository _depositRequestRepository;
            private readonly IMapper _mapper;

            public CreateDepositRequestCommandHandler(IDepositRequestRepository depositRequestRepository, IMapper mapper)
            {
                _depositRequestRepository = depositRequestRepository;
                _mapper = mapper;
            }



            public async Task<CreateDepositRequestDto> Handle(CreateDepositRequestCommand request, CancellationToken cancellationToken)
            {
                DepositRequest mappedDepositRequest = _mapper.Map<DepositRequest>(request);
                DepositRequest createdDepositRequest = await _depositRequestRepository.AddAsync(mappedDepositRequest);
                CreateDepositRequestDto createDepositRequestDto = _mapper.Map<CreateDepositRequestDto>(createdDepositRequest);
                return createDepositRequestDto;
            }
        }
    }
}
