using CodeBase.Data;

namespace CodeBase.Services
{
    public interface IProgressBeforeSaveHandler
    {
        void UpdateProgressBeforeSave(PlayerProgress playerProgress);
    }
}
