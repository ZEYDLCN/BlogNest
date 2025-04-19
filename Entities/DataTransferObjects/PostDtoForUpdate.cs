using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record PostDtoForUpdate : PostDtoForManipulation
    {
        [Required]
        public int Id { get; init; }  // Blog yazısı ID'si (Primary Key)
    }
    
}
