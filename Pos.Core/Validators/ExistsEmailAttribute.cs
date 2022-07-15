using System.ComponentModel.DataAnnotations;
using Pos.Core.Interfaces.IBusinesLayer;

namespace Pos.Core.Validators
{
    public class ExistsEmailAttribute: ValidationAttribute
    {
         protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            bool result;

            var _unitOfWorkBl = validationContext.GetService(typeof(IUnitOfWorkBl)) as IUnitOfWorkBl;

            result = _unitOfWorkBl.User.ExistsEmailAsync(value.ToString()).Result;
            if (result)
                return new ValidationResult($"El correo {value} ya existe");

            return ValidationResult.Success;
        }
    }
}