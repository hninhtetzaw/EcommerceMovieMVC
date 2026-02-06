namespace EcommerceMVC.Models.UserDtos
{
    public class ResponseUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public DateTime? CreatedDate { get; set; }

        public string RoleId { get; set; }

        //for verifypassword
        public string Password { get; set; }
    }
}
