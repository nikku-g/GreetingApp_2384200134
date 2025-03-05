using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReposatoryLayer.Context;
using ReposatoryLayer.Entity;
using ReposatoryLayer.Interface;

namespace ReposatoryLayer.Service
{
    public class GreetingRL : IGreetingRL
    {
        private readonly GreetingContext _context;

        public GreetingRL(GreetingContext context)
        {
            _context = context;
        }

        public void SaveGreeting(GreetingMessage greetingMessage)
        {
            _context.GreetingMessages.Add(greetingMessage);
            _context.SaveChanges();
        }

        public List<GreetingMessage> GetAllGreetings()
        {
            return _context.GreetingMessages.ToList();
        }

        GreetingMessage IGreetingRL.SaveGreeting(GreetingMessage greetingMessage)
        {
            throw new NotImplementedException();
        }
    }
}
