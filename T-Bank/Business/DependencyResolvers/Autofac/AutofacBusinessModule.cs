using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Entities.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Business
            //builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            //builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<CustomerAuthManager>().As<IAuthService<Customer>>().SingleInstance();
            builder.RegisterType<EmployeeAuthManager>().As<IAuthService<Employee>>().SingleInstance();

            //Core
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            //DAL
            builder.RegisterType<EfCustomerDal>().As<ICustomerUserDal>().SingleInstance();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeUserDal>().SingleInstance();

            //var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            //    .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            //    {
            //        Selector = new AspectInterceptorSelector()
            //    }).SingleInstance();





            //var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            //builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            //    .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            //    {
            //        Selector = new AspectInterceptorSelector()
            //    }).SingleInstance();
        }
    }
}
