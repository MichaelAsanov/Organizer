using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizer.UI.Web.Models.Validators
{
    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(
                             IEnumerable<Attribute> attributes,
                             Type containerType,
                             Func<object> modelAccessor,
                             Type modelType,
                             string propertyName)
        {
            var data = base.CreateMetadata(attributes,
                                     containerType,
                                     modelAccessor,
                                     modelType,
                                     propertyName);

            var description = attributes
                        .SingleOrDefault(a => typeof(DescriptionAttribute) == a.GetType());
            if (description != null) data
                        .Description = ((DescriptionAttribute)description).Description;

            return data;
        }
    }
}