using Castle.Windsor.Installer;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonkeyShelter.Common
{
    public static class CastleHelper
    {
        public static WindsorContainer Container { get; private set; }
        private static WindsorHttpDependencyResolver _resolver;
        private static bool _initialized;

        static CastleHelper()
        {
            Container = new WindsorContainer();
            _initialized = false;
        }

        public static WindsorHttpDependencyResolver GetDependencyResolver()
        {
            if (_initialized)
                return _resolver;

            _initialized = true;
            Container.Install(FromAssembly.This());
            _resolver = new WindsorHttpDependencyResolver(Container);

            return _resolver;
        }
    }
}