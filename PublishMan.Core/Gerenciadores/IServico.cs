using System.Collections.Generic;
using System.ServiceProcess;

namespace PublishMan.Core.Gerenciadores
{
    public interface IServico
    {
        List<ServiceController> Obtem();
        ServiceController Obtem(string nome);
    }
}
