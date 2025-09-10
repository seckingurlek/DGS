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

namespace Application.Features.DepositRequests.Commands.UpdateDepositRequest
{
    public class UpdateDepositRequestStatusCommand : IRequest<UpdateDepositRequestStatusDto>
    {


        public UpdateDepositRequestStatusCommand() { }


        public string TenantIdentityNumber { get; set; }
        public bool IsAccepted { get; set; }

        public class UpdateDepositRequestStatusCommandHandler :IRequestHandler<UpdateDepositRequestStatusCommand , UpdateDepositRequestStatusDto>
        {
            private readonly IDepositRequestRepository _depositRequestRepository;
            private readonly IMapper _mapper;


            public UpdateDepositRequestStatusCommandHandler(IDepositRequestRepository depositRequestRepository, IMapper mapper)
            {
                _depositRequestRepository = depositRequestRepository;
                _mapper = mapper;
            }

            public async Task<UpdateDepositRequestStatusDto> Handle(UpdateDepositRequestStatusCommand request, CancellationToken cancellationToken)
            {
                var depositRequest = await _depositRequestRepository.GetAsync(d => d.TenantIdentityNumber  == request.TenantIdentityNumber);
                if (depositRequest == null)
                {
                    throw new ArgumentException("Deposit request bulunamadı.");
                }

                // Status ve IsAccepted güncelle
                depositRequest.IsAccepted = request.IsAccepted;
                depositRequest.Status = request.IsAccepted ? DepositRequestStatus.Accepted : DepositRequestStatus.Rejected;

                // DB'ye güncelle
                var updatedDepositRequest = await _depositRequestRepository.UpdateAsync(depositRequest);

                // DTO'ya map
                var createdRequestStatusDto = _mapper.Map<UpdateDepositRequestStatusDto>(updatedDepositRequest);
                return createdRequestStatusDto;
            }
        }
    }
}
