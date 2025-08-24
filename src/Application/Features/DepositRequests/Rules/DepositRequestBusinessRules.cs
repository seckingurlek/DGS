using Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCuttingConcerns.Exceptions;

namespace Application.Features.DepositRequests.Rules
{
    public class DepositBusinessRules
    {
        private readonly IDepositRequestRepository _depositRequestRepository;
        private readonly ILandlordRepository _landlordRepository;
        public DepositBusinessRules(IDepositRequestRepository depositRequestRepository, ILandlordRepository landlordRepository)
        {
            _depositRequestRepository = depositRequestRepository;
            _landlordRepository = landlordRepository;   
        }
        public async Task TenantEmailAndPhoneCanNotBeEmpty(string email, string phone)
        {
            var result = await _depositRequestRepository.GetAsync(e => e.TenantEmail == email & e.TenantPhone == phone);
            if (result == null)
            {
                throw new BusinessExceptions("Tenant Email and phone number must be filled");
            }
        }

        public async Task LandlordMustExist(Guid LandlordId)
        {
            var landLord = await _landlordRepository.GetAsync(l=>l.Id == LandlordId);
            if (landLord == null)
            {
                throw new Exception("Ev sahibi bulunamadı.");
            }
        }


        public Task DepositAmountMustBeGreaterThanZero(decimal depositAmount)
        {
            if (depositAmount <= 0)
                throw new BusinessExceptions("Miktar 0'dan büyük olmalı");
            return Task.CompletedTask;
        }
    }
}
