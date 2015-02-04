using InventoryERP.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryERP.Validations
{
    public class RequiredIfTrueAttribute : ValidationAttribute
    {
        public string BooleanPropertyName { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance.GetValue<bool>(BooleanPropertyName))
            {
                return new RequiredAttribute().IsValid(value) 
                    ? ValidationResult.Success 
                    : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var modelClientValidationRule = new ModelClientValidationRule
            {
                ValidationType = "requirediftrue",
                ErrorMessage = FormatErrorMessage(metadata.DisplayName)
            };

            modelClientValidationRule.ValidationParameters.Add("boolprop", BooleanPropertyName);

            yield return modelClientValidationRule;
        }
    }
}