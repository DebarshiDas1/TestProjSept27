using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using TestProjSept27.Models;
using System.Net;

namespace TestProjSept27.Services
{
    /// <summary>
    /// Interface of FileService
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// It will upload/save files to blob container
        /// </summary>
        /// <param name = "tenantId">Tenant id</param>
        /// <param name = "entityName">Name of the target entity</param>
        /// <param name = "fieldName">Name of the target field</param>
        /// <param name = "files">List of files to be saved</param>
        /// <returns>List of file path of saved files</returns>
        Task<List<string>> SaveFiles(Guid tenantId, string entityName, string fieldName, List<IFormFile> files);
        /// <summary>
        /// It will delete files from blob container
        /// </summary>
        /// <param name = "filePaths">List of file path to be deleted</param>
        /// <returns>List of boolean status for each deleted file</returns>
        Task<List<bool>> DeleteFiles(List<string> filePaths);
    }

    /// <summary>
    /// Implementation of FileService
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// It will upload/save files to blob container
        /// </summary>
        /// <param name = "tenantId">Tenant id</param>
        /// <param name = "entityName">Name of the target entity</param>
        /// <param name = "fieldName">Name of the target field</param>
        /// <param name = "files">List of files to be saved</param>
        /// <returns>List of file path of saved files</returns>
        public async Task<List<string>> SaveFiles(Guid tenantId, string entityName, string fieldName, List<IFormFile> files)
        {
            List<string> filePath = new List<string>();
            var blobContainerClient = GetBlobContainerClient();
            foreach (var file in files)
            {
                var path = string.Empty;
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    path = $"{tenantId}/{entityName}/{fieldName}/{file.FileName}";
                    BlobClient cloudBlockBlob = blobContainerClient.GetBlobClient(path);
                    try
                    {
                        await cloudBlockBlob.DownloadContentAsync();
                        path = $"{tenantId}/{entityName}/{fieldName}/{GetTimeStamp()}/{file.FileName}";
                        cloudBlockBlob = blobContainerClient.GetBlobClient(path);
                    }
                    catch
                    {
                    }

                    var urlEncodedFileName = WebUtility.UrlEncode(file.FileName);
                    var metaData = new Dictionary<string, string> { { "title", urlEncodedFileName } };
                    var ms = new MemoryStream();
                    await file.CopyToAsync(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    await cloudBlockBlob.UploadAsync(ms, new BlobHttpHeaders { ContentType = file.ContentType }, metaData);
                    path = $"{blobContainerClient.Uri}/{path}";
                }

                filePath.Add(path);
            }

            return filePath;
        }

        /// <summary>
        /// It will delete files from blob container
        /// </summary>
        /// <param name = "filePaths">List of file path to be deleted</param>
        /// <returns>List of boolean status for each deleted file</returns>
        public async Task<List<bool>> DeleteFiles(List<string> filePaths)
        {
            List<bool> deleteStatus = new List<bool>();
            var blobContainerClient = GetBlobContainerClient();
            foreach (var path in filePaths)
            {
                var relativePath = path.Contains($"/{blobContainerClient.Name}/") ? path.Split($"/{blobContainerClient.Name}/")[1] : path;
                BlobClient cloudBlockBlob = blobContainerClient.GetBlobClient(relativePath);
                bool result = await cloudBlockBlob.DeleteIfExistsAsync();
                deleteStatus.Add(result);
            }

            return deleteStatus;
        }

        private static BlobContainerClient GetBlobContainerClient()
        {
            return new BlobContainerClient($"DefaultEndpointsProtocol=https;AccountName={AppSetting.AccountName};AccountKey={AppSetting.AccountKey};EndpointSuffix=core.windows.net", AppSetting.ContainerName);
        }

        private static string GetTimeStamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
    }
}