using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mrodaAzureTest.Models
{
    public class BookEntity:TableEntity
    {
        public BookEntity()
        { }

        public string Name { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }
        public string ISBN { get; set; }

    }
}