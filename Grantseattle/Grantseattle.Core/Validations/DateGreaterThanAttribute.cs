using InventoryERP.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace InventoryERP.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        string otherPropertyName;

        public DateGreaterThanAttribute(string otherPropertyName, string errorMessage)
            : base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;

            DateTime toValidate = (DateTime)value;
            DateTime referenceProperty = validationContext.GetValue<DateTime>(otherPropertyName);

            if (referenceProperty != null)
            {
                if (toValidate.CompareTo(referenceProperty) < 1)
                {
                    validationResult = new ValidationResult(ErrorMessageString);
                }
            }
            else
            {
                validationResult = new ValidationResult("An error occurred while validating the property. OtherProperty is not of type DateTime");
            }

            return validationResult;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = ErrorMessageString;

            // The value we set here are needed by the jQuery adapter
            ModelClientValidationRule dateGreaterThanRule = new ModelClientValidationRule();
            
            dateGreaterThanRule.ErrorMessage = errorMessage;

            // This is the name the jQuery adapter will use
            dateGreaterThanRule.ValidationType = "dategreaterthan"; 

            //"otherpropertyname" is the name of the jQuery parameter for the adapter, must be LOWERCASE!
            dateGreaterThanRule.ValidationParameters.Add("otherpropertyname", otherPropertyName);

            yield return dateGreaterThanRule;
        }
    }
}