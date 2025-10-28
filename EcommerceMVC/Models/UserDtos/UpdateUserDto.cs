using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.Models.UserDtos
{
    public class UpdateUserDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        [Required]
        [StringLength(40)]
        public string Email { get; set; }
    }
}
