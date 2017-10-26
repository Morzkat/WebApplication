using System.ComponentModel.DataAnnotations;

namespace BuyYourMovie.Models
{
    //Interface for all models make sure they have a Id
    public interface ModelsClass
    {
        [Key]
        int Id { get; set; }
    }
}
