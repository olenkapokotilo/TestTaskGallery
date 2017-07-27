using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskGallery.Core.Entities
{

    //todo: rename to fileUploadResult
    public class Result
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public UploadFile Photo { get; set; }
    }
}
