using System.Collections.Generic;
using PublishMan.Core.Entidades;

namespace PublishMan.Core
{
    public interface IArquivosAdapter
    {
        IList<Servico> ObtemServicos();
    }
}
