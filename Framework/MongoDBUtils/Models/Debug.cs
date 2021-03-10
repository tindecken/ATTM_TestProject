using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using NUnit.Framework.Interfaces;

namespace TestProject.Framework.MongoDBUtils.Models
{
    [BsonIgnoreExtraElements]
    public class Debug
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [JsonRequired]
        public string TestCaseId { get; set; }
        [JsonRequired]
        public string TestCaseName { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; }
        public string Category { get; set; }
        public string TestSuite { get; set; }
        public string TestCase { get; set; }
        public string ErrorMessage { get; set; }
        public string Log { get; set; }
        public DateTime SstartAt { get; set; }
        public DateTime EndAt { get; set; }
        public DateTime ExecuteTime { get; set; }

        public string RunMachine { get; set; }
        public string ErrorScreenshot { get; set; }
        public string Screenshot1 { get; set; }
        public string Screenshot2 { get; set; }
    }
}
