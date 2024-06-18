using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services.GameFactory;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class CopyRotationCamera : MonoBehaviour
    {
        private IGameFactory gameFactory;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        private void Update()
        {
            if (gameFactory.FollowCamera == null) return;

            transform.LookAt(transform.position + gameFactory.FollowCamera.transform.rotation * Vector3.forward, gameFactory.FollowCamera.transform.rotation * Vector3.up);
        }
    }
}
