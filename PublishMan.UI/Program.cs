using System;
using System.Windows.Forms;
using System.Configuration;

namespace PublishMan.UI
{
    static class Program
    {
        private static SimpleInjector.Container _container;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Core.Configuracao.Ambiente.Origem = ConfigurationManager.AppSettings["origem"];
            Core.Configuracao.Ambiente.Destino = ConfigurationManager.AppSettings["destino"];

            Bootstrap();

            Application.Run(_container.GetInstance<Form>());
        }

        private static void Bootstrap()
        {
            _container = new SimpleInjector.Container();

            Core.Configuracao.Dependencias.Resolve(new Container(_container));

            _container.Register<Form>();
            _container.GetRegistration(typeof(Form)).Registration.SuppressDiagnosticWarning(
                SimpleInjector.Diagnostics.DiagnosticType.DisposableTransientComponent, "Relaxa, eu cuido desse!");

            _container.Verify();
        }
    }
}
