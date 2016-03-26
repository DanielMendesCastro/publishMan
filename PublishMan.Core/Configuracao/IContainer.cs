namespace PublishMan.Core.Configuracao
{
    public interface IContainer
    {
        void Register<TService, TImplementation>() where TService : class where TImplementation : class, TService;
    }
}
