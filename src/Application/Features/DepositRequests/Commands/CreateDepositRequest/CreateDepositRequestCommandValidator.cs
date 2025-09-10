using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DepositRequests.Commands.CreateDepositRequest
{
    public class CreateDepositRequestCommandValidator: AbstractValidator<CreateDepositRequestCommand>
    {
        public CreateDepositRequestCommandValidator()
        {
            RuleFor(c => c.LandlordIdentityNumber)
                           .NotEmpty().WithMessage("Kimlik numarası boş olamaz.")
                           .Length(11).WithMessage("Kimlik numarası 11 karakter uzunluğunda olmalıdır.")
                           .Matches("^[0-9]+$").WithMessage("Kimlik numarası sadece rakamlardan oluşmalıdır.");
        }
    }
}
