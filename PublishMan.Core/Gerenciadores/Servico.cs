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
            return ServiceController.GetServices().FirstOrDefault(x => x.ServiceName.Equals(nome));
        }

        public void Instala(Entidades.Servico servico)
        {
            var installer = new AssemblyInstaller(servico.Caminho, new[] { "" })
            {
                UseNewContext = true
            };

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
    }
}
