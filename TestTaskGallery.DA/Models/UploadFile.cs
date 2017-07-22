using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskGallery.DA.Models
{
    public class UploadFile
    {
        public int Id { get; set; }

        public byte[] Photo { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
