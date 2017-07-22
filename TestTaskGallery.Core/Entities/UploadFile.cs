﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskGallery.Core.Entities
{
    public class UploadFile
    {
        public int Id { get; set; }

        public byte[] Photo { get; set; }
        public Nullable<int> UserId { get; set; }
        public User User { get; set; }
    }
}
