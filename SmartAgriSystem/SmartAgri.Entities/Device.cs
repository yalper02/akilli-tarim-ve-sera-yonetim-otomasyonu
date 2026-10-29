namespace SmartAgri.Entities
{
    public class Device : BaseEntity
    {
        public int GreenhouseId { get; set; } // Hangi seraya ait (Foreign Key)
        public string DeviceName { get; set; } // Örn: Sıcaklık Sensörü, Sulama Vanası
        public bool IsActive { get; set; } // Çalışıp çalışmadığını belirtir

        // İlişkisel bağ
        public virtual Greenhouse Greenhouse { get; set; }
    }
}