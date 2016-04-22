using System.Configuration.Install;
using System.ServiceProcess;

namespace PublishMan.Core.Extensoes
{
    public static class AssemblyInstallerExtension
    {
        public static ServiceInstaller PegaServiceInstaller(this AssemblyInstaller a)
        {
            var collection = a.Installers;

            while (collection.Count < 2 || collection[1].GetType() != typeof(ServiceInstaller))
            {
                if (collection.Count == 0)
                    return null;

                collection = collection[0].Installers;
            }

            return (ServiceInstaller)collection[1];
        }
    }
}
