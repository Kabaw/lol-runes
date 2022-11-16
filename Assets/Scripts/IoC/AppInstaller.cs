using LoLRunes.Application.Services;
using LoLRunes.Domain.Interfaces;
using LoLRunes.Domain.Repositories;
using LoLRunes.Domain.Services;
using LoLRunes.Infra.Core;
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
        
        //Infra
        Container.Bind<IRunePageRepository>().To<RunePageRepository>().AsSingle();
        //Container.Bind<IInspectorDataProvider>().To<InspectorDataProvider>().FromInstance(inspectorDataProvider);
    }
}