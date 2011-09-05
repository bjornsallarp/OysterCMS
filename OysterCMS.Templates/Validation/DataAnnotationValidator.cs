using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using OysterCMS.PropertyControls;
using System.Web.UI;

using OysterCMS.Templates.Extensions;

namespace OysterCMS.Templates.Validation
{
    public class DataAnnotationValidator : BaseValidator
    {
        protected override bool EvaluateIsValid()
        {
            Type objectType = null;

            if (SourceType != null)
            {
                objectType = SourceType;
            }
            else if (!string.IsNullOrEmpty(SourceTypeString))
            {
                objectType = Type.GetType(SourceTypeString, true, true);
            }

            if (objectType != null)
            {
                // Find control to validate
                var inputControl = this.FindControl(this.ControlToValidate);
                if(inputControl != null)
                {
                    // All controls that can be validated must be decorated with a ValidationPropertyAttribute attribute that 
                    // tells which property to validate
                    Type inputControlType = inputControl.GetType();
                    string validationPropertyName = inputControlType.ValidationPropertyName();

                    if (validationPropertyName != null && inputControl != null)
                    {
                        PropertyInfo validationPropInfo = inputControlType.GetProperty(validationPropertyName);

                        // Loop through all validation decorated for the given property
                        foreach (var item in objectType.ValidationAttributes(PropertyName))
                        {
                            // Run the decorator validator using the value form the input control
                            if (!item.IsValid(validationPropInfo.GetValue(inputControl, null)))
                            {
                                this.ErrorMessage = item.ErrorMessage;
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public string PropertyName { get; set; }
        public Type SourceType { get; set; }
        public string SourceTypeString { get; set; }
    }
}