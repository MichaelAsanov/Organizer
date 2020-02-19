using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;
using Organizer.TestData;
using Organizer.UI.Web.App_Start;
using Organizer.UI.Web.Models.Validators;

namespace Organizer.UI.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofaqConfig.ConfigureContainer();

            Database.SetInitializer(new OrganizerDbDataInitializer());

            ModelValidatorProviders.Providers.Clear();
            ModelValidatorProviders.Providers.Add(
                new FluentValidationModelValidatorProvider(new FluentValidatorFactory()));

            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ModelMetadataProviders.Current = new CustomModelMetadataProvider();
        }
    }
}
