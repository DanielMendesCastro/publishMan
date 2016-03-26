using PublishMan.Core.Configuracao;

namespace PublishMan.UI
{
    public class Container : IContainer
    {
        private readonly SimpleInjector.Container _container;

        public Container(SimpleInjector.Container container)
        {
            _container = container;
        }

        void IContainer.Register<TService, TImplementation>()
        {
            _container.Register<TService, TImplementation>();
        }
    }
}
