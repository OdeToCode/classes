using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Validation
{
    public class MaxWordsAttribute : ValidationAttribute, IClientValidatable
    {
        public IEnumerable<ModelClientValidationRule>
            GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters["maxwords"] = _maxWords;
            rule.ValidationType = "wordcount";
            yield return rule;
        }

        // ...

        private readonly int _maxWords;
        const string DefaultErrorMessage = "{0} can only have {1} words";

        public MaxWordsAttribute(int maxWords) : base(DefaultErrorMessage)
        {
            _maxWords = maxWords;            
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(ErrorMessageString, name, _maxWords);
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var wordCount = value.ToString().Split(' ').Length;
                if (wordCount > _maxWords)
                {
                    return false;
                }
            }
            return true;
        }        
    }    
}