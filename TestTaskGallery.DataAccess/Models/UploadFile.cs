using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskGallery.DataAccess.Models
{
    public class UploadFile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Nullable<int> UserId { get; set; }
        public virtual User User { get; set; }
    }
}
