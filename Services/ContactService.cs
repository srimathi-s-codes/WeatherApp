using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class ContactService
    {
        private static readonly List<ContactMessage> _messages = new();

        public void SaveMessage(ContactMessage message)
        {
            message.Id = _messages.Count + 1;
            _messages.Add(message);
        }

        public List<ContactMessage> GetAllMessages()
        {
            return _messages.OrderByDescending(m => m.CreatedAt).ToList();
        }
    }
}