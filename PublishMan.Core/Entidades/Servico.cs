
using System.Linq;

namespace PublishMan.Core.Entidades
{
    public class Servico
    {
        public Servico(string caminho)
        {
            Caminho = caminho;
            Nome = caminho.Split('\\').Last();
        }

        public string Nome { get; set; }

        public string Caminho { get; set; }

        public bool Instalado { get; set; }

        public bool Ligado { get; set; }

    }
}
