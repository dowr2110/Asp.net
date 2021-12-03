using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PIS_lr3.Models
{
    public class TelephoneDictionary
    {
        private List<Telephone> m_Telephones = new List<Telephone>();
        private static string m_DataBaseFilePath = @"C:\Users\gunko\OneDrive\study\6th_sem\ProgrammingInternetServers\Лабораторная_работа_03_MVC_1\PIS_lr3\PIS_lr3\App_Data\Data.json";

        public TelephoneDictionary()
        {
            /*m_Telephones.Add(new Telephone { Surname = "Hunko", Number = "80291234567" });
            m_Telephones.Add(new Telephone { Surname = "Petrov", Number = "80297654321" });
            m_Telephones.Add(new Telephone { Surname = "Sidorov", Number = "80337162534" });*/
        }

        public List<Telephone> GetAll()
        {
            string json_string = File.ReadAllText(m_DataBaseFilePath);
            m_Telephones = JsonConvert.DeserializeObject<List<Telephone>>(json_string);
            return m_Telephones.OrderBy(u => u.Surname).ToList();
        }

        public void Insert(string surname, string number)
        {
            m_Telephones = GetAll();
            int id = 0;
            foreach (Telephone telephone in m_Telephones)
            {
                if (telephone.Id > id)
                {
                    id = telephone.Id;
                }
            }
            m_Telephones.Add(new Telephone { Id = id + 1, Surname = surname, Number = number });

            UpdateDataInFile(m_Telephones);
        }

        public void Update(int id, string surname, string number)
        {
            m_Telephones = GetAll();
            int index = m_Telephones.IndexOf(m_Telephones.Find(x => x.Id == id));
            m_Telephones[index].Surname = surname;
            m_Telephones[index].Number = number;

            UpdateDataInFile(m_Telephones);
        }

        public void Delete(int id)
        {
            m_Telephones = GetAll();
            Telephone removed = m_Telephones.Find(x => x.Id == id);
            m_Telephones.Remove(removed);

            UpdateDataInFile(m_Telephones);
        }

        private void UpdateDataInFile(List<Telephone> inTelephones)
        {
            File.WriteAllText(m_DataBaseFilePath, JsonConvert.SerializeObject(inTelephones));
        }
    }
}