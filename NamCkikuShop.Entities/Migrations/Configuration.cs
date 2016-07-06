namespace NamCkikuShop.Entities.Migrations
{
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NamCkikuShop.Entities.Models.NamCkikuShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NamCkikuShop.Entities.Models.NamCkikuShopDbContext context)
        {
            CreateProductCategorySample(context);
            CreateSlide(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
        private void CreateProductCategorySample(NamCkikuShop.Entities.Models.NamCkikuShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh",Status=true },
                 new ProductCategory() { Name="Viễn thông",Alias="vien-thong",Status=true },
                  new ProductCategory() { Name="Đồ gia dụng",Alias="do-gia-dung",Status=true },
                   new ProductCategory() { Name="Mỹ phẩm",Alias="my-pham",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }
        private void CreateFooter(NamCkikuShop.Entities.Models.NamCkikuShopDbContext context)
        {
            if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterId) == 0)
            {
                string content = "";
            }
        }
        private void CreateSlide(NamCkikuShop.Entities.Models.NamCkikuShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name ="headphones az12",
                        DisplayOrder =1,
                        Status =true,
                        Url ="#",
                        Image ="~/Content/Client/images/slider/img-04.png",
                        Content =@"h1>sale up to!</h1>
                        <h2>30% off</h2>
                        <div class=""check-box"">
                            <ul class=""list-unstyled"">
                                <li>With all products in shop</li>
                                <li>All combos $69.96</li>
                            </ul>
                        </div>" },
                    new Slide() {
                        Name ="Samsung s5",
                        DisplayOrder =2,
                        Status =true,
                        Url ="#",
                        Image ="~/Content/Client/images/slider/img-05.png",
                    Content=@"<h1>sale up to!</h1>
                        <h2>50% off</h2>"},
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }
    }
}
