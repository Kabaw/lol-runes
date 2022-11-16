using LoLRunes.Application.Services;
using LoLRunes.Domain.Services;
using Zenject;

public class AppInstaller : MonoInstaller<AppInstaller>
{
    //[SerializeField] InspectorDataProvider inspectorDataProvider;

    public override void InstallBindings()
    {
        //Domain
        Container.Bind<IRuneService>().To<RuneService>().AsSingle();
        Container.Bind<RunePageService>().AsSingle();
        Container.Bind<LeagueWindowInteractionService>().AsSingle();
        Container.Bind<CalibrationService>().AsSingle();
        
        //Aplication
        Container.Bind<CalibrationAppService>().AsSingle();
        Container.Bind<RunePageAppService>().AsSingle();
        
        //Container.Bind<IRunePageRepository>().To<RunePageRepository>().AsSingle();
        //Container.Bind<IInspectorDataProvider>().To<InspectorDataProvider>().FromInstance(inspectorDataProvider);
    }
}