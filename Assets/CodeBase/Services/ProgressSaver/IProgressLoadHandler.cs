using CodeBase.Data;

namespace CodeBase.Services.ProgressSaver
{
    public interface IProgressLoadHandler
    {
        void Load(PlayerProgress playerProgress);
    }
}
