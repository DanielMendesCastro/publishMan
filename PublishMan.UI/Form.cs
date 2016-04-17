using System.Windows.Forms;
using PublishMan.Core;

namespace PublishMan.UI
{
    public partial class Form : System.Windows.Forms.Form
    {
        private readonly IArquivosAdapter _arquivoAdapter;
        private readonly IServicosAdapter _servicosAdapter;

        public Form(IArquivosAdapter arquivoAdapter, IServicosAdapter servicosAdapter)
        {
            _arquivoAdapter = arquivoAdapter;
            _servicosAdapter = servicosAdapter;
            InitializeComponent();
        }

        private void Form_Load(object sender, System.EventArgs e)
        {
            var servicos = _servicosAdapter.ObtemServicos();
            listaServicos.DataSource = servicos;
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
