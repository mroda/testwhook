using System;

namespace mrodaAzureTest.Models
{
    public class BlobItem
    {
        public string Uri { get; set; }
        public string ContentType { get; set; }
        public DateTime LastModified { get; set; }
        public string BlobType { get; set; }
    }
}