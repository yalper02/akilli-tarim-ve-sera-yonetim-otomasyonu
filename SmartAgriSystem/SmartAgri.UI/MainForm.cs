using System;
using SmartAgri.Business;

namespace SmartAgri.UI
{
    public partial class MainForm : Form
    {
        private GreenhouseManager _greenhouseManager;

        public MainForm()
        {
            InitializeComponent();
            _greenhouseManager = new GreenhouseManager();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource = _greenhouseManager.GetAllGreenhouses();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Business katmanından seraları çekip GridControl'e bağlıyoruz
            dataGridView1.DataSource = _greenhouseManager.GetAllGreenhouses();
        }
    }
}