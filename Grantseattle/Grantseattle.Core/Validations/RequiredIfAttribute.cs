using InventoryERP.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InventoryERP.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class RequiredIfAttribute : ValidationAttribute, IClientValidatable
    {
        string otherattribute;

        public RequiredIfAttribute(string otherattribute, string errorMessage) : base(errorMessage)
        {
            this.otherattribute = otherattribute;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            string toValidate = (string)value;

            var otherPropertyInfo = validationContext.ObjectInstance.GetType();
            string referenceProperty = (string)otherPropertyInfo.GetProperty(otherattribute).GetValue(validationContext.ObjectInstance, null);  

            if (referenceProperty != null)
            {
                if (referenceProperty.IsNotNullOrWhiteSpace())
                {
                    if (toValidate.IsNullOrWhiteSpace())
                    {
                        validationResult = new ValidationResult(ErrorMessageString);
                    }
                    
                }
                //if (toValidate.IsNotNullOrWhiteSpace())
                //{
                //    if (referenceProperty.IsNullOrWhiteSpace())
                //    {
                //        validationResult = new ValidationResult(otherattribute + "Required");
                //    }

                //}
            }
            else
            {
                validationResult = new ValidationResult("");
            }
            return validationResult;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = ErrorMessageString;

            // The value we set here are needed by the jQuery adapter
            ModelClientValidationRule requiredIfRule = new ModelClientValidationRule();

            requiredIfRule.ErrorMessage = errorMessage;

            // This is the name the jQuery adapter will use
            requiredIfRule.ValidationType = "requiredif";

            //"otherpropertyname" is the name of the jQuery parameter for the adapter, must be LOWERCASE!
            requiredIfRule.ValidationParameters.Add("otherattribute", otherattribute);

            yield return requiredIfRule;
        }
    }

    
}
