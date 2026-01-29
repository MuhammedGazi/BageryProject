using Bagery.Core.Entities;

namespace Bagery.Core.Interfaces.Observer
{
    public interface INotificationSubject
    {
        void Attach(INotificationObserver observer);
        void Detach(INotificationObserver observer);
        Task NotifyObserverAsync(Promotion promotion);
    }
}
