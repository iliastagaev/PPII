using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class Product
    {
        public string s;
        public long value;
        public Product() { }
        public Product(string s, long value)
        {
            this.s = s;
            this.value = value;
        }
        public override string ToString()
        {
            return s.Substring(0 , s.IndexOf('.')) + ' ' + value;
        }
    }
}
