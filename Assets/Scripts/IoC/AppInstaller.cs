using LoLRunes.Application.Services;
using LoLRunes.Domain.Interfaces;
using LoLRunes.Domain.Repositories;
using LoLRunes.Domain.Services;
using LoLRunes.Infra;
using LoLRunes.Infra.Core;
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
        Container.Bind<RunePageService>().AsSingle();

        //Domain WindowInteraction
        Container.Bind<ICalibrationService>().To<CalibrationService>().AsSingle();
        Container.Bind<IRunePagePositionService>().To<RunePagePositionService>().AsSingle();     
        Container.Bind<ILeagueWindowInteractionService>().To<LeagueWindowInteractionService>().AsSingle();
        Container.Bind<IWindowCalibrationService>().To<WindowCalibrationService>().AsSingle();
        
        //Aplication
        Container.Bind<CalibrationAppService>().AsSingle();
        Container.Bind<RunePageAppService>().AsSingle();
    }
}