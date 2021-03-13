using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using TestProject.AppSettings;
using TestProject.Framework.MongoDB.Models;

namespace TestProject.Framework.MongoDB.Helpers
{
    public class MongoDBHelpers
    {
        private static AppSetting _appSetting;
        private static IMongoDatabase _db;
        static MongoDBHelpers()
        {
            string currentDir = Directory.GetCurrentDirectory();
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(currentDir, "appSettings.json"), true, true)
                .AddJsonFile($"appSettings.{env}.json", true, true)
                .AddEnvironmentVariables();
            var config = builder.Build();
            _appSetting = config.Get<AppSetting>();
            MongoClient dbClient = new MongoClient(_appSetting.DbOptions.MongoDBConnectionString);
            _db = dbClient.GetDatabase(_appSetting.DbOptions.DatabaseName);
        }

        public static string InitDebugRecord(DebugTest debugTest, string collection = "Debug")
        {
            var collect = _db.GetCollection<DebugTest>(collection);
            collect.InsertOne(debugTest);
            return debugTest.Id;
        }

        public static void AddInfoForDebugCase(DebugTest debugTest, string collection = "Debug")
        {
            var debugCollection = _db.GetCollection<DebugTest>(collection);
            var currTest = debugCollection.Find<DebugTest>(doc => doc.Id == debugTest.Id).FirstOrDefault();
            currTest.Status = debugTest.Status;
            currTest.Log += "\n" + debugTest.Log;
            debugCollection.FindOneAndReplace<DebugTest>(doc => doc.Id == debugTest.Id, currTest);
        }
        public static void UpdatePassForDebugCase(DebugTest debugTest, string collection = "Debug")
        {
            var debugCollection = _db.GetCollection<DebugTest>(collection);
            var currTest = debugCollection.Find<DebugTest>(doc => doc.Id == debugTest.Id).FirstOrDefault();
            currTest.Status = debugTest.Status;
            currTest.EndAt = debugTest.EndAt;
            currTest.ExecuteTime = debugTest.ExecuteTime;
            debugCollection.FindOneAndReplace<DebugTest>(doc => doc.Id == debugTest.Id, currTest);
        }

        public static void UpdateFailForDebugCase(DebugTest debugTest, string collection = "Debug")
        {
            var debugCollection = _db.GetCollection<DebugTest>(collection);
            var currTest = debugCollection.Find<DebugTest>(doc => doc.Id == debugTest.Id).FirstOrDefault();
            currTest.Status = debugTest.Status;
            currTest.EndAt = debugTest.EndAt;
            currTest.ExecuteTime = debugTest.ExecuteTime;
            currTest.Log = debugTest.Log;
            currTest.ErrorMessage = debugTest.ErrorMessage;
            if (!string.IsNullOrEmpty(debugTest.ErrorTearDownScreenshot))
            {
                currTest.ErrorTearDownScreenshot = debugTest.ErrorTearDownScreenshot;
            }
            else
            {
                currTest.ErrorScreenshot = debugTest.ErrorScreenshot;
            }
            debugCollection.FindOneAndReplace<DebugTest>(doc => doc.Id == debugTest.Id, currTest);
        }

        public static ObjectId TakeScreenShotAndUpload(string filename)
        {
            IGridFSBucket bucket = new GridFSBucket(_db);
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
            var id = bucket.UploadFromBytes(filename, source);
            return id;
        }
    }
}
