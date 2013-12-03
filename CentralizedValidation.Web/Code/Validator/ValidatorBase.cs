using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
                if (!HasMetadata(propertyInfo)) continue;

                var validationAttributes = GetValidationAttributes(propertyInfo);

                foreach (var validationAttribute in validationAttributes)
                {
                    var isValid = validationAttribute.IsValid(propertyInfo.GetValue(entity, null));

                    if (isValid) continue;

                    var members = new List<string> { propertyInfo.Name };

                    AddValidationError(validationAttribute, results, members);
                }
            }

            ValidationResult = results;
            return !results.Any();
        }

        private static void AddValidationError(ValidationAttribute validationAttribute, List<ValidationResult> results, List<string> members)
        {
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

        private static IEnumerable<ValidationAttribute> GetValidationAttributes(PropertyInfo propertyInfo)
        {
            var metaDataAttributes = propertyInfo.GetCustomAttributes(typeof (MetadataLocationAttribute), true);
            var metaAttribute = metaDataAttributes[0] as MetadataLocationAttribute;
            var metaDataInfo = metaAttribute.Type.GetProperty(propertyInfo.Name);
            var validationAttributes = metaDataInfo.GetCustomAttributes(typeof (ValidationAttribute), true);

            return validationAttributes.Select(validationAttribute => validationAttribute as ValidationAttribute);
        }

        private static bool HasMetadata(PropertyInfo propertyInfo)
        {
            var metaDataAttributes = propertyInfo.GetCustomAttributes(typeof(MetadataLocationAttribute), true);
            return metaDataAttributes.Any();
        }
    }
}