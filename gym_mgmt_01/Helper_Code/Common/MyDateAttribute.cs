using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace gym_mgmt_01.Helper_Code.Common
{
    public class MyDateAttribute : ValidationAttribute, IClientValidatable
    {
        private DateTime _MinDate;

        public MyDateAttribute()
        {
            _MinDate = DateTime.Today;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime _EndDat = DateTime.Parse(value.ToString(), CultureInfo.InvariantCulture);
            DateTime _CurDate = DateTime.Today;

            int cmp = _EndDat.CompareTo(_CurDate);
            if (cmp > 0)
            {
                // date1 is greater means date1 is comes after date2
                return ValidationResult.Success;
            }
            else if (cmp < 0)
            {
                // date2 is greater means date1 is comes after date1
                return new ValidationResult(ErrorMessage);
            }
            else
            {
                // date1 is same as date2
                return ValidationResult.Success;
            }
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "restrictbackdates",
            };
            rule.ValidationParameters.Add("mindate", _MinDate);
            yield return rule;
        }
    }
}