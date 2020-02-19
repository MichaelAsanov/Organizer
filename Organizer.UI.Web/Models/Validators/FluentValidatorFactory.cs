using System;
using System.Web.Mvc;
using FluentValidation;

namespace Organizer.UI.Web.Models.Validators
{
    public class FluentValidatorFactory : IValidatorFactory
    {
        public virtual IValidator<T> GetValidator<T>()
        {
            return (IValidator<T>)this.GetValidator(typeof(T));
        }

        public virtual IValidator GetValidator(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return DependencyResolver.Current.GetService(typeof(IValidator<>).MakeGenericType(type)) as IValidator;
        }
    }
}