using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mrodaAzureTest.Services
{
    public class StorageBaseService
    {
        public StorageBaseService() { }

        CloudBlobContainer container = null;
        internal CloudBlobContainer Container
        {
            get
            {
                if (container == null)
                {
                    string connectionString = null;

                    //if (Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.IsAvailable)
                    //    connectionString = CloudConfigurationManager.GetSetting("DevStorageConnectionString");
                    //else
                    connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DevStorageConnectionString"].ConnectionString;

                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    container = blobClient.GetContainerReference("pictures");
                    container.CreateIfNotExists();
                    container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                    return container;
                }
                else
                    return container;
            }
        }
    }
}