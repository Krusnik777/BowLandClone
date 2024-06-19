using CodeBase.Data;

namespace CodeBase.Services.ProgressSaver
{
    public interface IProgressBeforeSaveHandler
    {
        void UpdateProgressBeforeSave(PlayerProgress playerProgress);
    }
}
