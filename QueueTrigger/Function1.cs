using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace QueueTrigger
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")]string myQueueItem,
            [Blob("dev/{queueTrigger}",FileAccess.Read,Connection = "AzureWebJobsStorage")] Stream s
            , ILogger log)
        {
            StreamReader str = new StreamReader(s);
            log.LogInformation($"name: {myQueueItem}\n Size{s.Length} \n content:{str.ReadToEnd()}");
        }
    }
}
