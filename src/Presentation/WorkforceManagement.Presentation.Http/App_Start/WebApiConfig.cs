using Autofac;
using Autofac.Integration.WebApi;
using WorkforceManagement.Core.Application.Organizations.Abstractions;
using WorkforceManagement.Core.Application.Projects.Abstractions;
using WorkforceManagement.Core.Application.Users.Abstractions;
using WorkforceManagement.Core.Application.Users.Create;
using WorkforceManagement.Infrastructure.Memory.Organizations;
using WorkforceManagement.Infrastructure.Memory.Projects;
using WorkforceManagement.Infrastructure.Memory.Users;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

using System.Reflection;
using System.Web.Http;

namespace WorkforceManagement.Presentation.Http
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var mediatRConfiguration = MediatRConfigurationBuilder
                .Create(string.Empty, typeof(CreateUserCommand).Assembly)
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build();

            builder.RegisterMediatR(mediatRConfiguration);

            RegisterRepositories(builder);

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<OrganizationsRepository>()
                .As<IOrganizationsRepository>()
                .SingleInstance();

            builder.RegisterType<ProjectsRepository>()
                .As<IProjectsRepository>()
                .SingleInstance();

            builder.RegisterType<UsersRepository>()
                .As<IUsersRepository>()
                .SingleInstance();
        }
    }
}
