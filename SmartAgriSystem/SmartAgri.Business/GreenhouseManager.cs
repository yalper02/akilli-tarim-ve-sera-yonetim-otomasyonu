using System.Collections.Generic;
using System.Linq;
using SmartAgri.DataAccess;
using SmartAgri.Entities;

namespace SmartAgri.Business
{
    public class GreenhouseManager
    {
        // Seraları Listeleme (Veritabanından çekme)
        public List<Greenhouse> GetAllGreenhouses()
        {
            using (var context = new AppDbContext())
            {
                return context.Greenhouses.ToList();
            }
        }

        // Yeni Sera Ekleme
        public void AddGreenhouse(Greenhouse greenhouse)
        {
            using (var context = new AppDbContext())
            {
                context.Greenhouses.Add(greenhouse);
                context.SaveChanges();
            }
        }
    }
}