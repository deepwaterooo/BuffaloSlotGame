using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class SlotsContext : MVCSContext {

    public SlotsContext(MonoBehaviour view) : base(view) {
    }
    public SlotsContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags) {
    }

    protected override void mapBindings() {
        base.mapBindings();

        injectionBinder.Bind<IScore>().To<ScoreModel>().ToSingleton(); // 单例模式
        injectionBinder.Bind<StartSpin>().ToSingleton();               // 单例模式
        injectionBinder.Bind<StopSpin>().ToSingleton();                // 单例模式

        mediationBinder.Bind<ScoreTextView>().To<ScoreTextMediator>();  // 中介者模式

        commandBinder.Bind(Events.CHANGE_SCORE).To<ChangeScoreCommand>();
    }
}
