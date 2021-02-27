using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Identity;
using DataAccessLayer.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeding
{
    public class DataInitializer
    {
        private const string InitialAdminUsername = "admin@gmail.com";
        private const string InitialAdminEmail = "admin@gmail.com";
        private const string InitialAdminPassword = "Admin_1";
        private const string InitialAdminRoleName = "admin";

        private const string InitialUserUsername = "user@gmail.com";
        private const string InitialUserEmail = "user@gmail.com";
        private const string InitialUserPassword = "User_1";
        private const string InitialUserRoleName = "user";

        private static readonly CarType[] initialCarTypes = new[]
        {
            new CarType { Id = 1, Type = "Легковой" },
            new CarType { Id = 2, Type = "Грузовой" },
            new CarType { Id = 3, Type = "Автобус" },
            new CarType { Id = 4, Type = "Спортивный" },
            new CarType { Id = 5, Type = "Внедорожник" },
            new CarType { Id = 6, Type = "Тягач" },
            new CarType { Id = 7, Type = "Мотоцикл" }
        };

        private static readonly ClientType[] initialClientTypes = new[]
        {
            new ClientType { Id = 1, Type = "Обычный" },
            new ClientType { Id = 2, Type = "Постоянный" }
        };

        private static readonly CarState[] initialCarStates = new[]
        {
            new CarState{ Id = 1, State = "Хорошее" },
            new CarState{ Id = 2, State = "Плохое" }
        };

        private static readonly Client[] initialClients = new[]
        {
            new Client{ Id = 1, FirstName = "AdminFirstName", LastName = "AdminLastName", SecondName = "AdminSecondName", ClientTypeId = 1 },
            new Client{ Id = 2, FirstName = "UserFirstName", LastName = "UserLastName", SecondName = "UserSecondName", ClientTypeId = 1 }
        };

        public static async Task InitializeUsersWithRolesAsync(IUnitOfWork unitOfWork)
        {
            var roleManager = unitOfWork.RoleManager;
            var userManager = unitOfWork.UserManager;

            if (await roleManager.FindByNameAsync(InitialAdminRoleName) is null)
                await roleManager.CreateAsync(new Role { Name = InitialAdminRoleName });

            if (await userManager.FindByNameAsync(InitialAdminUsername) is null)
            {
                User admin = new User { Email = InitialAdminEmail, UserName = InitialAdminUsername, ClientId = 1 };
                IdentityResult result = await userManager.CreateAsync(admin, InitialAdminPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, InitialAdminRoleName);
            }

            if (await roleManager.FindByNameAsync(InitialUserRoleName) is null)
                await roleManager.CreateAsync(new Role { Name = InitialUserRoleName });

            if (await userManager.FindByNameAsync(InitialUserUsername) is null)
            {
                User admin = new User { Email = InitialUserEmail, UserName = InitialUserUsername, ClientId = 2 };
                IdentityResult result = await userManager.CreateAsync(admin, InitialUserPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, InitialUserRoleName);
            }
        }

        public static CarType[] InitialCarTypes { get { return initialCarTypes; } }

        public static ClientType[] InitialClientTypes { get { return initialClientTypes; } }

        public static CarState[] InitialCarStates { get { return initialCarStates; } }

        public static Client[] InitialClients { get { return initialClients; } }
    }
}