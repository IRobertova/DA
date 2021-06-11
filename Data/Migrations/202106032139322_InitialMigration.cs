namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 180),
                        Year = c.Int(nullable: false),
                        Genre = c.String(nullable: false, maxLength: 40),
                        Duration = c.Int(nullable: false),
                        Resume = c.String(maxLength: 400),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User_Movie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Movie_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Rent_Day = c.DateTime(nullable: false),
                        Return_Day = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(maxLength: 200),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                        Movie_Id1 = c.Int(),
                        User_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id1)
                .ForeignKey("dbo.Users", t => t.User_Id1)
                .Index(t => t.Movie_Id1)
                .Index(t => t.User_Id1);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 30),
                        LName = c.String(nullable: false, maxLength: 30),
                        Bday = c.DateTime(),
                        Phone = c.String(nullable: false, maxLength: 10),
                        Address = c.String(maxLength: 60),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Movie", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.User_Movie", "Movie_Id1", "dbo.Movies");
            DropIndex("dbo.User_Movie", new[] { "User_Id1" });
            DropIndex("dbo.User_Movie", new[] { "Movie_Id1" });
            DropTable("dbo.Users");
            DropTable("dbo.User_Movie");
            DropTable("dbo.Movies");
        }
    }
}
