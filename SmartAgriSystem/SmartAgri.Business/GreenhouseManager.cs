using SmartAgri.DataAccess;
using SmartAgri.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartAgri.Business
{
    public class GreenhouseManager
    {
        // 1. READ (Listeleme)
        public List<Greenhouse> GetAllGreenhouses()
        {
            using (var db = new AppDbContext())
            {
                return db.Greenhouses.ToList();
            }
        }

        // 2. CREATE (Ekleme)
        public bool AddGreenhouse(Greenhouse greenhouse)
        {
            if (string.IsNullOrWhiteSpace(greenhouse.Name))
                throw new ArgumentException("Sera adı boş bırakılamaz!");

            using (var db = new AppDbContext())
            {
                db.Greenhouses.Add(greenhouse);
                return db.SaveChanges() > 0;
            }
        }

        // 3. DELETE (Silme)
        public bool DeleteGreenhouse(int id)
        {
            using (var db = new AppDbContext())
            {
                var greenhouse = db.Greenhouses.Find(id);
                if (greenhouse != null)
                {
                    db.Greenhouses.Remove(greenhouse);
                    return db.SaveChanges() > 0;
                }
                return false;
            }
        }

        // 4. UPDATE (Güncelleme)
        public bool UpdateGreenhouse(Greenhouse greenhouse)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var existingGreenhouse = context.Greenhouses.Find(greenhouse.Id);
                    if (existingGreenhouse != null)
                    {
                        existingGreenhouse.Name = greenhouse.Name;
                        existingGreenhouse.Location = greenhouse.Location;

                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}