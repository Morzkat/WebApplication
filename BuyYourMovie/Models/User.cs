//User model
namespace BuyYourMovie.Models
{
    public class User : ModelsClass
    {
        public User(int Id, string userEmail, string userPw, string token, int level)
        {
            this.id = Id;
            this.userEmail = userEmail;
            this.userPw = userPw;
            this.token = token;
            this.level = level;
        }

        //User params
        public int id { get; set; }
        public string userEmail { get; set; }
        public string userPw { get; set; }
        public string token { get; set; }
        public int level { get; set; }
    }
}
