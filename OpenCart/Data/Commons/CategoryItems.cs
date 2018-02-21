using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data.Commons
{
    public class CategoryItems
    {
        public string Name { get; private set; }
        public List<ElementItem> ElementItems { get; private set; }
        public CategoryItems(string name)
        {
            this.Name = name;
            ElementItems = new List<ElementItem>();
        }

        public void AddItem(ElementItem elementItem)
        {
            ElementItems.Add(elementItem);
        }
    }
}
