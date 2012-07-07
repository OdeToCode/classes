using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace Movies.Models
{
    public class MaxWordsAttribute : ValidationAttribute, 
                                     IClientValidatable 
    {
        public MaxWordsAttribute(int maxWords)
        {
            MaxWords = maxWords;
        }

        public int MaxWords { get; set; }        

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            // simplistic check...
            int wordCount = value.ToString().Split(' ').Count();
            if (wordCount > MaxWords)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<ModelClientValidationRule>
            GetClientValidationRules(
                ModelMetadata metadata,
                ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters["maxwords"] = MaxWords;
            rule.ValidationType = "wordcount";
            yield return rule;
        }
    }

}