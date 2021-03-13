using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TestProject.Framework.MongoDB.Models
{
    [BsonIgnoreExtraElements]
    public class RegressionTest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RegressionId { get; set; }
        public string AnalyzedStatus { get; set; }
        public string AnalyzedMessage { get; set; }
        public string AnalyzedBy { get; set; }
        public string Issue { get; set; }
        public string IssueDescription { get; set; }
        [BsonElement]
        [JsonRequired]
        public string TestCaseId { get; set; }
        [JsonRequired]
        public string TestCaseName { get; set; }
        public string Description { get; set; }
        public string TestCaseType { get; set; }
        public string LastStatus { get; set; }
        public string Category { get; set; }
        public string TestSuite { get; set; }
        public string TestGroup { get; set; }
        public string Team { get; set; }
        public List<RegressionLog> Logs { get; set; }
        public string WorkItem { get; set; }
        public string Comments { get; set; }
    }
}
