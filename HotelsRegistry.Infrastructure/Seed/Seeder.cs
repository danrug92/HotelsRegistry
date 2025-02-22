using HotelsRegistry.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsRegistry.Infrastructure.Seed
{
    public static class Seeder
    {
        public static async Task SeedAsync(DataContext context)
        {
            if (await context.Accommodations.AnyAsync()) return;
            var accommodation = new Accommodation
            {
                Id = Guid.NewGuid(),
                Name = "Grand Hotel Roma",
                Description = "Un hotel di lusso nel cuore di Roma.",
                Address = "Via del Corso, 123",
                City = "Roma",
                Country = "Italia",
                Phone = "+390612345678",
                Email = "info@grandhotelroma.com",
                VatNumber = "IT12345678901",
                IsPartOfChain = false,
                Stars = 5,
                Type = "Luxury Hotel",
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            var roomTypeStandard = new RoomType
            {
                Id = Guid.NewGuid(),
                AccommodationId = accommodation.Id,
                Name = "Standard",
                Description = "Camera standard con i comfort base.",
                HierarchyLevel = 1,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            var roomTypeDeluxe = new RoomType
            {
                Id = Guid.NewGuid(),
                AccommodationId = accommodation.Id,
                Name = "Deluxe",
                Description = "Camera deluxe con vista panoramica.",
                HierarchyLevel = 2,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            var pricingStandard = new Pricing
            {
                Id = Guid.NewGuid(),
                RoomTypeId = roomTypeStandard.Id,
                Price = 100,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                IsSeasonal = false,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            var roomHierarchyLvl1_2 = new RoomHierarchy
            {
                Id = Guid.NewGuid(),
                RoomTypeBaseId = roomTypeStandard.Id,
                RoomTypeRelatedId = roomTypeDeluxe.Id,
                PercentageIncrease = 30,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            var pricingDeluxe = new Pricing
            {
                Id = Guid.NewGuid(),
                RoomTypeId = roomTypeDeluxe.Id,
                Price = pricingStandard.Price * (1 + (roomHierarchyLvl1_2.PercentageIncrease / 100m)),//loggica da attuare in un possibile FE 
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                IsSeasonal = false,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };
            var room101 = new Room
            {
                Id = Guid.NewGuid(),
                NameRoom = "Room 101",
                Description = "Standard room with a city view",
                RoomTypeId = roomTypeStandard.Id,
                RoomNumber = 101,
                RoomCode = "STD-101",
                SizeInSquareMeters = 25,
                Capacity = 2,
                Floor = 1,
                IsAvailable = true,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
            };
            var room202 = new Room
            {
                Id = Guid.NewGuid(),
                NameRoom = "Room 202",
                Description = "Deluxe room with sea view",
                RoomTypeId = roomTypeDeluxe.Id,
                RoomNumber = 202,
                RoomCode = "DLX-202",
                SizeInSquareMeters = 35,
                Capacity = 3,
                Floor = 2,
                IsAvailable = true,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            await context.Accommodations.AddAsync(accommodation);
            await context.RoomTypes.AddRangeAsync(roomTypeStandard, roomTypeDeluxe);
            await context.RoomHierarchys.AddAsync(roomHierarchyLvl1_2);
            await context.Pricings.AddRangeAsync(pricingStandard, pricingDeluxe);
            await context.Rooms.AddRangeAsync(room101, room202);
            await context.SaveChangesAsync();
            await context.SaveChangesAsync(); 

        }
    }
}
