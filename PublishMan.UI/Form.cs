using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PublishMan.Core;

namespace PublishMan.UI
{
    public partial class Form : System.Windows.Forms.Form
    {
        private readonly IArquivosAdapter _arquivoAdapter;
        private readonly IServicosAdapter _servicosAdapter;

        private IList<Core.Entidades.Servico> _servicos;

        public Form(IArquivosAdapter arquivoAdapter, IServicosAdapter servicosAdapter)
        {
            _arquivoAdapter = arquivoAdapter;
            _servicosAdapter = servicosAdapter;
            InitializeComponent();
        }

        private void Form_Load(object sender, System.EventArgs e)
        {
            _servicos = _servicosAdapter.ObtemServicos();
            listaServicos.DataSource = _servicos;
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var servico = PegaServicoSelecionado();
            if (servico == null)
                return;
        }

        private Core.Entidades.Servico PegaServicoSelecionado()
        {
            return listaServicos.CurrentRow != null
                ? _servicos.First(x => x.Nome == listaServicos.CurrentRow.Cells[0].Value.ToString())
                : null;
        }
    }
}
