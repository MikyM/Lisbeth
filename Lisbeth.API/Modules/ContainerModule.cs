using System.Reflection;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using AutoMapper.Extensions.ExpressionMapping;
using Lisbeth.API.Application.Interfaces;
using Lisbeth.API.Application.Services;
using Lisbeth.API.DataAccessLayer.DbContext;
using Lisbeth.API.DataAccessLayer.Repositories;
using MikyM.Common.DataAccessLayer.Extensions;
using Microsoft.AspNetCore.Http;
using MikyM.Common.Application.Interfaces;
using MikyM.Common.Application.Services;
using Module = Autofac.Module;

namespace Lisbeth.API.Modules
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            // stuff
            builder.RegisterAutoMapper(opt => opt.AddExpressionMapping(), Assembly.GetExecutingAssembly());
            builder.AddUnitOfWork<LisbethDbContext>();
            builder.RegisterGeneric(typeof(ReadOnlyService<,,>)).As(typeof(IReadOnlyService<,>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(CrudService<,,>)).As(typeof(ICrudService<,>))
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(AuditLogService).Assembly).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(AuditRepository).Assembly).Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            // pagination stuff
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.Register(x =>
            {
                var accessor = x.Resolve<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            }).As<IUriService>().SingleInstance();

        }
    }
}
