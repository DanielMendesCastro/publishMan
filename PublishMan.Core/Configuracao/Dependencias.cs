
namespace PublishMan.Core.Configuracao
{
    public static class Dependencias
    {
        public static void Resolve(IContainer container)
        {
            container.Register<Gerenciadores.IArquivo, Gerenciadores.Arquivo>();
            container.Register<IArquivosAdapter, ArquivosAdapter>();
        }
    }
}
