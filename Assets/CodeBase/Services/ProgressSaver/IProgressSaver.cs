using CodeBase.Infrastructure.DependencyInjection;
using UnityEngine;

namespace CodeBase.Services.ProgressSaver
{
    public interface IProgressSaver : IService
    {
        void AddObject(GameObject gameObject);
        void ClearObjects();
        void LoadProgress();
        void SaveProgress();
    }
}