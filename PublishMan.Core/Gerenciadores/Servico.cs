using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;

namespace PublishMan.Core.Gerenciadores
{
    public class Servico : IServico
    {
        public List<ServiceController> Obtem()
        {
            return ServiceController.GetServices().ToList();
        }

        public ServiceController Obtem(string nome)
        {
            var services = ServiceController.GetServices();

            return services.FirstOrDefault(x => x.ServiceName.Equals(nome));
        }

        public void Instala(Entidades.Servico servico)
        {
            var installer = new AssemblyInstaller(servico.Caminho, new[] { "" })
            {
                UseNewContext = true
            };

            //((ServiceInstaller)installer.Installers[0].Installers[1]).

            installer.Install(null);
            installer.Commit(null);
        }

        public void Desinstala(Entidades.Servico servico)
        {
            var installer = new AssemblyInstaller(servico.Caminho, new[] { "" })
            {
                UseNewContext = true
            };

            installer.Uninstall(null);
        }

        public void Parar(Entidades.Servico servico)
        {
            var sc = new ServiceController(servico.Nome);
            sc.Start();
            sc.WaitForStatus(ServiceControllerStatus.Running);
        }

        public void Iniciar(Entidades.Servico servico)
        {
            var sc = new ServiceController(servico.Nome);
            sc.Stop();
            sc.WaitForStatus(ServiceControllerStatus.Stopped);
        }
    }
}
