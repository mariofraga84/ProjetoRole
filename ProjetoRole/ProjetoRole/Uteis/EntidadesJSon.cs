using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Loucopido.Uteis
{
    class EntidadesJSon
    {
    }

    [DataContract]
    public class PostCrate
    {
        [DataMember(Name = "data")]
        public List<Post> Data { get; set; }

        [DataMember(Name = "paging")]
        public Paging Paging { get; set; }
    }

    [DataContract]
    public class Paging
    {
        [DataMember(Name = "previous")]
        public string Previous { get; set; }

        [DataMember(Name = "next")]
        public string Next { get; set; }
    }

    [DataContract]
    public class Post
    {
        [DataMember(Name = "id")]
        public string ID { get; set; }

        [DataMember(Name = "name1")]
        public string Name { get; set; }

        [DataMember(Name = "created_time")]
        public string CreatedTime { get; set; }
    }

    [DataContract]
    public class BaseUser
    {
        [DataMember(Name = "id")]
        public string ID { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
