namespace EcommerceMVC.Models.UserDtos
{
    public class ResponseUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
