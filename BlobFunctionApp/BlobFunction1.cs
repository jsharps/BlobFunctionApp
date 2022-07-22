using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace BlobFunctionApp
{
    public class BlobFunction1
    {
        [FunctionName("BlobTrigger01")]
        [StorageAccount("BlobConnectionString")]
        public void Run([BlobTrigger("source-container/{name}")] Stream inputBlob,
                        [Blob("destination-container/{name}", FileAccess.Write)] Stream outputBlob,
                        string name, 
                        ILogger log)
        {
          
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {inputBlob.Length} Bytes");
            inputBlob.CopyTo(outputBlob);
            log.LogInformation($"C# Blob trigger function file copied to destination");
        }
    }
}
