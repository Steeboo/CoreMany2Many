using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreMany2Many
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1. Create records");
            Console.WriteLine("2. Update record geel");
            Console.WriteLine("3. Update record rood");
            var key = Console.ReadKey().KeyChar;

            using (var c = new AppDbContext())
            {
                switch (key)
                {
                    case '1':
                        var product = new Product() { Name = "Product1" };
                        var geel = new Color() { Name = "Geel" };
                        var rood = new Color() { Name = "Rood" };

                        c.Colors.Add(geel);
                        c.Colors.Add(rood);
                        c.Products.Add(product);
                        break;
                    case '2':
                        var product1 = c.Products.Include(x => x.ProductColors).First();
                        product1.ProductColors.Clear();
                        c.SaveChanges();
                                                                   
                        product1.ProductColors.Add(new ProductColor() { ColorId = 1, ProductId = 1 });
                        break;
                    case '3':
                        var product2 = c.Products.Include(x => x.ProductColors).First();
                        product2.ProductColors.Clear();
                        c.SaveChanges();
                                                                
                        product2.ProductColors.Add(new ProductColor() { ColorId = 2, ProductId = 1 });
                        break;
                    default:
                        return;
                }
                c.SaveChanges();
            }

            Console.WriteLine("Done");
        }
    }
}
