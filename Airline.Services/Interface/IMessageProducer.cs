using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.Services.Interface
{
    public interface IMessageProducer
    {
        public void SendingMessages<T>(T message);
    }
}
