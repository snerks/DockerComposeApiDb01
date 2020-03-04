using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace DockerComposeApiDb01.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ColourContext>());
            }
        }

        public static void SeedData(ColourContext context)
        {
            System.Console.WriteLine("SeedData - START");

            System.Console.WriteLine("Applying migration - BEFORE");

            context.Database.Migrate();

            System.Console.WriteLine("Applying migration - AFTER");

            if (!context.ColourItems.Any())
            {
                System.Console.WriteLine("Adding data - BEFORE");

                context.ColourItems.AddRange(
                    new Colour { ColourName = "Red" },
                    new Colour { ColourName = "Orange" },
                    new Colour { ColourName = "Yellow" },
                    new Colour { ColourName = "Green" },
                    new Colour { ColourName = "Blue" }
                );

                System.Console.WriteLine("SeedData:BEFORE");

                var recordsAffectedCount = context.SaveChanges();

                System.Console.WriteLine("SeedData:AFTER");
                System.Console.WriteLine($"SeedData:AFTER:recordsAffectedCount=[{recordsAffectedCount}]");

                System.Console.WriteLine("Adding data - AFTER");

            }
            else
            {
                System.Console.WriteLine("Already have data...");
            }

            System.Console.WriteLine("SeedData - END");
        }
    }
}