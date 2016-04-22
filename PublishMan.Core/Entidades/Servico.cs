using System.Linq;
using System.ServiceProcess;

namespace PublishMan.Core.Entidades
{
    public class Servico
    {
        public Servico(ServiceInstaller instalador, ServiceController service, string caminho)
        {
            Description = instalador.Description;
            DisplayName = instalador.DisplayName;
            ServiceName = instalador.ServiceName;

            Caminho = caminho;
            Nome = caminho.Split('\\').Last();
            if (Nome.Contains(".exe"))
                Nome = Nome.Replace(".exe", "");

            Instalado = service != null;
            Status = service?.Status ?? ServiceControllerStatus.Stopped;
        }

        //new
        public string Description { get; set; }

        public string DisplayName { get; set; }

        public string ServiceName { get; set; }

        //old
        public string Nome { get; set; }

        public string Caminho { get; set; }

        public bool Instalado { get; set; }

        //same
        public ServiceControllerStatus Status { get; set; }
    }
}
