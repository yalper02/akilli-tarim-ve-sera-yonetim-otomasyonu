using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using SmartAgri.Entities;
using SmartAgri.Business;

namespace SmartAgri.UI
{
    public partial class MainForm : XtraForm
    {
        private GreenhouseManager _greenhouseManager;
        private int _selectedGreenhouseId = 0; // Seçilen seranın ID'sini burada tutacağız.

        // Eksik olan ve hata veren değişken tanımlarını buraya ekliyoruz:
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;

        private SimpleButton simpleButton1;
        private TextEdit txtGreenhouseName;
        private TextEdit txtLocation;
        private SimpleButton btnSave;

        public MainForm()
        {
            InitializeComponent();
            _greenhouseManager = new GreenhouseManager();

            this.Text = "Akıllı Tarım Yönetim Sistemi - Seralar";
            this.Size = new Size(910, 520);

            SetupComponents();
        }

        private void simpleButton1_Click(object? sender, EventArgs e)
        {
            try
            {
                var list = _greenhouseManager.GetAllGreenhouses();

                // Eğer veritabanında hiç sera yoksa test amaçlı 1 tane sera ekleyelim
                if (list.Count == 0)
                {
                    _greenhouseManager.AddGreenhouse(new Greenhouse
                    {
                        Name = "A Blok Otomatik Sera",
                        Location = "Merkez Kampüs"
                    });

                    // Tekrar güncel listeyi çekelim
                    list = _greenhouseManager.GetAllGreenhouses();
                }

                // GridControl'e veriyi bağlayalım
                gridControl1.DataSource = list;
                gridControl1.RefreshDataSource();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Veriler çekilirken bir hata oluştu: " + ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            try
            {
                // GreenhouseManager'ın null olup olmadığını garantiye alalım
                if (_greenhouseManager == null)
                {
                    _greenhouseManager = new GreenhouseManager();
                }

                // 1. GridControl üzerinde o an seçili olan satırı yakalıyoruz
                var selectedGreenhouse = gridView1.GetFocusedRow() as Greenhouse;

                if (selectedGreenhouse == null)
                {
                    XtraMessageBox.Show(
                        "Lütfen silmek istediğiniz serayı tablodan seçin!",
                        "Uyarı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // 2. Kullanıcıya silme işlemi için onay soralım
                var confirm = XtraMessageBox.Show(
                    $"'{selectedGreenhouse.Name}' adlı serayı silmek istediğinize emin misiniz?",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    // 3. Business katmanı üzerinden silme işlemini gerçekleştiriyoruz
                    bool result = _greenhouseManager.DeleteGreenhouse(selectedGreenhouse.Id);

                    if (result)
                    {
                        XtraMessageBox.Show(
                            "Sera başarıyla silindi!",
                            "Başarılı",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // 4. Tabloyu güncel liste ile yeniliyoruz
                        gridControl1.DataSource = _greenhouseManager.GetAllGreenhouses();
                        gridControl1.RefreshDataSource();
                    }
                }
            }
            catch (Exception ex)
            {
                // Hatanın detayını tam olarak görmek için ex.ToString() yazdıralım
                XtraMessageBox.Show(
                    "Silme işlemi sırasında bir hata oluştu: " + ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_selectedGreenhouseId == 0)
                {
                    XtraMessageBox.Show(
                        "Lütfen tablodan güncellemek istediğiniz bir sera seçin!",
                        "Uyarı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                string name = txtGreenhouseName.Text.Trim();
                string location = txtLocation.Text.Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(location))
                {
                    XtraMessageBox.Show(
                        "Sera adı ve konum alanları boş bırakılamaz!",
                        "Uyarı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Güncellenecek nesneyi oluşturuyoruz
                var updatedGreenhouse = new Greenhouse
                {
                    Id = _selectedGreenhouseId,
                    Name = name,
                    Location = location
                };

                bool result = _greenhouseManager.UpdateGreenhouse(updatedGreenhouse);

                if (result)
                {
                    XtraMessageBox.Show(
                        "Sera başarıyla güncellendi!",
                        "Başarılı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Tabloyu tazele
                    gridControl1.DataSource = _greenhouseManager.GetAllGreenhouses();
                    gridControl1.RefreshDataSource();

                    // Alanları sıfırla
                    _selectedGreenhouseId = 0;
                    txtGreenhouseName.Text = string.Empty;
                    txtLocation.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    "Güncelleme sırasında bir hata oluştu: " + ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SetupComponents()
        {
            // --- 1. LİSTELEME BUTONU ---
            simpleButton1 = new SimpleButton();
            simpleButton1.Text = "Seraları Listele";
            simpleButton1.Location = new Point(12, 12);
            simpleButton1.Size = new Size(115, 25);
            simpleButton1.Click += simpleButton1_Click;
            this.Controls.Add(simpleButton1);

            // --- 2. SERA ADI GİRİŞ KUTUSU ---
            var lblName = new Label();
            lblName.Text = "Sera Adı:";
            lblName.Location = new Point(138, 16);
            lblName.AutoSize = true;
            this.Controls.Add(lblName);

            txtGreenhouseName = new TextEdit();
            txtGreenhouseName.Location = new Point(195, 12);
            txtGreenhouseName.Size = new Size(120, 22);
            this.Controls.Add(txtGreenhouseName);

            // --- 3. KONUM GİRİŞ KUTUSU ---
            var lblLocation = new Label();
            lblLocation.Text = "Konum:";
            lblLocation.Location = new Point(325, 16);
            lblLocation.AutoSize = true;
            this.Controls.Add(lblLocation);

            txtLocation = new TextEdit();
            txtLocation.Location = new Point(375, 12);
            txtLocation.Size = new Size(120, 22);
            this.Controls.Add(txtLocation);

            // --- 4. SERA EKLE BUTONU ---
            btnSave = new SimpleButton();
            btnSave.Text = "Sera Ekle";
            btnSave.Location = new Point(510, 11);
            btnSave.Size = new Size(85, 25);
            btnSave.Click += btnSave_Click;
            this.Controls.Add(btnSave);

            // --- 6. SERA SİL BUTONU ---
            var btnDelete = new SimpleButton();
            btnDelete.Text = "Sera Sil";
            btnDelete.Location = new Point(602, 11);
            btnDelete.Size = new Size(85, 25);
            btnDelete.Click += btnDelete_Click;
            this.Controls.Add(btnDelete);

            // --- 7. SERA GÜNCELLE BUTONU ---
            var btnUpdate = new SimpleButton();
            btnUpdate.Text = "Sera Güncelle";
            btnUpdate.Location = new Point(694, 11);
            btnUpdate.Size = new Size(95, 25);
            btnUpdate.Click += btnUpdate_Click;
            this.Controls.Add(btnUpdate);

            // --- 8. GRIDCONTROL AYARLARI ---
            gridControl1 = new GridControl();
            gridControl1.Location = new Point(12, 55);
            gridControl1.Size = new Size(875, 410);

            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView(gridControl1);
            gridControl1.MainView = gridView1;
            gridControl1.ViewCollection.Add(gridView1);

            gridControl1.Click += gridControl1_Click;
            this.Controls.Add(gridControl1);
        }
    }
}