using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceProcess;
using PublishMan.Core.Entidades;

namespace PublishMan.Core.Test
{
    [TestClass]
    public class ServicoTest
    {
        public Gerenciadores.Servico Gerenciador = new Gerenciadores.Servico();
        public Servico Servico = new Servico(@"C:\publishMan\servico\ServicoExemplo.exe", false, ServiceControllerStatus.Stopped);

        [TestMethod]
        public void DeveEncontrarServicoInstalado()
        {
            Assert.IsNotNull(Gerenciador.Obtem(ServiceController.GetServices().First().ServiceName));
        }

        [TestMethod]
        public void DeveRetornarNullParaServicosNaoInstalados()
        {
            Assert.IsNull(Gerenciador.Obtem("AlgumServicoNaoInstalado"));
        }

        [TestMethod]
        public void DeveInstalarServico()
        {
            if (Gerenciador.Obtem(Servico.Nome) != null)
                Gerenciador.Desinstala(Servico);

            Gerenciador.Instala(Servico);

            Assert.IsNotNull(Gerenciador.Obtem(Servico.Nome));

            Gerenciador.Desinstala(Servico);
        }

        [TestMethod]
        public void DeveDesinstalarServico()
        {
            if (Gerenciador.Obtem(Servico.Nome) == null)
                Gerenciador.Instala(Servico);

            Gerenciador.Desinstala(Servico);

            Assert.IsNull(Gerenciador.Obtem(Servico.Nome));
        }
    }
}
