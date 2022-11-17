using LoLRunes.Application.Services;
using LoLRunes.Application.Services.Interfaces;
using LoLRunes.Domain.Repositories;
using LoLRunes.Domain.Services;
using LoLRunes.Domain.Services.Interfaces;
using LoLRunes.Infra;
using LoLRunes.Infra.Core;
using LoLRunes.LeagueClienteCommunication.Strategies.WindowInteraction.Services;
using LoLRunes.LeagueClienteCommunication.Strategies.WindowInteraction.Services.Interfaces;
using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller<AppInstaller>
{
    [SerializeField] InspectorDataProvider inspectorDataProvider;

    public override void InstallBindings()
    {
        //Infra
        Container.Bind<IInspectorDataProvider>().To<InspectorDataProvider>().FromInstance(inspectorDataProvider);
        Container.Bind<ICalibrationRepository>().To<CalibrationRepository>().AsSingle();
        Container.Bind<IRunePageRepository>().To<RunePageRepository>().AsSingle();

        //Domain Core
        Container.Bind<IRuneService>().To<RuneService>().AsSingle();
        Container.Bind<IRunePageService>().To<RunePageService>().AsSingle();

        //Domain WindowInteraction
        Container.Bind<ICalibrationService>().To<CalibrationService>().AsSingle();
        Container.Bind<IRunePagePositionService>().To<RunePagePositionService>().AsSingle();
        Container.Bind<ILeagueWindowInteractionService>().To<LeagueWindowInteractionService>().AsSingle();
        Container.Bind<IWindowCalibrationService>().To<WindowCalibrationService>().AsSingle();
        
        //Aplication
        Container.Bind<ICalibrationAppService>().To<CalibrationAppService>().AsSingle();
        Container.Bind<IRunePageAppService>().To<RunePageAppService>().AsSingle();
    }
}