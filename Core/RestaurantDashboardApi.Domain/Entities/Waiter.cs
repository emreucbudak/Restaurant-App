using RestaurantDashboardApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Domain.Entities
{
    public class Waiter : BaseEntity
    {
        public Waiter()
        {
        }

        public Waiter(string name, string surname, string email, string password, int? restaurantId, string phoneNumber, int waiterWorkStatusId)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            RestaurantId = restaurantId;
            PhoneNumber = phoneNumber;
            WaiterWorkStatusId = waiterWorkStatusId;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<Order> Orders { get; set; }
        public string PhoneNumber { get; set; }
        public int WaiterWorkStatusId   { get; set; }
        public WaiterWorkStatus WaiterWorkStatus { get; set; }

    }
}
