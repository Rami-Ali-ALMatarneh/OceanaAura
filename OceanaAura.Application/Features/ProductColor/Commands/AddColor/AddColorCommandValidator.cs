using FluentValidation;
using OceanaAura.Application.Features.ContactUs.Commands.AddContactUs;
using OceanaAura.Application.Features.ProductColor.Commands.Common;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.ProductColor.Commands.AddColor
{
    public class AddColorCommandValidator : BaseValidator<AddColorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddColorCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
