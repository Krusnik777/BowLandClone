using CodeBase.Infrastructure.DependencyInjection;
using UnityEngine.Events;

namespace CodeBase.Services
{
    public interface IAdsService : IService
    {
        void Initialize();
        void LoadInterstital();
        void LoadRewarded();
        void ShowInterstital();
        void ShowRewarded(UnityAction videoCompleted);

        bool IsRewardedVideoReady {  get; }
    }
}