using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_GenericTypesCollections.Models
{
    internal class Library<T>
    {
        public List<T> Item { get; set; }
        public string Name { get; set; }
        public Library(string name)
        {
            Name = name;
            Item = new List<T>();
        }
        public void Add(T item)
        {
            Item.Add(item);
            Console.WriteLine("elave edildi");
        }
        public void Remove(T item)
        {
            Item.Remove(item);
            Console.WriteLine("silindi");
        }
        public List<T> GetAll()
        {
            return Item;
        }
        public int Count()
        {
            return Item.Count;
        }
        public T FindByIndex(int index)
        {
            if (index >= 0 && index < Item.Count)
            {
                return Item[index];
            }
            else
            {
                Console.WriteLine("Index siyahının hüdudlarından kenardadır!");
                return default(T);
            }  
        }
    }
}
