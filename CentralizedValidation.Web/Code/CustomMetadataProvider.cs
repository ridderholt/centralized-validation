using System;
using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;

namespace CentralizedValidation.Web.Code
{
    public class CustomMetadataProvider : DataAnnotationsModelMetadata
    {
        public CustomMetadataProvider(DataAnnotationsModelMetadataProvider provider, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName, DisplayColumnAttribute displayColumnAttribute)
            : base(provider, containerType, modelAccessor, modelType, propertyName, displayColumnAttribute)
        {

        }
   }
}