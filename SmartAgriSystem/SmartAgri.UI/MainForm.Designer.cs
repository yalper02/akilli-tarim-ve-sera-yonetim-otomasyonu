
using DevExpress.XtraEditors;
using SmartAgri.Entities;

namespace SmartAgri.UI {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            // Tablodan seçilen satırdaki veriyi Greenhouse nesnesine cast ediyoruz
            var selectedGreenhouse = gridView1.GetFocusedRow() as Greenhouse;

            if (selectedGreenhouse != null)
            {
                _selectedGreenhouseId = selectedGreenhouse.Id;
                txtGreenhouseName.Text = selectedGreenhouse.Name;
                txtLocation.Text = selectedGreenhouse.Location;
                this.Text = "Seçilen Sera: " + selectedGreenhouse.Name;
            }
        }

        #endregion

        private void btnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                string name = txtGreenhouseName.Text.Trim();
                string location = txtLocation.Text.Trim();

                // Boş alan kontrolü
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(location))
                {
                    XtraMessageBox.Show(
                        "Lütfen sera adı ve konum alanlarını boş bırakmayın!",
                        "Uyarı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Yeni sera nesnesi oluşturup veritabanına ekleme
                var newGreenhouse = new Greenhouse
                {
                    Name = name,
                    Location = location
                };

                bool result = _greenhouseManager.AddGreenhouse(newGreenhouse);

                if (result)
                {
                    XtraMessageBox.Show(
                        "Sera başarıyla eklendi!",
                        "Başarılı",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Listeyi güncelle
                    gridControl1.DataSource = _greenhouseManager.GetAllGreenhouses();
                    gridControl1.RefreshDataSource();

                    // Kutuları temizle
                    txtGreenhouseName.Text = string.Empty;
                    txtLocation.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    "Kayıt eklenirken bir hata oluştu: " + ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
