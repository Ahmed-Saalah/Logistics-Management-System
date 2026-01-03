using Logex.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Logex.API.Data.Seeding
{
    public static class LogisticsZonesSeeder
    {
        public static void SeedLogisticsZonesData(this ModelBuilder modelBuilder)
        {
            // Seed Zones
            modelBuilder
                .Entity<Zone>()
                .HasData(
                    new Zone { Id = 1, Name = "Greater Cairo" },
                    new Zone { Id = 2, Name = "Delta" },
                    new Zone { Id = 3, Name = "Canal" },
                    new Zone { Id = 4, Name = "South Egypt" }
                );

            // Seed Cities
            modelBuilder
                .Entity<City>()
                .HasData(
                    // Zone 1: Cairo
                    new City
                    {
                        Id = 1,
                        Name = "Cairo",
                        ZoneId = 1,
                    },
                    new City
                    {
                        Id = 2,
                        Name = "Giza",
                        ZoneId = 1,
                    },
                    new City
                    {
                        Id = 3,
                        Name = "6th of October",
                        ZoneId = 1,
                    },
                    new City
                    {
                        Id = 4,
                        Name = "New Cairo",
                        ZoneId = 1,
                    },
                    // Zone 2: Delta
                    new City
                    {
                        Id = 5,
                        Name = "Alexandria",
                        ZoneId = 2,
                    },
                    new City
                    {
                        Id = 6,
                        Name = "Tanta",
                        ZoneId = 2,
                    },
                    new City
                    {
                        Id = 7,
                        Name = "Mansoura",
                        ZoneId = 2,
                    },
                    new City
                    {
                        Id = 8,
                        Name = "Damietta",
                        ZoneId = 2,
                    },
                    // Zone 3: Canal
                    new City
                    {
                        Id = 9,
                        Name = "Port Said",
                        ZoneId = 3,
                    },
                    new City
                    {
                        Id = 10,
                        Name = "Suez",
                        ZoneId = 3,
                    },
                    new City
                    {
                        Id = 11,
                        Name = "Ismailia",
                        ZoneId = 3,
                    },
                    // Zone 4: South Egypt
                    new City
                    {
                        Id = 12,
                        Name = "Luxor",
                        ZoneId = 4,
                    },
                    new City
                    {
                        Id = 13,
                        Name = "Aswan",
                        ZoneId = 4,
                    },
                    new City
                    {
                        Id = 14,
                        Name = "Assiut",
                        ZoneId = 4,
                    },
                    new City
                    {
                        Id = 15,
                        Name = "Sohag",
                        ZoneId = 4,
                    }
                );

            // Seed ZoneRates
            modelBuilder
                .Entity<ZoneRate>()
                .HasData(
                    // Scenario A: Same Zone
                    new ZoneRate
                    {
                        Id = 1,
                        FromZoneId = 1,
                        ToZoneId = 1,
                        BaseRate = 30.00m,
                        AdditionalWeightCost = 5.00m,
                    },
                    new ZoneRate
                    {
                        Id = 2,
                        FromZoneId = 2,
                        ToZoneId = 2,
                        BaseRate = 35.00m,
                        AdditionalWeightCost = 5.00m,
                    },
                    new ZoneRate
                    {
                        Id = 3,
                        FromZoneId = 3,
                        ToZoneId = 3,
                        BaseRate = 35.00m,
                        AdditionalWeightCost = 5.00m,
                    },
                    new ZoneRate
                    {
                        Id = 4,
                        FromZoneId = 4,
                        ToZoneId = 4,
                        BaseRate = 45.00m,
                        AdditionalWeightCost = 6.00m,
                    },
                    // Scenario B: Cairo to Others
                    new ZoneRate
                    {
                        Id = 5,
                        FromZoneId = 1,
                        ToZoneId = 2,
                        BaseRate = 100.00m,
                        AdditionalWeightCost = 8.00m,
                    },
                    new ZoneRate
                    {
                        Id = 6,
                        FromZoneId = 1,
                        ToZoneId = 3,
                        BaseRate = 150.00m,
                        AdditionalWeightCost = 9.00m,
                    },
                    new ZoneRate
                    {
                        Id = 7,
                        FromZoneId = 1,
                        ToZoneId = 4,
                        BaseRate = 200.00m,
                        AdditionalWeightCost = 15.00m,
                    },
                    // Scenario C: Reverse Routes
                    new ZoneRate
                    {
                        Id = 8,
                        FromZoneId = 2,
                        ToZoneId = 1,
                        BaseRate = 100.00m,
                        AdditionalWeightCost = 8.00m,
                    },
                    new ZoneRate
                    {
                        Id = 9,
                        FromZoneId = 3,
                        ToZoneId = 1,
                        BaseRate = 150.00m,
                        AdditionalWeightCost = 9.00m,
                    },
                    new ZoneRate
                    {
                        Id = 10,
                        FromZoneId = 4,
                        ToZoneId = 1,
                        BaseRate = 200.00m,
                        AdditionalWeightCost = 15.00m,
                    },
                    // Scenario D: Long Distance
                    new ZoneRate
                    {
                        Id = 11,
                        FromZoneId = 2,
                        ToZoneId = 4,
                        BaseRate = 250.00m,
                        AdditionalWeightCost = 15.00m,
                    },
                    new ZoneRate
                    {
                        Id = 12,
                        FromZoneId = 4,
                        ToZoneId = 2,
                        BaseRate = 250.00m,
                        AdditionalWeightCost = 15.00m,
                    }
                );
        }
    }
}
