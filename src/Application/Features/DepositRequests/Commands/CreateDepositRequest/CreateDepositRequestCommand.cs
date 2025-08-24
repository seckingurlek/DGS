using Application.Features.DepositRequests.Dtos;
using Application.Features.DepositRequests.Rules;
using Application.Features.Tenant.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Mailing;
using MailKit;
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
        public CreateDepositRequestCommand()
        {
            TenantEmail = string.Empty;
            TenantName = string.Empty;
            TenantPhoneNumber = string.Empty;
        }
        public Guid Id { get; set; }
        public string TenantEmail { get; set; } 
        public string TenantPhoneNumber { get; set; }
        public string TenantName { get; set; }
        public decimal DepositAmount { get; set; }   
        public Guid LandlordId { get; set; }
        public class CreateDepositRequestCommandHandler : IRequestHandler<CreateDepositRequestCommand, CreateDepositRequestDto>
        {

            private readonly IDepositRequestRepository _depositRequestRepository;
            private readonly ILandlordRepository _landlordRepository;
            private readonly IMapper _mapper;
            private readonly DepositBusinessRules _depositBusinessRules;
            private readonly MailManager _mailManager;

            public CreateDepositRequestCommandHandler(IDepositRequestRepository depositRequestRepository, ILandlordRepository landlordRepository, IMapper mapper, DepositBusinessRules depositBusinessRules, MailManager mailManager)
            {
                _depositRequestRepository = depositRequestRepository;
                _landlordRepository = landlordRepository;
                _mapper = mapper;
                _depositBusinessRules = depositBusinessRules;
                _mailManager = mailManager; ;
            }



            public async Task<CreateDepositRequestDto> Handle(CreateDepositRequestCommand request, CancellationToken cancellationToken)
            {
                await _depositBusinessRules.LandlordMustExist(request.LandlordId);
                await _depositBusinessRules.DepositAmountMustBeGreaterThanZero(request.DepositAmount);
                await _depositBusinessRules.TenantEmailAndPhoneCanNotBeEmpty(request.TenantEmail, request.TenantPhoneNumber);


                DepositRequest mappedDepositRequest = _mapper.Map<DepositRequest>(request);
                mappedDepositRequest.Status = DepositRequestStatus.Pending;

                DepositRequest createdDepositRequest = await _depositRequestRepository.AddAsync(mappedDepositRequest);
                CreateDepositRequestDto createDepositRequestDto = _mapper.Map<CreateDepositRequestDto>(createdDepositRequest);


                _mailManager.SendDepositRequestNotification(request.TenantName, request.TenantEmail);

                return createDepositRequestDto;
            }
        }
    }
}
