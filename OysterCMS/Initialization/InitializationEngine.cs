using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using OysterCMS.PageTypes;
using Hyper.ComponentModel;

namespace OysterCMS.Initialization
{
    class InitializationEngine
    {
        private static object initLock = new object();
        private static bool isInitialized = false;

        public static void Initialize()
        {
            lock (initLock)
            {
                if (isInitialized)
                    return;

                RegisterHyperDescriptors();
                DataFactory.Instance.ToString();

                isInitialized = true;
            }
        }

        /// <summary>
        /// To increase performace of dynamic property access we're using HyperDescriptors and in order
        /// to maximize performance and ease of use we register all pagetypes with the HyperTypeDescriptionProvider
        /// from the start.
        /// </summary>
        private static void RegisterHyperDescriptors()
        {
            Assembly[] AssembliesLoaded = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly loadedAssembly in AssembliesLoaded)
            {
                // Find all classes that derive from PageTypeBase
                foreach (var derivedClass in loadedAssembly.GetTypes().Where(type => type.IsSubclassOf(typeof(PageTypeBase))))
                {
                    // Register
                    HyperTypeDescriptionProvider.Add(derivedClass);
                }
            }
        }
    }
}
