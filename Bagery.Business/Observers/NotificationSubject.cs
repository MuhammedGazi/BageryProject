using Bagery.Core.Entities;
using Bagery.Core.Interfaces.Observer;

namespace Bagery.Business.Observers
{
    public class NotificationSubject : INotificationSubject
    {
        private readonly List<INotificationObserver> _observers;

        public NotificationSubject()
        {
            _observers = new List<INotificationObserver>();
        }

        public void Attach(INotificationObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(INotificationObserver observer)
        {
            _observers.Remove(observer);
        }

        public async Task NotifyObserverAsync(Promotion promotion)
        {
            foreach (var observer in _observers)
            {
                await observer.UpdateAsync(promotion);
            }
        }
    }
}
