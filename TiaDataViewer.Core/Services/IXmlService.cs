using System.Threading.Tasks;

namespace TiaDataViewer.Core.Services
{
    public interface IXmlService
    {
        Task<T> DeserializeXmlAsync<T>(string filePath) where T : class;
    }
}