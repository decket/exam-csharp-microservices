using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExamService.Models;

namespace ExamService.Data
{
    public static class PrepareDatabase
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }

            if (!context.SalesOrderDetails.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.SalesOrderDetails.AddRange(
                    new SalesOrderDetail()
                    {
                      SalesOrderId = 0,
                      SalesOrderDetailId = 0,
                      OrderQty = 1,
                      ProductId = 0,
                      SpecialOfferId = 0,
                      UnitPrice = 120,
                      UnitPriceDiscount = 20,
                      LineTotal = 's',
                      Rowguid = 0,
                      ModifiedDate = new DateTime()
                    }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}