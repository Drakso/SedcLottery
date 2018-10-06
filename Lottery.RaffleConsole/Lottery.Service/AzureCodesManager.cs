using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Lottery.Service
{
    public class AzureCodesManager : ICodesManager
    {
        private readonly IExcelManager _excelManager;

        public AzureCodesManager(IExcelManager excelManager)
        {
            _excelManager = excelManager;
        }

        public async void ProcessCodes()
        {
            var cloudStorageAccount = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=codesstorage;AccountKey=SfHe0RsrmCWxarOx+ayW4kcJzSaagIHk0eiRybwStibnWPJTSFrI5yhx8E7aShYM51xAb9pDxq7tBRNf1pi/HQ==;EndpointSuffix=core.windows.net");

            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            var cloudContainer = cloudBlobClient.GetContainerReference("codefiles");

            var filesList = await cloudContainer.ListBlobsSegmentedAsync(string.Empty, true, BlobListingDetails.None, 10,
                new BlobContinuationToken(), null, null);

            foreach (var listBlobItem in filesList.Results)
            {
                var blobItem = (CloudBlockBlob) listBlobItem;
                var fileBlob = cloudContainer.GetBlockBlobReference(blobItem.Name);

                var stream = new MemoryStream();
                await fileBlob.DownloadToStreamAsync(stream);

                _excelManager.ProcessExcelPackage(stream);

                await fileBlob.DeleteAsync();
            }
        }
    }
}
