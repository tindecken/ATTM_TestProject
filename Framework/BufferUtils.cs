using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace TestProject.Framework
{
    public class BufferUtils
    {
        public static string getValueFromBuffer(string sKey)
        {
            if (sKey == null) return null;
            string sValue = sKey;
            if (Regex.Match(sKey, @"^%.*%$").Success)
            {
                XmlDocument xmlBuffer = new XmlDocument();
                xmlBuffer.Load(ProjectConstant.sBufferFile);
                XmlNode rootElement = xmlBuffer.DocumentElement;
                XmlNodeList lstBufferItem = rootElement.ChildNodes;
                foreach (XmlNode xmlBufferItem in lstBufferItem)
                {
                    if (xmlBufferItem.Attributes["Name"].Value.ToString().ToUpper().Equals(sKey.Substring(1, sKey.Length - 2).ToUpper()))
                    {
                        sValue = xmlBufferItem.Attributes["Value"].Value;
                        //Logger.Info($"[Key] {sKey}, [Value] {sValue}");
                        break;
                    }
                }
                //Logger.Info($"[NotFoundKey] {sKey} --> [Value] {sValue}");
            }

            return sValue;
        }
        public static void setValueToBuffer(string sKey, string sValue)
        {
            bool bAdded = false;
            XmlDocument xmlBuffer = new XmlDocument();
            xmlBuffer.Load(ProjectConstant.sBufferFile);
            XmlNode rootElement = xmlBuffer.DocumentElement;
            XmlNodeList lstBufferItem = rootElement.ChildNodes;
            // Check sKey is already exist ==> update value
            foreach (XmlNode xmlBufferItem in lstBufferItem)
            {
                if (xmlBufferItem.Attributes["Name"].Value.ToString().ToUpper().Equals(sKey.ToUpper()))
                {
                    xmlBufferItem.Attributes["Value"].Value = sValue;
                    xmlBufferItem.Attributes["CreatedAt"].Value = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                    bAdded = true;
                    break;
                }
            }
            if (!bAdded)
            { //Not exist sKey ==> add new sKey and sValue
                XmlElement addElement = xmlBuffer.CreateElement("Buffer");
                addElement.SetAttribute("Name", sKey);
                addElement.SetAttribute("Value", sValue);
                addElement.SetAttribute("CreatedAt", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
                rootElement.AppendChild(addElement);
            }
            xmlBuffer.Save(ProjectConstant.sBufferFile);
            //Logger.Info($"[Key] {sKey}, [Value] {sValue}");
        }
    }
}
