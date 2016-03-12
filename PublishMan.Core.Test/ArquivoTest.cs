using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PublishMan.Core.Test
{
    [TestClass]
    public class ArquivoTest
    {
        public const string origem = @"C:\publishMan\root1\";
        public const string destino = @"C:\publishMan\root2\";
        public Gerenciadores.Arquivo gerenciador = new Gerenciadores.Arquivo();

        [TestInitialize]
        public void CriaDiretorioOrigem()
        {
            Directory.CreateDirectory(origem);
        }

        [TestMethod]
        public void DeveCopiarArquivo()
        {
            var arquivo = "arquivo.txt";
            File.CreateText(origem + arquivo).Dispose();

            gerenciador.Copia(origem, destino, arquivo);

            Assert.IsTrue(File.Exists(Path.Combine(destino, arquivo)));
        }

        [TestMethod]
        public void DeveCopiarTodosOsArquivos()
        {
            CriaArquivos(origem, 10);

            gerenciador.Copia(origem, destino);

            Assert.AreEqual(Directory.GetFiles(origem).Length, Directory.GetFiles(destino).Length);
        }

        [TestMethod]
        public void DeveCopiarDiretorio()
        {
            Directory.CreateDirectory(Path.Combine(origem, "diretorio"));

            gerenciador.Copia(origem, destino);

            Assert.IsTrue(Directory.Exists(destino));
        }

        [TestMethod]
        public void DeveCopiarTodosOsDiretorios()
        {
            CriaDiretorios(origem, 10);

            gerenciador.Copia(origem, destino);

            Assert.AreEqual(Directory.GetDirectories(origem).Length, Directory.GetDirectories(destino).Length);
        }

        [TestMethod]
        public void DeveCopiarRecursivamente()
        {
            var arquivo = "arquivo.txt";
            var caminho = origem;
            for (var x = 0; x < 10; x++)
            {
                caminho = Path.Combine(caminho, "diretorio");
                Directory.CreateDirectory(caminho);
                File.CreateText(Path.Combine(caminho, arquivo)).Dispose();
            }

            gerenciador.Copia(origem, destino);

            caminho = origem;
            for (var x = 0; x < 10; x++)
            {
                caminho = Path.Combine(caminho, "diretorio");
                Assert.IsTrue(Directory.Exists(caminho));
                Assert.IsTrue(File.Exists(Path.Combine(caminho, arquivo)));
            }
        }

        [TestMethod]
        public void DeveListarArquivoPorExtensao()
        {
            CriaArquivos(origem, 2);

            var arquivos = gerenciador.ObtemPorExtensao(origem, "txt");

            Assert.AreEqual(2, arquivos.Count);
        }

        [TestMethod]
        public void DeveListarArquivoPorExtensaoRecursivamente()
        {
            var arquivo = "arquivo.txt";
            var caminho = origem;
            for (var x = 0; x < 10; x++)
            {
                caminho = Path.Combine(caminho, "diretorio");
                Directory.CreateDirectory(caminho);
                File.CreateText(Path.Combine(caminho, arquivo)).Dispose();
            }

            var arquivos = gerenciador.ObtemPorExtensao(origem, "txt");

            Assert.AreEqual(10, arquivos.Count);
        }

        [TestCleanup]
        public void LimpaDiretorios()
        {
            if (Directory.Exists(origem))
                Directory.Delete(origem, true);
            if (Directory.Exists(destino))
                Directory.Delete(destino, true);
        }

        public void CriaDiretorios(string origem, byte quantidade)
        {
            for (var x = 0; x < 10; x++)
                Directory.CreateDirectory(Path.Combine(origem, "diretorio" + x));
        }

        public void CriaArquivos(string origem, byte quantidade)
        {
            for (var x = 0; x < quantidade; x++)
                File.CreateText(Path.Combine(origem, "arquivo" + x + ".txt")).Dispose();
        }
    }
}
