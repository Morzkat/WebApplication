//User model
namespace BuyYourMovie.Models
{
    public class User : ModelsClass
    {
        public User(int Id, string userEmail, string userPw, string token)
        {
            this.Id = Id;
            this.userEmail = userEmail;
            this.userPw = userPw;
            this.token = token;
        }

        //User params
        public int Id { get; set; }
        public string userEmail { get; set; }
        public string userPw { get; set; }
        public string token { get; set; }
    }
}
