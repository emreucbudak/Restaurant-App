using RestaurantDashboardApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Domain.Entities
{
    public class RestaurantCase : BaseEntity
    {
        public RestaurantCase()
        {
        }

        public RestaurantCase(string caseName, string caseSurname, string caseEmail, string casePassword, int restaurantId)
        {
            Name = caseName;
            Surname = caseSurname;
            Email = caseEmail;
            Password = casePassword;
            RestaurantId = restaurantId;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
