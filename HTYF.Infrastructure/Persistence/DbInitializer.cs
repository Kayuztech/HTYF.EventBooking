using HTYF.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HTYF.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (await context.EventsDbSet.AnyAsync())
                return; // Data already exists

            var events = new List<Event>
            {
                new Event
                {
                    Title = "Tech for Good Conference",
                    Summary = "A conference focused on using technology for social impact.",
                    EventDateTime = DateTime.Now.AddDays(7),
                    Location = "Lagos, Nigeria",
                    Capacity = 150
                },
                new Event
                {
                    Title = "Youth Innovation Workshop",
                    Summary = "Hands-on workshop empowering young innovators.",
                    EventDateTime = DateTime.Now.AddDays(14),
                    Location = "Abuja, Nigeria",
                    Capacity = 50
                },
                new Event
                {
                    Title = "Community Health Seminar",
                    Summary = "Awareness seminar on community health initiatives.",
                    EventDateTime = DateTime.Now.AddDays(21),
                    Location = "Ibadan, Nigeria",
                    Capacity = 100
                },
                new Event
                {
                    Title = "NGO Fundraising Meetup",
                    Summary = "Networking event for nonprofit fundraising strategies.",
                    EventDateTime = DateTime.Now.AddDays(30),
                    Location = "Online",
                    Capacity = 300
                },
                new Event
                {
                    Title = "Volunteer Training Session",
                    Summary = "Training session for new volunteers.",
                    EventDateTime = DateTime.Now.AddDays(10),
                    Location = "Port Harcourt, Nigeria",
                    Capacity = 80
                }
            };

            await context.EventsDbSet.AddRangeAsync(events);
            await context.SaveChangesAsync();
        }
    }
}
