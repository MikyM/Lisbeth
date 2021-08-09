using System.Reflection;
using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using AutoMapper.Extensions.ExpressionMapping;
using Lisbeth.API.Application.Interfaces;
using Lisbeth.API.Application.Services;
using Lisbeth.DataAccessLayer.DbContext;
using Lisbeth.DataAccessLayer.Repositories.Base;
using Lisbeth.DataAccessLayer.UnitOfWork;
using Lisbeth.Shared.Application.Interfaces.Base;
using Lisbeth.Shared.Application.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
            
            // unitofwork
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.Register(x =>
            {
                var ctx = x.Resolve<LisbethDbContext>();
                return new UnitOfWork(ctx);
            }).As<IUnitOfWork>().InstancePerLifetimeScope();

            //  services
            builder.RegisterGeneric(typeof(ReadOnlyService<,>)).As(typeof(IReadOnlyService<,>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(CrudService<,>)).As(typeof(ICrudService<,>)).InstancePerLifetimeScope();
            builder.RegisterType<ServiceBase>().As<IServiceBase>().InstancePerLifetimeScope();
            
            // pagination stuff
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.Register(x =>
            {
                var accessor = x.Resolve<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            }).As<IUriService>().SingleInstance();

            //builder.Register(b => new LisbethDbContext
             //   (new DbContextOptionsBuilder<LisbethDbContext>().UseInMemoryDatabase("test").Options)).SingleInstance();
            // register me daddy
        }
    }
}
