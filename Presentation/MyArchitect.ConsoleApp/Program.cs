

using Microsoft.EntityFrameworkCore;
using MyArchitect.Persistence;

namespace MyArchitect.ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            DbContextOptionsBuilder<OnionContext> optionsBuilder = new DbContextOptionsBuilder<OnionContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-5QUPQUE\\SQLEXPRESS;Initial Catalog=OnionArchitect;Integrated Security=true;");
            OnionContext ctx = new OnionContext(optionsBuilder.Options);
            var categories = ctx.Categories.ToList();
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Id}-{category.Name}");
            }

            Console.ReadKey();
        }
    }
}

