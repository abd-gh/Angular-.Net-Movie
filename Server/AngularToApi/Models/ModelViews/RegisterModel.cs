using System.ComponentModel.DataAnnotations;

namespace AngularToApi.Models.ModelViews
{
    public class RegisterModel
    {
        [StringLength(265),Required] //exactly like user table
        public string UserName { get; set; }

        [StringLength(265), Required, DataType(DataType.EmailAddress)] //exactly like user table
        public string Email { get; set; }

        [Required] //exactly like user table
        public string Password { get; set; }
    }
}
