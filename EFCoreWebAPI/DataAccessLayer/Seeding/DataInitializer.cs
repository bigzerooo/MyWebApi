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

        private static readonly Car[] initialCars = new[]
        {
            new Car
            {
                Id = 1,
                Brand = "Alfa Romeo Giulia",
                Price = 31585,
                PricePerHour = 31.50m,
                CarTypeId = 1,
                Year = 2019,
                ImagePath = "/default_images/initial_car_images/1.jpg",
                Description = "Alfa Romeo's pointy, shield-shaped grille may not be for everyone, but the Giulia wears it well and the rest of the car is truly gorgeous. This sport sedan is perfectly proportioned, with a long hood and a cabin set back toward the rear wheels, and the body surfacing and details are exquisite. And every Giulia shares the same good looks; Alfa Romeo doesn't muck up the base models or reserve the choicest flourishes for the range-topping, high-performance Giulia Quadrifoglio. We think that the base Giulia's tamer front and rear bumpers, lack of side vents, and additional chrome trim actually add to the design's appeal."
            },
            new Car
            {
                Id = 2,
                Brand = "Audi RS6 Avant/RS7",
                Price = 68999,
                PricePerHour = 68.90m,
                CarTypeId = 1,
                Year = 2016,
                ImagePath = "/default_images/initial_car_images/2.jpg",
                Description = "Audi’s latest V-8–powered RS cars offer similar below-the-beltline musculature with your choice of greenhouse and roofline. The RS6 Avant and RS7 look like their pedestrian A-level siblings on a steady drip of steroids, with every surface flexed and exaggerated. Both feature wider fenders and a lower ride height, lending them an aggressive but elegant presence on the road. The RS6 Avant is a welcome challenger to the Mercedes-AMG E63S at the top of the miniscule U.S. wagon market. Equally as elegant and perhaps even more sinister is the RS7, which trades the long roof for a sloping roofline and a more streamlined silhouette."
            },
            new Car
            {
                Id = 3,
                Brand = "Aston Martin DBS Superleggera",
                Price = 377038,
                PricePerHour = 377,
                CarTypeId = 1,
                Year = 2019,
                ImagePath = "/default_images/initial_car_images/3.jpg",
                Description = "If any automaker knows how to make a beautiful car, it's Aston Martin. The DBS Superleggera is both the brand's newest model and the best expression of its current design language. While it is based on the DB11, the DBS's bodywork is unique save for the roof. The whale shark–like grille design somehow isn't too big, its yawning opening harking back to Astons of yore, and the squared-off rear, short front overhang, and wide fenders give it excellent proportions. The DBS's more traditional detailing relative to the more futuristically styled DB11 further helps it earn the b-word descriptor."
            },
            new Car
            {
                Id = 4,
                Brand = "BMW 8-series Gran Coupe",
                Price = 169814,
                PricePerHour = 169,
                CarTypeId = 1,
                Year = 2014,
                ImagePath ="/default_images/initial_car_images/4.jpg",
                Description = "Audi isn’t the only brand that makes big beautiful. The most gorgeous member of BMW’s 8-series family is, in our eyes, the Gran Coupe. The four-door is hard to miss, its profile flowing seamlessly from long hood into raked windshield then arcing gracefully back down into the C-pillar and meaty rear haunches. The 8-series Gran Coupe uses many of the same styling cues that the 6-series Gran Coupe did except it's more distilled and refined: the greenhouse is more open, the sheet metal is more organically shaped, and the kidney grille—unlike other BMW models—doesn't appear to be flaring its nostrils at anyone."
            },
            new Car
            {
                Id = 5,
                Brand = "Bugatti Chiron",
                Price = 9200000,
                PricePerHour = 9200,
                CarTypeId = 4,
                Year = 2016,
                ImagePath = "/default_images/initial_car_images/5.jpg",
                Description = "Bugatti's Veyron, while striking and undeniably iconic thanks to its record-setting top speed, was not necessarily an attractive car. To many it was stubby, bulbous, and weird-looking. While only incrementally faster, its successor, the Chiron, is a whole lot prettier. The design is more aggressive, with larger air scoops and vents. The whole rear end is practically one big mesh grille with taillights stuffed into its void. Each side of the car is dominated by a C-line that curves around the doors and visually splits the body into two distinct sections; this demarcation doubles as the color division for the Bugatti's available two-tone paint jobs. It’s all very purposeful and dramatic. And beautiful. Especially the Pur Sport."
            },
            new Car
            {
                Id = 6,
                Brand = "Ford GT",
                Price = 75860,
                PricePerHour = 75,
                CarTypeId = 1,
                Year = 2017,
                ImagePath = "/default_images/initial_car_images/6.jpg",
                Description = "Ford updated its GT supercar for the 2020 model year, and with it came the option for a body in completely naked carbon fiber. That comes at a steep price compared to the GT's $500,000 base, though, adding about 50 percent to the sticker. As gnarly as the exposed carbon looks, we'd choose the updated and modernized Gulf Racing Heritage livery Ford GT rolled out at the same time."
            },
            new Car
            {
                Id = 7,
                Brand = "Infiniti Q60",
                Price = 37852,
                PricePerHour = 37,
                CarTypeId = 1,
                Year = 2013,
                ImagePath = "/default_images/initial_car_images/7.jpg",
                Description = "We like the Infiniti Q50 well enough, but in lopping off two of its doors to create the Q60 coupe, Infiniti created something special. The Q60's slimmer lights, sportier bumpers, and sleeker rear end all are improvements over the sedan, but it's what's in the middle of the car that really wins. The Q60's roofline arcs though a near perfect sweep over the cabin, and it wears the best version yet of Infiniti's unusual kinked-C-pillar design. The Q60's shoulder line is higher up and more pronounced than the Q50’s, and placing the door handle on that shoulder—as opposed to below it—cleans up the bodyside graphic."
            },
            new Car
            {
                Id = 8,
                Brand = "Lexus LC",
                Price = 118000,
                PricePerHour = 118,
                CarTypeId = 1,
                Year = 2014,
                ImagePath = "/default_images/initial_car_images/8.jpg",
                Description = "The outrageous Lexus LC began life as a similarly wild-looking 2012 concept car that Lexus had no plans to build. Four years after that show car debuted, it made a nearly edit-free transition to production. The LC's classic grand tourer proportions are just the beginning, embellished with a dramatic hourglass grille, squinting headlights, spectacularly wide and muscular rear fenders, and roof that appears to float thanks to blacked-out C-pillars. Minimalist the Lexus's design is not, but we think its sci-fi detailing adds to the car's beauty. For 2021, Lexus will add a convertible to the lineup, and it looks at least as stunning as the coupe."
            },
            new Car
            {
                Id = 9,
                Brand = "Mazda 3",
                Price = 30000,
                PricePerHour = 30,
                CarTypeId = 1,
                Year = 2016,
                ImagePath = "/default_images/initial_car_images/9.jpg",
                Description = "The previous-generation Mazda 3 already was one of our favorite designs on the market, but Mazda's all-new 3 is even better. Keep in mind, this is an affordable, right-sized car, albeit one with sophisticated body panels shaped to use light to their advantage. Creases and body lines are held to an absolute minimum. The 3's shark nose pairs surprisingly well with the sedan's curving roofline and nicely sculpted trunk, and again, we should remind you that this is a compact front-wheel-drive sedan that drives like anything but. We understand that the 3 hatchback, which has a curiously thick C-pillar and sports a severely raked rear window, might appeal to a narrower subset of the public, but we dig it."
            },
            new Car
            {
                Id = 10,
                Brand = "Mercedes-Benz S-class Coupe",
                Price = 173000,
                PricePerHour = 173,
                CarTypeId = 1,
                Year = 2018,
                ImagePath = "/default_images/initial_car_images/10.jpg",
                Description = "Every version of the current Mercedes-Benz S-class looks spectacular and represents an assemblage of upscale details, but our personal favorite is the two-door coupe. The roofline has a graceful, sweeping curvature that blends beautifully into the sculpted trunk lid via the convex rear window. Mercedes puffs out the coupe's hips more than the four-door sedan’s, and the slight upward curve at the bottom of the rear windows resolves in a fantastic point at the C-pillar. At the rear, a horizontal graphic makes the car look lower and wider, and the long OLED taillights are stunning, to boot. Should the coupe's pillarless side glass fail to impress, there's always the S-class cabriolet; it might not look as good with its cloth roof in place, but when that lid is folded and stowed behind the rear seats, the car looks like a land-based yacht."
            },
            new Car
            {
                Id = 11,
                Brand = "Polestar 1",
                Price = 62000,
                PricePerHour = 62,
                CarTypeId = 1,
                Year = 2016,
                ImagePath = "/default_images/initial_car_images/11.jpg",
                Description = "Volvo and China’s Geely are extremely unlikely parents for a new performance brand, but Polestar is here and focused not only on performance, but design. The company's first effort, the Polestar 1, bears a passing resemblance to a high-style Ford Mustang but with a cleaner simplicity to its lines. It's certainly different to see Volvo design language used on a flagship coupe like this, but damn does it work well."
            },
            new Car
            {
                Id = 12,
                Brand = "Porsche 911",
                Price = 234000,
                PricePerHour = 234,
                CarTypeId = 1,
                Year = 2017,
                ImagePath = "/default_images/initial_car_images/12.jpg",
                Description = "There are few examples throughout the Porsche 911's history of bad design. Surely somebody loves the 996-generation's scrambled-egg headlights, and the '80s 911s' bumpers could have been better, but the rear-engined sports car has consistently qualified as beautiful. The new 992 generation is the most streamlined 911 yet, all big hips, smooth edges, and clean lines. It represents a wholly modern take on the classic 911 theme, but Porsche tossed some retro 911 touches in for good measure, including the squared-off hood and the full-width taillights."
            },
            new Car
            {
                Id = 13,
                Brand = "Porsche Taycan",
                Price = 244000,
                PricePerHour = 0,
                CarTypeId = 1,
                Year = 2018,
                ImagePath = "/default_images/initial_car_images/13.jpg",
                Description = "Arguably the best looking EV to date, the Porsche Taycan provides hope for aesthetes in an electric future. Like the Panamera, the Taycan has four doors, but it has a trunk instead of a hatch and looks as if a 911 were melted and stretched. Even the newly streamlined Panamera seems staid in comparison. The Taycan pulls its design directly from the Mission E concept and lost very little of that jaw-dropper’s specialness. Smooth curves, low stance, and wide hips make for a great combination. If all EVs looked like the Taycan, our arms would be open a little wider for them."
            },
            new Car
            {
                Id = 14,
                Brand = "Volkswagen Arteon",
                Price = 134000,
                PricePerHour = 244,
                CarTypeId = 1,
                Year = 2013,
                ImagePath = "/default_images/initial_car_images/14.jpg",
                Description = "Volkswagen's now-discontinued CC was among the first mainstream cars to feature a so-called \"four-door coupe\" design. Its spiritual successor, the new Arteon, takes the same theme and puts a fastback spin on it. Unlike the CC, the Arteon is a hatchback, but you wouldn't know it from the way the roof flows into what looks like a vestigial trunk. The wide rear haunches and sculpted front fenders punctuate tight creases stamped into the body sides. The slightly fussy front-end detailing is forgivable given the Arteon's technical appearance and utterly elegant tail."
            },
            new Car
            {
                Id = 15,
                Brand = "Volvo V60",
                Price = 384000,
                PricePerHour = 134,
                CarTypeId = 1,
                Year = 2020,
                ImagePath = "/default_images/initial_car_images/15.jpg",
                Description = "Since being sold to Geely in 2010, Volvo has elevated its styling from quirky Swede to modern chic, establishing a standout style even among the distinct personalities in the luxury space. The Volvo V60 is not only an example of Volvo's stylistic resurgence, but also its dedication to building attractive wagons. The V60 looks like a scaled down V90, and that's not a bad thing considering its larger sibling—while even more beautiful and premium—is only a special order in the U.S., making it a rare sight on public roads."
            }
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

        public static Car[] InitialCars { get { return initialCars; } }
    }
}