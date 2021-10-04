using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LR3.Models
{
    public class SpravochnikDict
    {
        private List<Spravocnik> m_Telephones = new List<Spravocnik>();
        private static string m_DataBaseFilePath = @"C:\Довр\ФИТ\4 КУРС\7 сем\программирование в интеернет(ПИ)\лабораторные работы\LR3\LR3\App_Data\Data.json";

        public SpravochnikDict()
        {
            
        }

        public List<Spravocnik> GetAll()
        {
            string json_string = File.ReadAllText(m_DataBaseFilePath);
            m_Telephones = JsonConvert.DeserializeObject<List<Spravocnik>>(json_string);
            return m_Telephones.OrderBy(u => u.surname).ToList();
        }

        public void Insert(string surname, string number)
        {
            m_Telephones = GetAll();
            int id = 0;
            foreach (Spravocnik sp in m_Telephones)
            {
                if (sp.id > id)
                {
                    id = sp.id;
                }
            }
            m_Telephones.Add(new Spravocnik { id = id + 1, surname = surname, phone_number = number });

            UpdateDataInFile(m_Telephones);
        }

        public void Update(int id, string surname, string number)
        {
            m_Telephones = GetAll();
            foreach (Spravocnik sp in m_Telephones)
            {
                if (sp.id == id)
                {
                    sp.surname = surname;
                    sp.phone_number = number;
                }

            }
            UpdateDataInFile(m_Telephones);
        }

        public void Delete(int id)
        {
            /*  m_Telephones = GetAll();
              Spravocnik removed = new Spravocnik();
              foreach (Spravocnik sp in m_Telephones)
              {
                  if (sp.id == id)
                  {
                      removed.id = id;
                      removed.surname = sp.surname;
                      removed.phone_number = sp.phone_number;
                  } 
              }
              m_Telephones.Remove(removed);
              UpdateDataInFile(m_Telephones);*/

            m_Telephones = GetAll();
            Spravocnik removed = m_Telephones.Find(x => x.id == id);
            m_Telephones.Remove(removed);

            UpdateDataInFile(m_Telephones);
        }

        private void UpdateDataInFile(List<Spravocnik> inTelephones)
        {
            File.WriteAllText(m_DataBaseFilePath, JsonConvert.SerializeObject(inTelephones));
        }
    }
}