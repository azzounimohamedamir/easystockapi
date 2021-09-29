using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class LoginResponseDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
