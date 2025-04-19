using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record PostDtoForManipulation
    {
        [Required]
        [MinLength(2,ErrorMessage = "Title too short, length must be between 2 and 50 characters.")]
        [MaxLength(50,ErrorMessage = "Title too long, length must be between 2 and 50 characters.")]
        public string Title { get; init; }  // Blog başlığı

        [Required]
        [MinLength(10, ErrorMessage = "Content too short, length must be between 10 and 300 characters.")]
        [MaxLength(300, ErrorMessage = "Content too long, length must be between 10 and 300 characters.")]
        public string Content { get; init; }  // Blog içeriği

    }
}
