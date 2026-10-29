using System.Collections.Generic;

namespace SmartAgri.Entities
{
    public class Greenhouse : BaseEntity
    {
        public string Name { get; set; } // Örn: 1 Nolu Domates Serası
        public string Location { get; set; } // Örn: Kampüs Alanı
        public double TargetTemperature { get; set; } // İdeal Sıcaklık

        // Navigation Property (Bir seranın birden fazla cihazı ve logu olabilir)
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<SensorLog> SensorLogs { get; set; }
    }
}