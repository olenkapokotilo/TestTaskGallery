using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskGallery.Core.Entities
{
    public class UploadFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; } //todo: why nullable?
        public User User { get; set; }
    }
}
