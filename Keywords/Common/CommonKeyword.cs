using OpenQA.Selenium;
using TestProject.Framework;
namespace TestProject.Keywords
{
    public class CommonKeyword
    {
        readonly IWebDriver driver;
        public CommonKeyword(IWebDriver driver)
        {
            this.driver = driver;
        }

        public CommonKeyword() {
        }

        /// <summary>
        /// author: Tindecken
        /// createdDate: 1/1/2020
        /// description: Clean Up
        /// </summary>
        /// <param name="sOptional">Optional. Exp: null</param>
        public void CleanUp(string sOptional)
        {
            // Nothing here, just a flag
        }
        /// <summary>
        /// author: Tindecken
        /// createdDate: 06/22/2020
        /// description: GotoURL
        /// </summary>
        /// <param name="sUrl">URL need to navigate. Exp: http://vnexpress.net</param>
        /// <param name="sOptional">Optional. Exp: null</param>
        public void GoToUrl(string sUrl, string sOptional)
        {
            //Process parameter with buffer
            sUrl = BufferUtils.getValueFromBuffer(sUrl);
            sOptional = BufferUtils.getValueFromBuffer(sOptional);
            driver.Navigate().GoToUrl(sUrl);
        }

        /// <summary>
        /// author: Tindecken
        /// createdDate: 06/30/2020
        /// updatedMessage: Update 1
        /// updatedMessage: Update 3
        /// description: Combine multiple variables then store it into buffer file with sKey.
        /// description: Line 2 of desc.
        /// </summary>
        /// <param name="sKey">Key Name to store the result of combine variables. Exp: SQLConnectionString</param>
        /// <param name="sValue1">Value 1. Exp:null</param>
        /// <param name="sValue2">Value 2. Exp:null</param>
        /// <param name="sValue3">Value 3. Exp:null</param>
        /// <param name="sValue4">Value 4. Exp:null</param>
        /// <param name="sValue5">Value 5. Exp:null</param>
        /// <param name="sValue6">Value 6. Exp:null</param>
        /// <param name="sValue7">Value 7. Exp:null</param>
        /// <param name="sValue8">Value 8. Exp:null</param>
        /// <param name="sValue9">Value 9. Exp:null</param>
        /// <param name="sValue10">Value 10. Exp:null</param>
        /// <param name="sValue11">Value 11. Exp:null</param>
        /// <param name="sValue12">Value 12. Exp:null</param>
        /// <param name="sValue13">Value 13. Exp:null</param>
        /// <param name="sValue14">Value 14. Exp:null</param>
        /// <param name="sValue15">Value 15. Exp:null</param>
        /// <param name="sValue16">Value 16. Exp:null</param>
        /// <param name="sValue17">Value 17. Exp:null</param>
        /// <param name="sValue18">Value 18. Exp:null</param>
        /// <param name="sOptional">Optional Exp:null</param>
        public void CombineVariables(string sKey, string sValue1, string sValue2, string sValue3, string sValue4, string sValue5, string sValue6, string sValue7, string sValue8, string sValue9, string sValue10, string sValue11, string sValue12, string sValue13, string sValue14, string sValue15, string sValue16, string sValue17, string sValue18, string sOptional)
        {
            sKey = BufferUtils.getValueFromBuffer(sKey);
            sValue1 = BufferUtils.getValueFromBuffer(sValue1);
            sValue2 = BufferUtils.getValueFromBuffer(sValue2);
            sValue3 = BufferUtils.getValueFromBuffer(sValue3);
            sValue4 = BufferUtils.getValueFromBuffer(sValue4);
            sValue5 = BufferUtils.getValueFromBuffer(sValue5);
            sValue6 = BufferUtils.getValueFromBuffer(sValue6);
            sValue7 = BufferUtils.getValueFromBuffer(sValue7);
            sValue8 = BufferUtils.getValueFromBuffer(sValue8);
            sValue9 = BufferUtils.getValueFromBuffer(sValue9);
            sValue10 = BufferUtils.getValueFromBuffer(sValue10);
            sValue11 = BufferUtils.getValueFromBuffer(sValue11);
            sValue12 = BufferUtils.getValueFromBuffer(sValue12);
            sValue13 = BufferUtils.getValueFromBuffer(sValue13);
            sValue14 = BufferUtils.getValueFromBuffer(sValue14);
            sValue15 = BufferUtils.getValueFromBuffer(sValue15);
            sValue16 = BufferUtils.getValueFromBuffer(sValue16);
            sValue17 = BufferUtils.getValueFromBuffer(sValue17);
            sValue18 = BufferUtils.getValueFromBuffer(sValue18);
            sOptional = BufferUtils.getValueFromBuffer(sOptional);
            string sCombineVars = $"{sValue1}{sValue2}{sValue3}{sValue4}{sValue5}{sValue6}{sValue7}{sValue8}{sValue9}{sValue10}{sValue11}{sValue12}{sValue13}{sValue14}{sValue15}{sValue16}{sValue17}{sValue18}";
            BufferUtils.setValueToBuffer(sKey, sCombineVars);
        }
    }
}
