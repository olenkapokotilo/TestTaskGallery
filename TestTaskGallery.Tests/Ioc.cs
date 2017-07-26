using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace TestTaskGallery.Tests
{
    public static class Ioc
    {
        private static UnityContainer _container;
       
        static Ioc()
        {
            _container = new UnityContainer();
        }

        public static T Get<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public static void Add<T>(T obj)
        {
            _container.RegisterInstance<T>(obj);
        }

        public static void Add<TFrom, TTo>() where TTo : TFrom 
        {
            _container.RegisterType<TFrom,TTo>();
        }

        public static void CleanUp()
        {
            _container = new UnityContainer();
        }
    }
}
