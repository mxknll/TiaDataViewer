using System;
using System.Runtime.Serialization;
using System.Windows;

namespace TiaDataViewer.Core.Exceptions
{
    // Gets thrown if the XML is valid but the file can not be viewed
    [Serializable]
    public class InvalidXmlStructureException : Exception
    {
        public InvalidXmlStructureException()
        {
            string message = "Die Struktur der ausgewählten Datei entspricht nicht der einer gültigen TIA Selection Tool Datei.";
            MessageBox.Show(message, "Fehler im XML Dokument", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public InvalidXmlStructureException(string message)
            : base(message)
        {
            MessageBox.Show(message, "Fehler im XML Dokument", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
