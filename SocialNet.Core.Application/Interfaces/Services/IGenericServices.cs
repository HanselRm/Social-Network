

namespace SocialNet.Core.Application.Interfaces.Services
{
        public interface IGenericServices<SaveViewModel> where SaveViewModel : class
        {
            Task Update(SaveViewModel vm);
            Task<SaveViewModel> Add(SaveViewModel vm);
            Task Delete(int id);
            Task<SaveViewModel> GetByIdSaveViewModel(int id);
            Task<List<SaveViewModel>> GetAllViewModels();

        }
    
}
