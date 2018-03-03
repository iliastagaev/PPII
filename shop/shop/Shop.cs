using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class Shop
    {
        public List<Product> list;
        public Shop(List<Product> list)
        {
            this.list = list;
        }
        public  void AddProduct(Product a)
        {
            list.Add(a);
        }
        public void Remove(int i)
        {
            list.RemoveAt(i);
        }
    }
}
