using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PublishMan.Core.Test
{
    [TestClass]
    public class ArquivoTest
    {
        public const string Origem = @"C:\root1\";
        public const string Destino = @"C:\root2\";
        public Gerenciadores.Arquivo Gerenciador = new Gerenciadores.Arquivo();

        [TestInitialize]
        public void CriaDiretorioOrigem()
        {
            Directory.CreateDirectory(Origem);
        }

        [TestMethod]
        public void DeveCopiarArquivo()
        {
            const string arquivo = "arquivo.txt";
            File.CreateText(Origem + arquivo).Dispose();

            Gerenciador.Copia(Origem, Destino, arquivo);

            Assert.IsTrue(File.Exists(Path.Combine(Destino, arquivo)));
        }

        [TestMethod]
        public void DeveCopiarTodosOsArquivos()
        {
            CriaArquivos(Origem, 10);

            Gerenciador.Copia(Origem, Destino);

            Assert.AreEqual(Directory.GetFiles(Origem).Length, Directory.GetFiles(Destino).Length);
        }

        [TestMethod]
        public void DeveCopiarDiretorio()
        {
            Directory.CreateDirectory(Path.Combine(Origem, "diretorio"));

            Gerenciador.Copia(Origem, Destino);

            Assert.IsTrue(Directory.Exists(Destino));
        }

        [TestMethod]
        public void DeveCopiarTodosOsDiretorios()
        {
            CriaDiretorios(Origem, 10);

            Gerenciador.Copia(Origem, Destino);

            Assert.AreEqual(Directory.GetDirectories(Origem).Length, Directory.GetDirectories(Destino).Length);
        }

        [TestMethod]
        public void DeveCopiarRecursivamente()
        {
            const string arquivo = "arquivo.txt";
            var caminho = Origem;
            for (var x = 0; x < 10; x++)
            {
                caminho = Path.Combine(caminho, "diretorio");
                Directory.CreateDirectory(caminho);
                File.CreateText(Path.Combine(caminho, arquivo)).Dispose();
            }

            Gerenciador.Copia(Origem, Destino);

            caminho = Origem;
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
            CriaArquivos(Origem, 2);

            var arquivos = Gerenciador.ObtemPorExtensao(Origem, "txt");

            Assert.AreEqual(2, arquivos.Count);
        }

        [TestMethod]
        public void DeveListarArquivoPorExtensaoRecursivamente()
        {
            const string arquivo = "arquivo.txt";
            var caminho = Origem;
            for (var x = 0; x < 10; x++)
            {
                caminho = Path.Combine(caminho, "diretorio");
                Directory.CreateDirectory(caminho);
                File.CreateText(Path.Combine(caminho, arquivo)).Dispose();
            }

            var arquivos = Gerenciador.ObtemPorExtensao(Origem, "txt");

            Assert.AreEqual(10, arquivos.Count);
        }

        [TestCleanup]
        public void LimpaDiretorios()
        {
            if (Directory.Exists(Origem))
                Directory.Delete(Origem, true);
            if (Directory.Exists(Destino))
                Directory.Delete(Destino, true);
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
