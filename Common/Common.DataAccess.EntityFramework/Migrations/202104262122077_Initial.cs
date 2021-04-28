namespace Common.DataAccess.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SlotId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Slots", t => t.SlotId, cascadeDelete: true)
                .Index(t => t.SlotId)
                .Index(t => t.PersonId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(),
                        UserId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonAvails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        PersonId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.PersonCapacities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        CapacityId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Capacities", t => t.CapacityId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.CapacityId);
            
            CreateTable(
                "dbo.Capacities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskTypeCapacities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskTypeId = c.Int(nullable: false),
                        CapacityId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Capacities", t => t.CapacityId, cascadeDelete: true)
                .ForeignKey("dbo.TaskTypes", t => t.TaskTypeId, cascadeDelete: true)
                .Index(t => t.TaskTypeId)
                .Index(t => t.CapacityId);
            
            CreateTable(
                "dbo.TaskTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProjectId = c.Int(nullable: false),
                        IsActive = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        BeginTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        IsActive = c.Int(),
                        Description = c.String(),
                        TaskTypeId = c.Int(nullable: false),
                        TrainingId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.TaskTypes", t => t.TaskTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Trainings", t => t.TrainingId)
                .Index(t => t.ProjectId)
                .Index(t => t.TaskTypeId)
                .Index(t => t.TrainingId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsActive = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonTrainings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        TrainingId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Trainings", t => t.TrainingId)
                .Index(t => t.PersonId)
                .Index(t => t.TrainingId);
            
            CreateTable(
                "dbo.PersonTaskTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskTypeId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(nullable: false),
                        Age = c.Int(),
                        Street = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        Lat = c.Double(),
                        Lng = c.Double(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(nullable: false),
                        ClaimValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserPhotos",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Image = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ThemeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Settings", "Id", "dbo.Users");
            DropForeignKey("dbo.UserPhotos", "Id", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.PersonCapacities", "PersonId", "dbo.People");
            DropForeignKey("dbo.TaskTypeCapacities", "TaskTypeId", "dbo.TaskTypes");
            DropForeignKey("dbo.Slots", "TrainingId", "dbo.Trainings");
            DropForeignKey("dbo.PersonTrainings", "TrainingId", "dbo.Trainings");
            DropForeignKey("dbo.PersonTrainings", "PersonId", "dbo.People");
            DropForeignKey("dbo.Slots", "TaskTypeId", "dbo.TaskTypes");
            DropForeignKey("dbo.Slots", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectPersons", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectPersons", "PersonId", "dbo.People");
            DropForeignKey("dbo.Assignments", "SlotId", "dbo.Slots");
            DropForeignKey("dbo.TaskTypeCapacities", "CapacityId", "dbo.Capacities");
            DropForeignKey("dbo.PersonCapacities", "CapacityId", "dbo.Capacities");
            DropForeignKey("dbo.PersonAvails", "PersonId", "dbo.People");
            DropForeignKey("dbo.Assignments", "PersonId", "dbo.People");
            DropForeignKey("dbo.Assignments", "LocationId", "dbo.Locations");
            DropIndex("dbo.Settings", new[] { "Id" });
            DropIndex("dbo.UserPhotos", new[] { "Id" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.PersonTrainings", new[] { "TrainingId" });
            DropIndex("dbo.PersonTrainings", new[] { "PersonId" });
            DropIndex("dbo.ProjectPersons", new[] { "PersonId" });
            DropIndex("dbo.ProjectPersons", new[] { "ProjectId" });
            DropIndex("dbo.Slots", new[] { "TrainingId" });
            DropIndex("dbo.Slots", new[] { "TaskTypeId" });
            DropIndex("dbo.Slots", new[] { "ProjectId" });
            DropIndex("dbo.TaskTypeCapacities", new[] { "CapacityId" });
            DropIndex("dbo.TaskTypeCapacities", new[] { "TaskTypeId" });
            DropIndex("dbo.PersonCapacities", new[] { "CapacityId" });
            DropIndex("dbo.PersonCapacities", new[] { "PersonId" });
            DropIndex("dbo.PersonAvails", new[] { "PersonId" });
            DropIndex("dbo.Assignments", new[] { "LocationId" });
            DropIndex("dbo.Assignments", new[] { "PersonId" });
            DropIndex("dbo.Assignments", new[] { "SlotId" });
            DropTable("dbo.Settings");
            DropTable("dbo.UserPhotos");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.PersonTaskTypes");
            DropTable("dbo.PersonTrainings");
            DropTable("dbo.Trainings");
            DropTable("dbo.ProjectPersons");
            DropTable("dbo.Projects");
            DropTable("dbo.Slots");
            DropTable("dbo.TaskTypes");
            DropTable("dbo.TaskTypeCapacities");
            DropTable("dbo.Capacities");
            DropTable("dbo.PersonCapacities");
            DropTable("dbo.PersonAvails");
            DropTable("dbo.People");
            DropTable("dbo.Locations");
            DropTable("dbo.Assignments");
        }
    }
}
