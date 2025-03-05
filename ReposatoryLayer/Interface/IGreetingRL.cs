using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReposatoryLayer.Entity;

namespace ReposatoryLayer.Interface
{
    public interface IGreetingRL
    {
        GreetingMessage SaveGreeting(GreetingMessage greetingMessage);
        List<GreetingMessage> GetAllGreetings();
    }
}
