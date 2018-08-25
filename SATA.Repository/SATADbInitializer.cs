using Microsoft.EntityFrameworkCore;
using SATA.Repository.Entities;
using System.Linq;

namespace SATA.Repository
{
    public class SATADbInitializer
    {
        public static void Initialize(SATADbContext context)
        {
            // Apply all pending migrations
            context.Database.Migrate();

            if (!context.Cards.Any())
            {
                context.Cards.AddRange(new Card { CardNumber = "4123412341234123"}, //Visa
                                        new Card { CardNumber = "5123512351235123"}, //Master
                                        new Card { CardNumber = "312331233123312"}, //Amex
                                        new Card { CardNumber = "3123312331233123"}, //JCB
                                        new Card { CardNumber = "0123012301230123"}); //Unknow

                context.SaveChanges();
            }
        }
    }
}
