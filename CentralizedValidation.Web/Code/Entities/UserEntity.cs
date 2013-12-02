using CentralizedValidation.Web.Code.Attribute;
using CentralizedValidation.Web.Code.Metadata;

namespace CentralizedValidation.Web.Code.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        [MetadataLocation(typeof(UserMetadata))]
        public string Firstname { get; set; }

        [MetadataLocation(typeof(UserMetadata))]
        public string Lastname { get; set; }

        [MetadataLocation(typeof(UserMetadata))]
        public int Age { get; set; }
    }
}