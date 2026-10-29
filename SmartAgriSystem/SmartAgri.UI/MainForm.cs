using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using SmartAgri.Business;

namespace SmartAgri.UI
{
    public partial class MainForm : XtraForm
    {
        private GreenhouseManager _greenhouseManager;
        private GridControl gridControl1;
        private SimpleButton simpleButton1;

        public MainForm()
        {
            InitializeComponent();
            _greenhouseManager = new GreenhouseManager();

            this.Text = "Akıllı Tarım Yönetim Sistemi - Seralar";
            this.Size = new Size(800, 500);

            SetupComponents();
        }

        private void SetupComponents()
        {
            // GridControl Ayarları
            gridControl1 = new GridControl();
            gridControl1.Location = new Point(12, 60);
            gridControl1.Size = new Size(760, 380);

            // GridView'i manuel olarak ekleyip GridControl'e bağlıyoruz
            DevExpress.XtraGrid.Views.Grid.GridView gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView(gridControl1);
            gridControl1.MainView = gridView1;
            gridControl1.ViewCollection.Add(gridView1);

            this.Controls.Add(gridControl1);

            // SimpleButton Ayarları
            simpleButton1 = new SimpleButton();
            simpleButton1.Text = "Seraları Listele";
            simpleButton1.Location = new Point(12, 12);
            simpleButton1.Size = new Size(130, 35);
            simpleButton1.Click += simpleButton1_Click;
            this.Controls.Add(simpleButton1);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Business katmanından seraları çekiyoruz
            var greenhouses = _greenhouseManager.GetAllGreenhouses();

            // GridControl'e bağlıyoruz
            gridControl1.DataSource = greenhouses;

            // Grid görünümünü yenileyerek verilerin ekrana çizilmesini zorluyoruz
            gridControl1.RefreshDataSource();
        }
    }
}