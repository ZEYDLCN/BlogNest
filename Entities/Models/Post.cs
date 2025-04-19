using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    namespace BlogNest.Models
    {
        public class Post
        {
            public int Id { get; set; }  // Blog yazısı ID'si (Primary Key)
            public string Title { get; set; }  // Blog başlığı
            public string Content { get; set; }  // Blog içeriği
        }

    }

}
