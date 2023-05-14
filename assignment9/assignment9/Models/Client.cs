using System.ComponentModel.DataAnnotations;

namespace assignment9.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public Client() { }
        public Client(string clientName)
        {
            ClientId = BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);
            ClientName = clientName;
        }
        public override string ToString()
        {
            return $"客户名为{ClientName}";
        }
    }
}
