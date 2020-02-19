using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Common.Interfaces;
using FluentValidation;
using Organizer.Domain.Entities;
using Organizer.Domain.Interfaces;
using Organizer.Services;
using Organizer.UI.Web.Mapping;
using Organizer.UI.Web.Models.Validators;
using Organizer.UI.Web.Models.ViewModels;

namespace Organizer.UI.Web.App_Start
{
    public class AutofaqConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType(typeof (TaskDbService)).As(typeof (ITaskDbService)).InstancePerLifetimeScope();
            builder.RegisterType(typeof (TaskMapper)).As(typeof (ICommonMapper<Task, TaskViewModel>)).InstancePerLifetimeScope();

            builder.RegisterType(typeof(FluentValidatorFactory)).As(typeof(IValidatorFactory)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(FluentValidationService)).As(typeof(IValidationService)).InstancePerLifetimeScope();

            builder.RegisterType(typeof (TaskModelValidator)).As(typeof (IValidator<TaskViewModel>)).InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}