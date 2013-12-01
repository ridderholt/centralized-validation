using System;

namespace CentralizedValidation.Web.Code.Attribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MetadataLocationAttribute : System.Attribute
    {
        public Type Type { get; set; }

        public MetadataLocationAttribute(Type type)
        {
            Type = type;
        }
    }
}