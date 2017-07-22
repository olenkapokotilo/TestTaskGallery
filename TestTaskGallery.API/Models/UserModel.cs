using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTaskGallery.API.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<UploadFileModel> UploadFiles { get; set; }
    }
}