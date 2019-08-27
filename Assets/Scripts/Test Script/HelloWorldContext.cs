using System;
using UnityEngine;
using strange.extensions.context.impl;

public class HelloWorldContext : SignalContext
{
    public HelloWorldContext(MonoBehaviour contextView) : base(contextView)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();

        commandBinder.Bind<StartSignal>().To<HelloWorldStartCommand>().Once();
        mediationBinder.Bind<HelloWorldView>().To<HelloWorldMediator>();
        injectionBinder.Bind<ISomeManager>().To<ManagerAsNormalClass>().ToSingleton();
    }
}
