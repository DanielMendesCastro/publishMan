using System.Collections.Generic;

namespace PublishMan.Core.Gerenciadores
{
    public interface IArquivo
    {
        void Copia(string origem, string destino);

        void Copia(string origem, string destino, string arquivo);

        IList<string> ObtemPorExtensao(string caminho, string extensao);
    }
}
