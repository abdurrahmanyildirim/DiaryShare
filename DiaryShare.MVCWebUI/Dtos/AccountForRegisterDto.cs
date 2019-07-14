using System.ComponentModel.DataAnnotations;

namespace DiaryShare.MVCWebUI.Dtos
{
    public class AccountForRegisterDto
    {
        [Required(ErrorMessage = "Email adresi girmek zorunludur."), DataType(DataType.EmailAddress), RegularExpression(@"(?!.*\.\.)(^[^\.][^@\s]+@[^@\s]+\.[^@\s\.]+$)", ErrorMessage = "Lütfen geçerli bir E-Mail adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "İsim alanı boş bırakılamaz."), MaxLength(40, ErrorMessage = "İsim alanı 40 karakterden fazla olamaz.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim alanı boş bırakılamaz."), MaxLength(50, ErrorMessage = "Soyisim alanı 50 karakterden fazla olamaz.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur."),MaxLength(20,ErrorMessage ="Şifreniz 20 karakterden uzun olamaz.") ,MinLength(6, ErrorMessage = "."), DataType(DataType.Password), RegularExpression("^(?=.*[0-9]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z]{6,}$", ErrorMessage = "Şifreniz 6 karakterden uzun, harf ve sayı içermesi zorunludur.")]
        public string Password { get; set; }

    }
}