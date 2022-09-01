namespace TakipSistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feyza : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kullanıcılar", "TakipId", "dbo.Takipler");
            DropIndex("dbo.Kullanıcılar", new[] { "TakipId" });
            AddColumn("dbo.Takipler", "KullaniciAdSoyad", c => c.String());
            DropColumn("dbo.Kullanıcılar", "TakipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kullanıcılar", "TakipId", c => c.Int(nullable: false));
            DropColumn("dbo.Takipler", "KullaniciAdSoyad");
            CreateIndex("dbo.Kullanıcılar", "TakipId");
            AddForeignKey("dbo.Kullanıcılar", "TakipId", "dbo.Takipler", "TakipId", cascadeDelete: true);
        }
    }
}
