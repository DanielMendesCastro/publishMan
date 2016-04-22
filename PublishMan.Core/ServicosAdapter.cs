using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using PublishMan.Core.Extensoes;
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
            var servicos = new List<Servico>();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var executavel in executaveis)
            {
                //pega o instalador dentro do serviço
                var installer = new AssemblyInstaller(executavel, new[] { "" }) { UseNewContext = true }.PegaServiceInstaller();

                //pega os dados do serviço caso esteja instalado
                var servicoMaquina = servicosMaquina.FirstOrDefault(x => x.ServiceName.Equals(installer.DisplayName));

                servicos.Add(new Servico(installer, servicoMaquina, executavel));
            }

            return servicos;
        }
    }
}
