﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskGallery.DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<UploadFile> UploadFiles { get; set; }

        public User()
        {
            UploadFiles = new List<UploadFile>();
        }
    }
}
