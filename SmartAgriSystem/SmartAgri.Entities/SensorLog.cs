namespace SmartAgri.Entities
{
    public class SensorLog : BaseEntity 
    {
        public int GreenhouseId { get; set; } // Hangi seranın verisi (Foreign Key)
        public double Temperature { get; set; } // Ölçülen Sıcaklık
        public double Humidity { get; set; } // Ölçülen Nem
        public DateTime Timestap { get; set; } // Ölçüm Zamanı

        // İlişkisel bağ
        public virtual Greenhouse Greenhouse { get; set; }
    }
}