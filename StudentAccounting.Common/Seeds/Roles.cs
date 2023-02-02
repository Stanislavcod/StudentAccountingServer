using StudentAccounting.Common.Constants;
using StudentAccounting.Model.DatabaseModels;

namespace StudentAccounting.Model.Seeds
{
    public class Roles
    {
        public static void Seed(ApplicationDatabaseContext context)
        {
            foreach (var role in RolesConstant.Roles)
                if (!context.Roles.Any(x => x.Name == role.Name))
                    context.Roles.Add(new Role
                    {
                        Name = role.Name
                    });

            context.SaveChanges();
        }
    }
}
