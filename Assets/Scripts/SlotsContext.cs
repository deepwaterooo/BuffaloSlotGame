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

        injectionBinder.Bind<IScore>().To<ScoreModel>().ToSingleton();    
        injectionBinder.Bind<ICredit>().To<CreditModel>().ToSingleton();  
        injectionBinder.Bind<StartSpin>().ToSingleton();               
        injectionBinder.Bind<StopSpin>().ToSingleton();                

        mediationBinder.Bind<LeverView>().To<LeverMediator>();            
        mediationBinder.Bind<SlotView>().To<SlotMediator>();
        mediationBinder.Bind<ScoreTextView>().To<ScoreTextMediator>(); 
        mediationBinder.Bind<CreditTextView>().To<CreditTextMediator>(); 
        mediationBinder.Bind<SlotObjectView>().To<SlotObjectMediator>();
        mediationBinder.Bind<MainUIView>().To<MainUIViewMediator>();

        commandBinder.Bind(Events.CHANGE_SCORE).InSequence().To<ChangeScoreCommand>(); //.To<ChangeCreditCommand>();
        commandBinder.Bind(Events.CHANGE_CREDIT).To<ChangeCreditCommand>();
        commandBinder.Bind(NotificationCenter.SPIN).To<SpinCommand>();
        commandBinder.Bind(NotificationCenter.VOLUMN).To<VolumnCommand>();        
    }
}
