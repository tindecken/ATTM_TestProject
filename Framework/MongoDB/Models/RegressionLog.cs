using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using NUnit.Framework;

namespace TestProject.Framework.MongoDB.Models
{
    [BsonIgnoreExtraElements]
    public class RegressionLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement]
        [JsonRequired]
        public string RegressionTestId { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public string Logs { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int ExecuteTime { get; set; }
        public string RunMachine { get; set; }
        public string ErrorScreenshot { get; set; }
        public string ErrorTearDownScreenshot { get; set; }
        public string Screenshot1 { get; set; }
        public string Screenshot2 { get; set; }
    }
}
