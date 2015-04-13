using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace mrodaAzureTest.Services
{
    public class BlobStorageService : StorageBaseService
    {
        public BlobStorageService(): base() { }
                
        public IEnumerable<CloudBlockBlob> GetBlobItems()
        {
            var blobs = this.Container.ListBlobs(null, true, BlobListingDetails.All).Cast<CloudBlockBlob>();
            return blobs;
        }

        public void UploadFile(HttpPostedFileBase file)
        {
            CloudBlockBlob blob = this.Container.GetBlockBlobReference(Path.GetFileName(file.FileName));
            blob.Properties.ContentType = file.ContentType;
            blob.UploadFromStream(file.InputStream);
        }

        public void Delete(string fileName)
        {
            var blob = this.Container.GetBlockBlobReference(fileName);
            if (blob != null)
                blob.Delete();
        }
    }
}