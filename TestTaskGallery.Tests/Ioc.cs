using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using TestTaskGallery.API.CompositionRoot;

namespace TestTaskGallery.Tests
{
    public static class Ioc
    {
        #region should be replaced with real Ioc container

        private static UnityContainer container;
       
        static Ioc()
        {
            container = new UnityContainer();
            }
        #endregion should be replaced with real Ioc container

        public static T Get<T>() where T : class
        {
            return container.Resolve<T>();
            }

        public static void Add<T>(T obj)
        {
            container.RegisterInstance<T>(obj);
           }

        public static void Add<TFrom, TTo>() where TTo : TFrom 
        {
            container.RegisterType<TFrom,TTo>();
           }

        public static void CleanUp()
        {
            container = new UnityContainer();
        }
    }
}
