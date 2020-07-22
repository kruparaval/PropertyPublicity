using System.ComponentModel.DataAnnotations;

namespace OMTechStation.PropertyPublicity.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}