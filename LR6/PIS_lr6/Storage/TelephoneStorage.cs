using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Storage
{
    public class TelephoneStorage : IElementsDictionary<Telephone>
    {
        List<Telephone> telephones;
        static string json_path = @"C:\Довр\ФИТ\4 КУРС\7 сем\программирование в интеернет(ПИ)\лабораторные работы\LR6\PIS_lr6\PIS_lr6\App_Data\Data.json";

        public TelephoneStorage()
        {
            System.Diagnostics.Debug.WriteLine("hi");
        }

        public List<Telephone> GetElements()
        {
            string json_string = File.ReadAllText(json_path);
            telephones = JsonConvert.DeserializeObject<List<Telephone>>(json_string);
            return telephones.OrderBy(u => u.Surname).ToList();
        }

        public void AddElement(Telephone newTelephone)
        {
            telephones = GetElements();
            int max_id = telephones.Max(t => t.Id);
            telephones.Add(new Telephone { Id = max_id + 1, Surname = newTelephone.Surname, Phone_number = newTelephone.Phone_number });

            UpdateDataInFile(telephones);
        }

        public void UpdateElement(Telephone updatedTelephone)
        {
            telephones = GetElements();
            int index = telephones.IndexOf(telephones.Find(x => x.Id == updatedTelephone.Id));
            telephones[index].Surname = updatedTelephone.Surname;
            telephones[index].Phone_number = updatedTelephone.Phone_number;


            UpdateDataInFile(telephones);
        }

        public void DeleteElement(int id)
        {
            telephones = GetElements();
            Telephone removed = telephones.Find(x => x.Id == id);
            telephones.Remove(removed);

            UpdateDataInFile(telephones);
        }

        private void UpdateDataInFile(List<Telephone> inTelephones)
        {
            File.WriteAllText(json_path, JsonConvert.SerializeObject(inTelephones));
        }
    }
}
