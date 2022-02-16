using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentAPI.Models
{
    public class PrepDB
    {
        public static void  PrepPopution(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SendData(serviceScope.ServiceProvider.GetService<PaymentDetailContext>());
            }
        }
        public static void SendData(PaymentDetailContext context)
        {
            Console.WriteLine("Applying migration");
            context.Database.Migrate();

            if(context.PaymentDetails.Any())
            {
                context.PaymentDetails.AddRange(new PaymentDetail() { CardNumber = "1234567891234567", CardOwnerName = "Amit", ExpirationDate = "03/24", SecurityCode = "004", PaymentDetailId = 1 });
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data not seeding");
            }


        }
    }
}
