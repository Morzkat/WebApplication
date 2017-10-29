using System.ComponentModel.DataAnnotations;

namespace BuyYourMovie.Models
{
    //Interface for all models make sure they have a id
    public interface ModelsClass
    {
        [Key]
        int id { get; set; }
    }
}
