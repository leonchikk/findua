using HtmlAgilityPack;
using System.Threading.Tasks;

namespace FindUa.ProxyGrabber.Core
{
    public interface IDataLoader
    {
        Task<HtmlDocument> LoadHtmlDocumentAsync(string url);
        Task<HtmlDocument> LoadHtmlDocumentWithFormDataAsync(string url, string encodedFormData);
    }
}
