using OceanaAura.Application.Features.LookUp.Common;
using OceanaAura.Application.Features.ProductColor.Commands.AddColor;
using OceanaAura.Application.Features.ProductColor.Commands.Common;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.LookUp.Commands.AddCagegory
{
    public class AddProductCategoryValidator : BaseValidatorAddProductCategory<AddProductCategoryCommad>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddProductCategoryValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
