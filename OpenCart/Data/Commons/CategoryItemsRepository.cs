using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Data.Commons
{
    public sealed class CategoryItemsRepository
    {
        private CategoryItemsRepository() { }

        public static CategoryItems Desktops()
        {
            CategoryItems categoryItems = new CategoryItems("Desktops");
            categoryItems.AddItem(new ElementItem("PC", 0));
            categoryItems.AddItem(new ElementItem("Mac", 1));
            return categoryItems;
        }

        public static CategoryItems Software()
        {
            CategoryItems categoryItems = new CategoryItems("Software");
            categoryItems.AddItem(new ElementItem("Apple", 1));
            categoryItems.AddItem(new ElementItem("Microsoft", 1));
            categoryItems.AddItem(new ElementItem("Other", 2));
            return categoryItems;
        }

        public static List<CategoryItems> GetAll()
        {
            List<CategoryItems> result = new List<CategoryItems>();
            result.Add(Desktops());
            result.Add(Software());
            // TODO Add All CategoryItems
            return result;
        }

    }
}
