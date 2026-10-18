# \# Akıllı Tarım ve Sera Yönetim Otomasyonu

# 

# Fırat Üniversitesi Dönem Projesi

# 

# Bu proje, modern seralardaki ve tarım alanlarındaki çevresel koşulları izlemek ve otomatize etmek amacıyla geliştirilen bir dönem projesidir.

# 

# \## 🎯 Projenin Amacı

# 

# Tarım süreçlerini dijitalleştirerek kaynak verimliliğini artırmak, sera içi iklimlendirme ve sulama süreçlerini optimize etmek.

# 

# \## 🛠️ Kullanılan Teknolojiler

# \- \*\*Geliştirme Ortamı:\*\* Visual Studio \& C# (.NET)

# \- \*\*Arayüz Bileşenleri:\*\* DevExpress

# \- \*\*Veritabanı:\*\* SQLite

# \- \*\*Sürüm Kontrolü:\*\* Git \& GitHub

# \- \*\*Yapay Zeka:\*\* Google Gemini API

# 

# \## 🚀 Kurulum ve Çalıştırma Adımları

# 

# Projeyi kendi bilgisayarınızda yerel ortamınızda çalıştırmak için şu adımları izleyebilirsiniz:

# 

# 1\. \*\*Depoyu Klonlayın:\*\*

# bash git clone https://github.com/yalper02/akilli-tarim-ve-sera-yonetim-otomasyonu.git

# 

# 2\. \*\*Konfigürasyon Dosyasını Oluşturun:\*\*

# \- Proje ana dizininde bulunan `appsettings.example.json` dosyasını kopyalayın ve aynı dizine adını \*\*`appsettings.json`\*\* yaparak yapıştırın.

# \- `appsettings.json` dosyasını açarak kendi \*\*Google Gemini API anahtarınızı\*\* ilgili alana ekleyin:

# json

# {

# "ConnectionStrings": {

# "DefaultConnection": "Data Source=tarim.db;"

# },

# "ApiSettings": {

# "GeminiApiKey": "BURAYA\_GERCEK\_API\_ANAHTARINIZI\_YAZIN"

# }

# } 

# 

# \*(Not: `appsettings.json` dosyası `.gitignore` ile korunduğu için GitHub'a yüklenmez, güvenliğiniz altındadır.)\*

# 

# 3\. \*\*Projeyi Visual Studio ile Açın:\*\*

# \- Visual Studio uygulamasını açın ve projenizin alt klasöründe bulunan `.csproj` uzantılı dosya ile projeyi yükleyin.

# 

# 4\. \*\*Çalıştırın:\*\*

# \- Visual Studio üzerinde \*\*F5\*\* tuşuna basarak veya \*\*Start\*\* butonuna tıklayarak uygulamayı çalıştırın. SQLite veritabanı otomatik olarak oluşturulacaktır.





