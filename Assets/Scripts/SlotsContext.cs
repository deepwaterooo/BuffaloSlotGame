using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class SlotsContext : MVCSContext {

    public SlotsContext(MonoBehaviour view) : base(view) { }
    public SlotsContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags) { }

    protected override void mapBindings() {
        base.mapBindings();

        injectionBinder.Bind<IScore>().To<ScoreModel>().ToSingleton(); // 单例模式
        injectionBinder.Bind<StartSpin>().ToSingleton();               // 单例模式
        injectionBinder.Bind<StopSpin>().ToSingleton();                // 单例模式

        mediationBinder.Bind<LeverView>().To<LeverMediator>();
        mediationBinder.Bind<SlotView>().To<SlotMediator>();
        mediationBinder.Bind<ScoreTextView>().To<ScoreTextMediator>();  // 中介者模式
        mediationBinder.Bind<SlotObjectView>().To<SlotObjectMediator>();
        
        //mediationBinder.Bind<MainUIView>().To<MainUIViewMediator>();

        commandBinder.Bind(Events.CHANGE_SCORE).To<ChangeScoreCommand>();
        //commandBinder.Bind(NotificationCenter.SPIN).To<SpinCommand>();
        //commandBinder.Bind(NotificationCenter.VOLUMN).To<VolumnCommand>();        
    }
}
