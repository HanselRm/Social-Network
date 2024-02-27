

namespace SocialNet.Core.Application.Interfaces.Services
{
    internal interface IGenericServices
    {
        public interface IGenericServices<T> where T : class
        {
            Task Update(T vm);
            Task<T> Add(T vm);
            Task Delete(int id);
            Task<T> GetByIdSaveViewModel(int id);
            Task<List<T>> GetAllViewModels();

        }
    }
}
