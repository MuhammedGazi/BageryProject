using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Observer;
using Bagery.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Bagery.Business.Observers
{
    public class NotificationObserver : INotificationObserver
    {
        private readonly AppDbContext _context;

        public NotificationObserver(AppDbContext context)
        {
            _context = context;
        }

        public async Task UpdateAsync(Promotion promotion)
        {
            var users = await _context.Users.ToListAsync();
            var notifications = new List<Notification>();

            foreach (var user in users)
            {
                notifications.Add(new Notification
                {
                    Title = $"Yeni Kampanya: {promotion.Title}",
                    Message = $"{promotion.Description}. Hemen inceleyin!",
                    AppUserId = user.Id,
                    IsRead = false,
                    CreatedDate = System.DateTime.Now,
                });
            }

            await _context.Notifications.AddRangeAsync(notifications);
            await _context.SaveChangesAsync();
        }
    }
}
