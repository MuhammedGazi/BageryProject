using Bagery.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagery.Core.Interfaces.Observer
{
    public interface INotificationObserver
    {
        Task UpdateAsync(Promotion promotion);
    }
}
