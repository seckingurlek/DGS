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
            RuleFor(c => c.Id.ToString("N")) // "N" formatı: "34f8e0a7d5b4"
                .NotEmpty().WithMessage("Id boş olamaz.")
                .Length(11).WithMessage("Id 11 karakter uzunluğunda olmalıdır.");
        }
    }
}
