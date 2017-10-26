//User model
namespace BuyYourMovie.Models
{
    public class User : ModelsClass
    {
        public User(int id, string userEmail, string userPw)
        {
            this.Id = id;
            this.userEmail = userEmail;
            UserPw = userPw;
        }

        //User params
        public int Id { get; set; }
        public string userEmail { get; set; }
        public string UserPw { get; set; }
    }
}
