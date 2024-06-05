using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.EntryPoints;
using CodeBase.Infrastructure.ServiceLocator;
using CodeBase.LevelStates;
using CodeBase.Services.LevelStateMachine;
using UnityEngine;

namespace CodeBase.Bootstrappers
{
    public class LevelBootstrapper : MonoBootstrapper
    {
        public override void Bootstrap()
        {
            ILevelStateSwitcher levelStateSwitcher = AllServices.Container.Single<ILevelStateSwitcher>();

            levelStateSwitcher.AddState(new LevelBootstrapState(
                AllServices.Container.Single<IAssetProvider>(),
                AllServices.Container.Single<HeroSpawnPoint>()
                ));

            levelStateSwitcher.Enter<LevelBootstrapState>();
        }
    }
}
