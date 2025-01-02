using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface ITranslationService
    {
        Task<string> TranslateAsync(string sourceLanguage, string targetLanguage, string textToTranslate, CancellationToken cancellationToken);
    }
}

