using System.ComponentModel.DataAnnotations;
using CentralizedValidation.Web.Code.Attribute;
using CentralizedValidation.Web.Code.Metadata;

namespace CentralizedValidation.Web.Models
{
    public class UserViewModel
    {
        [MetadataLocation(typeof(UserMetadata))]
        public string Firstname { get; set; }

        [MetadataLocation(typeof(UserMetadata))]
        public string Lastname { get; set; }

        [MetadataLocation(typeof(UserMetadata))]
        public string Email { get; set; }

        [MetadataLocation(typeof(UserMetadata))]
        public int Age { get; set; }
    }
}