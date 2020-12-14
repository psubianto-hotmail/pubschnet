/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Common.DataAccess.EntityFramework.Configuration;
using Common.DataAccess.EntityFramework.Configuration.System;
using Common.Entities;
using System.Data.Entity;

namespace Common.DataAccess.EntityFramework
{
    public class DataContext : DbContext
    {
        public ContextSession Session { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Capacity> Capacities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PersonAvail> PersonAvails { get; set; }
        public DbSet<PersonCapacity> PersonCapacities { get; set; }
        public DbSet<PersonTaskType> PersonTaskTypes { get; set; }
        public DbSet<PersonTraining> PersonTrainings { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ProjectPerson> ProjectPersons { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<TaskTypeCapacity> TaskTypeCapacities { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<Training> Trainings { get; set; }

        protected void InitContextSettings()
        {
            Database.SetInitializer(new DataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DataContext() : base("name=localDb")
        {
            InitContextSettings();
        }

        protected DataContext(string connection) : base(connection)
        {
            InitContextSettings();
        }

        protected DataContext(ContextSession session, string connection) : base(connection)
        {
            Session = session;
            InitContextSettings();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new UserRoleConfig());
            modelBuilder.Configurations.Add(new UserClaimConfig());

            modelBuilder.Configurations.Add(new UserPhotoConfig());
            modelBuilder.Configurations.Add(new SettingsConfig());

            modelBuilder.HasDefaultSchema("starter");
        }
    }
}
