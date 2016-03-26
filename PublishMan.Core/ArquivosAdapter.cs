using System.Collections.Generic;
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

        public IList<string> ObtemServicos()
        {
            return _gerenciadorArquivo.ObtemPorExtensao(Configuracao.Ambiente.Origem, "exe");
        }
    }
}
