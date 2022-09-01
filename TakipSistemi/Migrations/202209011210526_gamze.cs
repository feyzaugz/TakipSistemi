namespace TakipSistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gamze : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanıcılar",
                c => new
                    {
                        KullaniciID = c.Int(nullable: false, identity: true),
                        KullaniciAd = c.String(),
                        KullaniciSoyad = c.String(),
                        KullaniciMail = c.String(),
                        Parola = c.String(),
                        Durum = c.Boolean(nullable: false),
                        YetkiId = c.Int(nullable: false),
                        TakipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KullaniciID)
                .ForeignKey("dbo.Takipler", t => t.TakipId, cascadeDelete: true)
                .ForeignKey("dbo.Yetkiler", t => t.YetkiId, cascadeDelete: true)
                .Index(t => t.YetkiId)
                .Index(t => t.TakipId);
            
            CreateTable(
                "dbo.Takipler",
                c => new
                    {
                        TakipId = c.Int(nullable: false, identity: true),
                        DosyaNo = c.String(),
                        TalepNo = c.Int(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        Yetkili = c.String(),
                        Tanim = c.String(),
                        Durum = c.Boolean(nullable: false),
                        DurumAciklama = c.String(),
                    })
                .PrimaryKey(t => t.TakipId);
            
            CreateTable(
                "dbo.Yetkiler",
                c => new
                    {
                        YetkiId = c.Int(nullable: false, identity: true),
                        YetkiAdi = c.String(),
                    })
                .PrimaryKey(t => t.YetkiId);
            
            CreateTable(
                "dbo.TakipLoglar",
                c => new
                    {
                        KullaniciAd = c.String(nullable: false, maxLength: 20),
                        Tarih = c.DateTime(nullable: false),
                        DurumAciklama = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.KullaniciAd);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kullanıcılar", "YetkiId", "dbo.Yetkiler");
            DropForeignKey("dbo.Kullanıcılar", "TakipId", "dbo.Takipler");
            DropIndex("dbo.Kullanıcılar", new[] { "TakipId" });
            DropIndex("dbo.Kullanıcılar", new[] { "YetkiId" });
            DropTable("dbo.TakipLoglar");
            DropTable("dbo.Yetkiler");
            DropTable("dbo.Takipler");
            DropTable("dbo.Kullanıcılar");
        }
    }
}
