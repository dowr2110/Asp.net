using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class TelephoneStorageEF : DbContext, IElementsDictionary<Telephone>
    {
        public DbSet<Telephone> Telephones { get; set; }


        public TelephoneStorageEF() : base("TelephoneContextConnection")
        {

        }

        public List<Telephone> GetElements()
        {
            var telephones = Telephones;
            return telephones.OrderBy(t => t.Id).ToList();
        }

        public void AddElement(Telephone newTelephone)
        {

           
            if (Telephones.Count() == 0)
            {
                Telephones.Add(new Telephone { Id = 1, Surname = newTelephone.Surname, Phone_number = newTelephone.Phone_number }); 
            }
            else
            {
                int max_id = Telephones.Max(t => t.Id);
                Telephones.Add(new Telephone { Id = max_id + 1, Surname = newTelephone.Surname, Phone_number = newTelephone.Phone_number });
            }
            SaveChanges();
        }

        public void UpdateElement(Telephone updatedTelephone)
        {
            var telephones = Telephones.ToList();
            int index = telephones.IndexOf(telephones.Find(x => x.Id == updatedTelephone.Id));
            if (index != -1)
            {
                telephones[index].Surname = updatedTelephone.Surname;
                telephones[index].Phone_number = updatedTelephone.Phone_number;

                SaveChanges();
            }
        }

        public void DeleteElement(int id)
        {
            var telephones = this.Telephones.ToList();
            Telephone removed = telephones.Find(x => x.Id == id);
            if (removed != null)
            {
                this.Telephones.Remove(removed);
                this.SaveChanges();
            }
        }
    }
}
