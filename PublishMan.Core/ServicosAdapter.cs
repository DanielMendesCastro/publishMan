using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using PublishMan.Core.Gerenciadores;
using Servico = PublishMan.Core.Entidades.Servico;

namespace PublishMan.Core
{
    public class ServicosAdapter : IServicosAdapter
    {
        private readonly IArquivo _gerenciadorArquivo;
        private readonly IServico _gerenciadorServico;

        public ServicosAdapter(IArquivo gerenciadorArquivo, IServico gerenciadorServico)
        {
            _gerenciadorArquivo = gerenciadorArquivo;
            _gerenciadorServico = gerenciadorServico;
        }

        public IList<Servico> ObtemServicos()
        {
            //busca os executáveis da pasta
            var executaveis = _gerenciadorArquivo.ObtemPorExtensao(Configuracao.Ambiente.Origem, "exe").ToList();
            executaveis.RemoveAll(x => x.Contains("vshost"));

            //busca os servicos instalados na maquina
            var servicosMaquina = _gerenciadorServico.Obtem();

            //transforma em servico verificando se está instalado e o status
            return (from executavel in executaveis
                    let servicoMaquina = servicosMaquina.FirstOrDefault(x => x.ServiceName.Equals(executavel))
                    select new Servico(executavel, servicoMaquina != null, servicoMaquina?.Status ?? ServiceControllerStatus.Stopped)).ToList();
        }
    }
}
