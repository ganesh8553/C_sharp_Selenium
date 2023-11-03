using System;
using System.IO;
using System.Xml;

namespace BenefitPro1.Utilities
{
    public class GenerateFile
    {
        public string LogException(Exception exception, string dataMsg)
        {
            string filePath = "";
            if (exception != null)
            {
                string logsDirectory = Path.Combine(Environment.CurrentDirectory, "Logs");
                Directory.CreateDirectory(logsDirectory); // Create the directory if it doesn't exist
                filePath = Path.Combine(logsDirectory, Guid.NewGuid().ToString() + ".xml");
                using (XmlWriter xw = XmlWriter.Create(filePath))
                {
                    WriteException(xw, "exception", exception, dataMsg);
                }
            }
            return filePath;
        }

        private void WriteException(XmlWriter writer, string name, Exception exception, string dataMsg)
        {
            if (exception == null) return;
            writer.WriteStartElement(name);
            writer.WriteElementString("message", dataMsg + Environment.NewLine + exception.Message);
            writer.WriteElementString("source", exception.Source);
            writer.WriteElementString("Date", DateTime.Now.ToString());
            writer.WriteElementString("stackTrace", exception.StackTrace);
            WriteException(writer, "innerException", exception.InnerException);
            writer.WriteEndElement();
        }

        private void WriteException(XmlWriter writer, string name, Exception exception)
        {
            if (exception == null) return;
            writer.WriteStartElement(name);
            writer.WriteElementString("message", exception.Message);
            writer.WriteElementString("source", exception.Source);
            writer.WriteElementString("Date", DateTime.Now.ToString());
            writer.WriteElementString("stackTrace", exception.StackTrace);
            WriteException(writer, "innerException", exception.InnerException);
            writer.WriteEndElement();
        }
    }
}
