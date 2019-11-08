using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Interfaces
{
    public interface IMailingService
    {
        void Send(IMail mail);
    }
}
