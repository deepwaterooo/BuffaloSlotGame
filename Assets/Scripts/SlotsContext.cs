using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;

public class SlotsContext : MVCSContext {
    private const string TAG = "SlotsContext";
    
    public SlotsContext(MonoBehaviour contextView) : base(contextView) { }
    public SlotsContext(MonoBehaviour contextView, ContextStartupFlags flags) : base(contextView, flags) { }

    protected override void addCoreComponents() {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    public override void Launch() {
        base.Launch();
        
        Signal startSignal = injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
    } 
}
