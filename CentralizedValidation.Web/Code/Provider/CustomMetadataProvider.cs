using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CentralizedValidation.Web.Code.Attribute;

namespace CentralizedValidation.Web.Code.Provider
{
    public class CustomMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<System.Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            if (attributes.OfType<MetadataLocationAttribute>().Any())
            {
                var metadataType = attributes.OfType<MetadataLocationAttribute>().First().Type;

                if (attributes != null)
                    return base.CreateMetadata(attributes, metadataType, modelAccessor, modelType, propertyName);
            }

            return base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
        }
    }
}