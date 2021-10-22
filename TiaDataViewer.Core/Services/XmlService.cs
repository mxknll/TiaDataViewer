using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace TiaDataViewer.Core.Services
{
    // Service to access XML-files
    public class XmlService : IXmlService
    {
        public async Task<T> DeserializeXmlAsync<T>(string filePath) where T : class
        {
            try
            {
                XmlSerializer serializer = new(typeof(T));

                using StreamReader streamReader = new(filePath);
                T output = (T)serializer.Deserialize(streamReader);
                return await Task.FromResult(output);
            }
            catch (Exception ex)
            {
                // In case of XML error show inner exception for details
                if (ex.HResult == -2146233079)
                {
                    MessageBox.Show(ex.InnerException.Message, "Fehler im XML Dokument", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Fehler beim Öffnen der Datei", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                throw;
            }

        }
    }
}
