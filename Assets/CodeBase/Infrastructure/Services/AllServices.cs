using System;
using System.Collections.Generic;

namespace CodeBase.Infrastructure.Services
{
    public class AllServices
    {
        private readonly Dictionary<Type, IService> _services = new();

        private static AllServices _instance;

        public static AllServices Container => _instance ??= new AllServices();

        public TService Single<TService>() where TService : IService
        {
            return (TService)_services[typeof(TService)];
        }

        public void RegisterSingle<TService>(TService service) where TService : IService
        {
            _services.Add(typeof(TService), service);
        }
    }
}