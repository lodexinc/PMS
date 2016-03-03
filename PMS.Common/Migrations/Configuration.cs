namespace PMS.Common.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<PMS.Common.PMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PMS.Common.PMSContext context)
        {
            //  This method will be called after migrating to the latest version.

            string AdminUserName = "admin";
            Encrypt encrypt = new Encrypt();
            encrypt.Key = AdminUserName;
            encrypt.Message = "abc@123";

            var member = context.Members.FirstOrDefault(m => m.UserName == AdminUserName);
            if (member == null)
            {
                context.Members.Add(
                           new Member()
                           {
                               Id = Guid.NewGuid(),
                               FirstName = "Supper",
                               LastName = "Admin",
                               UserName = AdminUserName,
                               Password = encrypt.EncryptString(),
                               University = "ABC",
                               EmailAddress = "test@test.com"
                           }
                       );
            }

            var publisher1 = context.Publishers.FirstOrDefault(p => p.Name == "Oxford Publishing Press");
            if (publisher1 == null)
            {
                context.Publishers.Add(
                    new Publisher()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Oxford Publishing Press",
                        Address = "SomeWhere London, UK",
                        City = "London",
                        Email = "publisher@orignalbooks.com",
                        Phone = "12345678",
                        PostCode = 1234
                    }
                    );
            }

            var publisher2 = context.Publishers.FirstOrDefault(p => p.Name == "Cambridge Publishing Press");
            if (publisher2 == null)
            {
                context.Publishers.Add(
                new Publisher()
                {
                    Id = Guid.NewGuid(),
                    Name = "Cambridge Publishing Press",
                    Address = "Far from my city",
                    City = "Paris",
                    Email = "publisher@paris.com",
                    Phone = "98765442",
                    PostCode = 3124
                }
                );
            }

            context.SaveChanges();
        }
    }
}
