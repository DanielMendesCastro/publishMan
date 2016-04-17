using System.Linq;
using System.ServiceProcess;

namespace PublishMan.Core.Entidades
{
    public class Servico
    {
        public Servico(string caminho, bool instalado, ServiceControllerStatus status)
        {
            Caminho = caminho;
            Nome = caminho.Split('\\').Last();
            if (Nome.Contains(".exe"))
                Nome = Nome.Replace(".exe", "");
            Instalado = instalado;
            Status = status;
        }

        public string Nome { get; set; }

        public string Caminho { get; set; }

        public bool Instalado { get; set; }

        public ServiceControllerStatus Status { get; set; }
    }
}
