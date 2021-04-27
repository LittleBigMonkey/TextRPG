using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Storage<T> : Dictionary<T, int> where T : Item
    {
        public T this[string name] => GetItemByName(name);

        private T GetItemByName(string name) => Keys.FirstOrDefault(Item => Item.name == name);

        public void Add(T item)
        {
            if (this.ContainsKey(item)) this[item]++;
            else this.Add(item, 1);
        }

        public bool Remove(string name) => Remove(GetItemByName(name));

        public new bool Remove(T item)
        {
            if (!this.ContainsKey(item)) return false;

            if (this[item] > 1) this[item]--;
            else base.Remove(item);

            return true;
        }
    }
}
