using HRsystem.Data;
using Microsoft.EntityFrameworkCore;

namespace HRsystem.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new HRsystemContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HRsystemContext>>());
            if (context == null || context.PersonBasicInfo == null || context.AccountInfo == null || context.SalaryInfo==null)
            {
                throw new ArgumentNullException(nameof(context), "Null HRsystemContext");
            }

            // Look for any movies.
            if (context.PersonBasicInfo.Any()||context.AccountInfo.Any())
            {
                return;   // DB has been seeded
            }

            context.PersonBasicInfo.AddRange(
                new PersonBasicInfo { Id = 202001, Name = "one", Sex = 'M', Age = 18, Department = "DepartmentOne" },
                new PersonBasicInfo { Id = 202002, Name = "one", Sex = 'F', Age = 19, Department = "DepartmentTwo" },
                new PersonBasicInfo { Id = 202003, Name = "one", Sex = 'M', Age = 20, Department = "DepartmentOne" },
                new PersonBasicInfo { Id = 202004, Name = "one", Sex = 'M', Age = 18, Department = "DepartmentTwo" },
                new PersonBasicInfo { Id = 202005, Name = "two", Sex = 'M', Age = 19, Department = "DepartmentOne" },
                new PersonBasicInfo { Id = 202006, Name = "two", Sex = 'F', Age = 20, Department = "DepartmentTwo" },
                new PersonBasicInfo { Id = 202007, Name = "two", Sex = 'M', Age = 21, Department = "DepartmentOne" },
                new PersonBasicInfo { Id = 202008, Name = "two", Sex = 'M', Age = 22, Department = "DepartmentTwo" }
            );
            context.SaveChanges();
            context.SalaryInfo.AddRange(
                new SalaryInfo { Id = 202001, Basic = 3000, Bonus = 0 },
                new SalaryInfo { Id = 202002, Basic = 4000, Bonus = 0 },
                new SalaryInfo { Id = 202003, Basic = 5000, Bonus = 0 },
                new SalaryInfo { Id = 202004, Basic = 3000, Bonus = 100 },
                new SalaryInfo { Id = 202005, Basic = 3000, Bonus = 500 },
                new SalaryInfo { Id = 202006, Basic = 3000, Bonus = 0 },
                new SalaryInfo { Id = 202007, Basic = 3000, Bonus = 20 },
                new SalaryInfo { Id = 202008, Basic = 12000, Bonus = 200 }
            );
            context.SaveChanges();
            context.AccountInfo.AddRange(
                new AccountInfo { Id = 202001, Password = "1", Autority = 1 },
                new AccountInfo { Id = 202002, Password = "2", Autority = 2 },
                new AccountInfo { Id = 202003, Password = "3", Autority = 2 },
                new AccountInfo { Id = 202004, Password = "4", Autority = 2 },
                new AccountInfo { Id = 202005, Password = "5", Autority = 2 },
                new AccountInfo { Id = 202006, Password = "6", Autority = 2 },
                new AccountInfo { Id = 202007, Password = "7", Autority = 3 },
                new AccountInfo { Id = 202008, Password = "1324", Autority = 0 }
            );

            context.SaveChanges();
            /*
            */
        }
    }
}
