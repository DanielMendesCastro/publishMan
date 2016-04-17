
namespace PublishMan.Core.Configuracao
{
    public static class Dependencias
    {
        public static void Resolve(IContainer container)
        {
            container.Register<Gerenciadores.IArquivo, Gerenciadores.Arquivo>();
            container.Register<Gerenciadores.IServico, Gerenciadores.Servico>();
            container.Register<IArquivosAdapter, ArquivosAdapter>();
            container.Register<IServicosAdapter, ServicosAdapter>();
        }
    }
}
