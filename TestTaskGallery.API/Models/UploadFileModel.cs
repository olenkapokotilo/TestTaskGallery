using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;

namespace TestTaskGallery.API.Models
{
    public class UploadFileModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public Nullable<int> UserId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public UserModel User { get; set; }
    }
}