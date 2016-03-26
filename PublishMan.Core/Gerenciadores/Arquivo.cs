using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace PublishMan.Core.Gerenciadores
{
    public class Arquivo : IArquivo
    {
        public void Copia(string origem, string destino)
        {
            CriaDiretorio(destino);

            foreach (var arquivo in Directory.GetFiles(origem).Where(arquivo => arquivo != null))
                File.Copy(arquivo, Path.Combine(destino, Path.GetFileName(arquivo)), true); 

            //chamada recursiva para copiar todos os diretórios e arquivos
            foreach (var diretorio in Directory.GetDirectories(origem).Where(diretorio => diretorio != null))
                Copia(diretorio, Path.Combine(destino, Path.GetFileName(diretorio))); 
        }

        public void Copia(string origem, string destino, string arquivo)
        {
            CriaDiretorio(destino);
            File.Copy(origem + arquivo, destino + arquivo);
        }

        private static void CriaDiretorio(string diretorio)
        {
            if (!Directory.Exists(diretorio))
                Directory.CreateDirectory(diretorio);
        }

        public IList<string> ObtemPorExtensao(string caminho, string extensao)
        {
            var arquivos = Directory.GetFiles(caminho, "*." + extensao).ToList();

            //chamada recursiva para pegar todos os arquivos
            foreach (var diretorio in Directory.GetDirectories(caminho).Where(diretorio => diretorio != null))
                arquivos.AddRange(ObtemPorExtensao(Path.Combine(caminho, Path.GetFileName(diretorio)), extensao));

            return arquivos;
        }
    }
}
