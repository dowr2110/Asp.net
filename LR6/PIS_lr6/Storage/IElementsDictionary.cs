using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IElementsDictionary<T>
    {
        List<T> GetElements();

        void AddElement(T element);
        void UpdateElement(T element);
        void DeleteElement(int id);
    }
}
