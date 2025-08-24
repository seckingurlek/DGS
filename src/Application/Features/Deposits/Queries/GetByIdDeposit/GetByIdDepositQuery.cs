using Application.Features.Deposits.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Deposits.Queries.GetByIdDeposit
{
    public class GetByIdDepositQuery:IRequest<CreatedDepositDto>
    {
        public Guid Id { get; set; }
        
        public class GetByIdDepositQueryHandler : IRequestHandler<GetByIdDepositQuery , CreatedDepositDto>
        {

            private readonly IDepositRepository _depositRepository;
            private readonly IMapper _mapper;

            public GetByIdDepositQueryHandler(IDepositRepository depositRepository, IMapper mapper)
            {
                _depositRepository = depositRepository;
                _mapper = mapper;   
            }
            public async Task<CreatedDepositDto> Handle(GetByIdDepositQuery request, CancellationToken cancellationToken)
            {
                Deposit deposit = await _depositRepository.GetAsync(d => d.Id == request.Id);

                CreatedDepositDto createdDepositDto = _mapper.Map<CreatedDepositDto>(deposit);
                return createdDepositDto;
            }
        }
    }
}
