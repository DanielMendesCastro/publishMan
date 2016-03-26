using System.Collections.Generic;
using System.Linq;
using PublishMan.Core.Gerenciadores;


namespace PublishMan.Core
{
    public class ArquivosAdapter : IArquivosAdapter
    {
        private readonly IArquivo _gerenciadorArquivo;

        public ArquivosAdapter(IArquivo gerenciadorArquivo)
        {
            _gerenciadorArquivo = gerenciadorArquivo;
        }

        public IList<Entidades.Servico> ObtemServicos()
        {
            return _gerenciadorArquivo.ObtemPorExtensao(Configuracao.Ambiente.Origem, "exe").Select(x => new Entidades.Servico(x)).ToList();
        }
    }
}
