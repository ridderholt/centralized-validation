using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;
using CentralizedValidation.Web.Code.Attribute;

namespace CentralizedValidation.Web.Code.Validator
{
    public class ValidatorBase<TEntity> where TEntity : class
    {
        public IEnumerable<ValidationResult> ValidationResult { get; protected set; }

        public bool IsValid(TEntity entity)
        {
            var results = new List<ValidationResult>();

            foreach (var propertyInfo in entity.GetType().GetProperties())
            {
                var metaDataAttributes = propertyInfo.GetCustomAttributes(typeof(MetadataLocationAttribute), true);
                if (metaDataAttributes.Any())
                {
                    var metaAttribute = metaDataAttributes[0] as MetadataLocationAttribute;
                    var metaDataInfo = metaAttribute.Type.GetProperty(propertyInfo.Name);
                    var validationAttributes = metaDataInfo.GetCustomAttributes(typeof(ValidationAttribute), true);

                    foreach (var attr in validationAttributes)
                    {
                        var validationAttribute = attr as ValidationAttribute;
                        var isValid = validationAttribute.IsValid(propertyInfo.GetValue(entity, null));

                        if (!isValid)
                        {
                            var members = new List<string> { propertyInfo.Name };

                            if (string.IsNullOrEmpty(validationAttribute.ErrorMessageResourceName))
                            {
                                results.Add(new ValidationResult(validationAttribute.ErrorMessage, members));
                            }
                            else
                            {
                                var manager = new ResourceManager(validationAttribute.ErrorMessageResourceType);
                                results.Add(new ValidationResult(manager.GetString(validationAttribute.ErrorMessageResourceName), members));
                            }
                        }
                    }
                }
            }

            ValidationResult = results;
            return !results.Any();
        }
    }
}