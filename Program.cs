using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace demo_app
{
    public class Program
    {
        public static void Main(string[] args)
        {
             // добавление данных
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта User
                ApplicationUser user1 = new ApplicationUser { UserName = "Tom", Password = "Tom" };
                ApplicationUser user2 = new ApplicationUser { UserName = "Bob", Password = "Bob" };
 
                // добавляем их в бд
                db.Users.AddRange(user1, user2);
                db.SaveChanges();
            }
            // получение данных
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Users list:");
                foreach (ApplicationUser u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.UserName} - {u.Password}");
                }
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
