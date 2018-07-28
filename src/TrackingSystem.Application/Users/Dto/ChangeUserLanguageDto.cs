using System.ComponentModel.DataAnnotations;

namespace TrackingSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}