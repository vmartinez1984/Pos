using System.ComponentModel.DataAnnotations;
using Pos.Core.Interfaces.IBusinesLayer;

namespace Pos.Core.Validators
{
    public class ExistsBarcodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            bool result;

            var _unitOfWorkBl = validationContext.GetService(typeof(IUnitOfWorkBl)) as IUnitOfWorkBl;

            result = _unitOfWorkBl.Product.ExistsBarcodeAsync(value.ToString()).Result;
            if (result)
                return new ValidationResult($"El código de barras {value.ToString()} ya existe");

            return ValidationResult.Success;
        }
    }

     public class NotExistsBarcodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            bool result;

            var _unitOfWorkBl = validationContext.GetService(typeof(IUnitOfWorkBl)) as IUnitOfWorkBl;

            result = _unitOfWorkBl.Product.ExistsBarcodeAsync(value.ToString()).Result;
            if (!result)
                return new ValidationResult($"El código de barras {value.ToString()} no existe");

            return ValidationResult.Success;
        }
    }
}