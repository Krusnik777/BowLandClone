namespace CodeBase.Infrastructure.DependencyInjection
{
    public class TestInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            dIContainer.RegisterSingle<Service1>();
            //ProjectContext.Container.RegisterSingle<Service2>();
        }
    }
}
