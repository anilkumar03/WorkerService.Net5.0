using System;
using System.IO;
using Microsoft.Extensions.Hosting;

namespace WorkerService5._0.Services
{
    public class UtilitiesService
    {
        private readonly IHostEnvironment _env;
        private const string LogFileName = "log.txt";
        
        public UtilitiesService(IHostEnvironment env)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
        }

        public void WriteLog(string text)
        {
            var filePath = Path.Combine(_env.ContentRootPath, LogFileName);
            if (!File.Exists(filePath))
            {
                using var myFile = File.Create(filePath);
                myFile.Dispose();
            }
            var writer = new StreamWriter(filePath, true);
            writer.WriteLine("DateTime: " + DateTimeOffset.Now.ToString("F"));
            writer.WriteLine(text);
            writer.WriteLine("*********************************************************");
            writer.Close();
        }
    }
}