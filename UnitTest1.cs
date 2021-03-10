using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using Newtonsoft.Json;
using NUnit.Framework;
using TestProject.AppSettings;

namespace TestFW
{

    public class Tests
    {
        private AppSetting _appSetting;
        public Tests()
        {
            string currentDir = Directory.GetCurrentDirectory();
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(currentDir, "appSettings.json"), true, true)
                .AddJsonFile($"appSettings.{env}.json", true, true)
                .AddEnvironmentVariables();
            var config = builder.Build();
            _appSetting = config.Get<AppSetting>();
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var client = new MongoClient(_appSetting.DbOptions.MongoDBConnectionString);
            var database = client.GetDatabase(_appSetting.DbOptions.DatabaseName);
            IGridFSBucket bucket = new GridFSBucket(database);
            byte[] source;
            using var bitmap = new Bitmap(1920, 1080);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(0, 0, 0, 0,
                    bitmap.Size, CopyPixelOperation.SourceCopy);
            }
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
                source = memoryStream.ToArray();
            }
            var id = bucket.UploadFromBytes("filename", source);

            Assert.Pass();
        }
    }
}