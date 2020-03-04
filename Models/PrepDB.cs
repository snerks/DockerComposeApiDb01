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

            var maxIterationCount = 10;

            for (int i = 0; i < maxIterationCount; i++)
            {
                try
                {
                    System.Console.WriteLine($"SeedData - Applying migration - BEFORE - iterationCount = [{i}]");

                    context.Database.Migrate();

                    System.Console.WriteLine($"SeedData - Applying migration - AFTER - iterationCount = [{i}]");

                    break;
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"SeedData - Applying migration - Exception - START - iterationCount = [{i}]");

                    System.Console.WriteLine($"SeedData - Applying migration - Exception - [{ex}]");

                    System.Console.WriteLine($"SeedData - Applying migration - Exception - END - iterationCount = [{i}]");

                    System.Threading.Thread.Sleep(20000);
                }
            }

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
