using System.Collections;
using System.Collections.Generic;
using Calculator;
using ErrorDialog;
using Localization;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private StringsContainer stringsContainer;
    public override void InstallBindings()
    {
        Container.Bind<StringsContainer>()
        .FromScriptableObject(stringsContainer)
        .AsSingle()
        .NonLazy();

        Container.Bind<ICalculatorModel>()
            .To<CalculatorModel>().AsSingle();
        Container.Bind<ICalculatorView>()
            .To<CalculatorView>()
            .FromComponentInHierarchy()
            .AsTransient();

        Container.Bind<IErrorDialogView>()
            .To<ErrorDialogView>()
            .FromComponentInHierarchy()
            .AsTransient();
        
        Container.Bind<CalculatorPresenter>().AsTransient().NonLazy();
    }
}
