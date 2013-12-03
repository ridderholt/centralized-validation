using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CentralizedValidation.Web.Code.Entities;
using CentralizedValidation.Web.Code.Validator;
using CentralizedValidation.Web.Models;

namespace CentralizedValidation.Web.Code.Services
{
    public class UserService
    {
        private readonly Validator<UserEntity> _validator;

        public UserService()
        {
            _validator = new Validator<UserEntity>();
        }

        public IEnumerable<ValidationResult> Add(UserViewModel model)
        {
            var userEntity = new UserEntity {Age = model.Age, Firstname = model.Firstname, Lastname = model.Lastname};

            if (_validator.IsValid(userEntity))
            {
                //Save entity
            }

            return _validator.ValidationResult;
        }
    }
}