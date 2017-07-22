using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTaskGallery.MVC.Models
{
    public class UploadFileModel
    {
        public int Id { get; set; }

        public byte[] Photo { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}