using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class Telephone : IComparable
    {
        private static int index = 0;

        private int id = 0;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                index = value > index ? value : index;
                id = value;
            }
        }
        public string Surname { get; set; }
        public string Phone_number { get; set; }


        public Telephone() { }

        public Telephone(string name, string phone_number)
        {
            this.Id = ++index;
            this.Surname = name;
            this.Phone_number = phone_number;
        }

        public Telephone(int id, string name, string phone_number)
        {
            this.Id = id;
            this.Surname = name;
            this.Phone_number = phone_number;
        }

        public int CompareTo(object obj)
        {
            Telephone e = obj as Telephone;
            return this.Surname.CompareTo(e.Surname);
        }
    }
}
