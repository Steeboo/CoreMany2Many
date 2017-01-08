using System.Collections.Generic;

namespace CoreMany2Many
{
    public class Product
    {
        public Product()
        {
            ProductColors = new List<ProductColor>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<ProductColor> ProductColors { get; set; }
    }
}