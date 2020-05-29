namespace Epic_Game.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using EpicGameLibrary.Models;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EGContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Epic_Game.Models.ApplicationDbContext";
        }

        protected override void Seed(EGContext context)
        {

            //Generate Guid
            //Product
            var witcher3 = Guid.Parse("d75ebeb8-4bc7-44b3-86bf-904ec05a5686");
            //Social Media
            var witcher3_Facebook = Guid.Parse("bf89dbc8-0861-47cb-b9a8-88e188ba72cc");
            var witcher3_Instagram = Guid.Parse("42e244df-ff43-40b6-8648-3cd0ef5114db");
            var witcher3_Youtube = Guid.Parse("baa4ccf3-43b3-4e41-a919-59f55f9f6d1e");
            var witcher3_Twitter = Guid.Parse("f8142560-b5bc-44f0-b9a8-33fe5ac3867a");
            var witcher3_Twitch = Guid.Parse("e771ae00-712c-4e17-a6e9-16352a811b36");

            //Product Seed Data 
            context.Product.AddOrUpdate(x => x.ProductID,
                new Product
                {
                    ProductID = witcher3,
                    ContentType = "Game",
                    ProductName = "The Witcher 3: Wild Hunt",
                    Title = "The Witcher 3: Wild Hunt",
                    Price = 960.0m,
                    Discount = 0.7m,
                    Developer = "CD PROJEKT",
                    Publisher = "CD PROJEKT",
                    ReleaseDate = new DateTime(2015, 5, 19),
                    Category = 5,
                    AgeRestriction = 17,
                    OS = 1,
                    Description = File.ReadAllText("../../App_Data/ProductText/Witcher3_text.txt")
                });

            context.Image.AddOrUpdate(x => x.ImgID,
                //Store Img
                new Image { ImgID = 50000, Location = 0, ProductOrPack = witcher3, Url = "/Assets/Images/Witcher3/storeImg.jpg" },
                //Logo
                new Image { ImgID = 50001, Location = 1, ProductOrPack = witcher3, Url = "/Assets/Images/Witcher3/logo.jpg" },
                //Slider
                new Image { ImgID = 50002, Location = 2, ProductOrPack = witcher3, Url = "https://www.youtube.com/watch?v=ehjJ614QfeM" },
                new Image { ImgID = 50004, Location = 2, ProductOrPack = witcher3, Url = "/Assets/Images/Witcher3/slider02.jpg" },
                new Image { ImgID = 50003, Location = 2, ProductOrPack = witcher3, Url = "/Assets/Images/Witcher3/slider03.jpg" },
                new Image { ImgID = 50005, Location = 2, ProductOrPack = witcher3, Url = "/Assets/Images/Witcher3/slider04.jpg" },
                new Image { ImgID = 50006, Location = 2, ProductOrPack = witcher3, Url = "/Assets/Images/Witcher3/slider05.jpg" },
                new Image { ImgID = 50007, Location = 2, ProductOrPack = witcher3, Url = "/Assets/Images/Witcher3/slider06.jpg" },
                new Image { ImgID = 50008, Location = 2, ProductOrPack = witcher3, Url = "/Assets/Images/Witcher3/slider07.jpg" },
                new Image { ImgID = 50009, Location = 2, ProductOrPack = witcher3, Url = "/Assets/Images/Witcher3/slider08.jpg" },
                new Image { ImgID = 50010, Location = 2, ProductOrPack = witcher3, Url = "/Assets/Images/Witcher3/slider09.jpg" },
                new Image { ImgID = 50011, Location = 2, ProductOrPack = witcher3, Url = "/Assets/Images/Witcher3/slider10.jpg" }
                );

            context.Social_Media.AddOrUpdate(x => x.FollowID,
                new Social_Media { FollowID = witcher3_Facebook, ProductID = witcher3, Community = "facebook", URL = "https://www.facebook.com/thewitcher/" },
                new Social_Media { FollowID = witcher3_Instagram, ProductID = witcher3, Community = "instagram", URL = "https://www.instagram.com/cdpred/" },
                new Social_Media { FollowID = witcher3_Youtube, ProductID = witcher3, Community = "youtube", URL = "https://www.youtube.com/thewitcher/" },
                new Social_Media { FollowID = witcher3_Twitter, ProductID = witcher3, Community = "twitter", URL = "https://twitter.com/witchergame" },
                new Social_Media { FollowID = witcher3_Twitch, ProductID = witcher3, Community = "twitch", URL = "https://www.twitch.tv/cdprojektred" }
                );
        }
    }
}
