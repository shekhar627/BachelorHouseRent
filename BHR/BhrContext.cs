using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BHR.EntityConfiguration;
using BHR.Models;

namespace BHR
{
    public class BhrContext:DbContext
    {
        public DbSet<Division> Divisions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Thana> Thanas { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<HouseKey> HouseKeys { get; set; }
        public DbSet<UserHouse> UserHouses { get; set; }
        public DbSet<ManagerHouse> ManagerHouses { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertiseImage> AdvertiseImages { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ConfirmPayment> ConfirmPayments { get; set; }
















        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new DivisionConfiguration());
            modelBuilder.Configurations.Add(new DistrictConfiguration());
            modelBuilder.Configurations.Add(new OccupationConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserImageConfiguration());
            modelBuilder.Configurations.Add(new ThanaConfiguration());
            modelBuilder.Configurations.Add(new HouseConfiguration());
            modelBuilder.Configurations.Add(new HouseKeyConfiguration());
            modelBuilder.Configurations.Add(new ManagerHouseConfiguration());
            modelBuilder.Configurations.Add(new UserHouseConfiguration());
            modelBuilder.Configurations.Add(new AdvertisementConfiguration());
            modelBuilder.Configurations.Add(new AdvertiseImageConfiguration());
            modelBuilder.Configurations.Add(new ConfirmPaymentConfiguration());

        }
    }
}