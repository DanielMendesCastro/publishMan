using System.Windows.Forms;

namespace PublishMan.UI
{
    public partial class Form : System.Windows.Forms.Form
    {
        private readonly Core.IArquivosAdapter _arquivoAdapter;

        public Form(Core.IArquivosAdapter arquivoAdapter)
        {
            _arquivoAdapter = arquivoAdapter;
            InitializeComponent();
        }

        private void Form_Load(object sender, System.EventArgs e)
        {
            var servicos = _arquivoAdapter.ObtemServicos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
