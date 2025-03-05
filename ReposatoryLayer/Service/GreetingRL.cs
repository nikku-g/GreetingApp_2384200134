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

        public GreetingMessage GetGreetingById(int id)
        {
            return _context.GreetingMessages.FirstOrDefault(g => g.Id == id); 
        }

        GreetingMessage IGreetingRL.SaveGreeting(GreetingMessage greetingMessage)
        {
            throw new NotImplementedException();
        }

        public GreetingMessage UpdateGreeting(GreetingMessage greetingMessage)
        {
            var existingGreeting = _context.GreetingMessages.FirstOrDefault(g => g.Id == greetingMessage.Id);
            if (existingGreeting != null)
            {
                existingGreeting.Message = greetingMessage.Message;
                _context.SaveChanges();  // Save the updated greeting message to the database
                return existingGreeting;
            }
            return null;

        }

        public bool DeleteGreeting(int id)
        {
            var greetingMessage = _context.GreetingMessages.FirstOrDefault(g => g.Id == id);
            if (greetingMessage != null)
            {
                _context.GreetingMessages.Remove(greetingMessage);
                _context.SaveChanges();
                return true;  // Successfully deleted
            }
            return false;  // Greeting message with the given id does not exist
        }
    }
}
