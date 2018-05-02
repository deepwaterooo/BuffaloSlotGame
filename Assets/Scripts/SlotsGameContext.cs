using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class SlotsGameContext : SlotsContext {

    public SlotsGameContext(MonoBehaviour view) : base(view) { }
    
    protected override void mapBindings() {
        base.mapBindings();

        commandBinder.Bind<StartSignal>().To<GameViewInitiateCommand>().Once(); // execute only once
        commandBinder.Bind<SpinSignal>().To<SpinCommand>().Pooled();
        
        
        injectionBinder.Bind<IScore>().To<ScoreModel>().ToSingleton();    
        injectionBinder.Bind<ICredit>().To<CreditModel>().ToSingleton();  
        injectionBinder.Bind<StartSpin>().ToSingleton();               
        injectionBinder.Bind<StopSpin>().ToSingleton();                

        mediationBinder.Bind<LeverView>().To<LeverMediator>();            
        mediationBinder.Bind<SlotView>().To<SlotMediator>();
        mediationBinder.Bind<GameView>().To<GameMediator>();
        
        mediationBinder.Bind<ScoreTextView>().To<ScoreTextMediator>(); 
        mediationBinder.Bind<CreditTextView>().To<CreditTextMediator>(); 
        mediationBinder.Bind<SlotObjectView>().To<SlotObjectMediator>();
        mediationBinder.Bind<MainUIView>().To<MainUIViewMediator>();

        //commandBinder.Bind(Events.CHANGE_SCORE).InSequence().To<ChangeScoreCommand>(); //.To<ChangeCreditCommand>();
        //commandBinder.Bind(Events.CHANGE_CREDIT).To<ChangeCreditCommand>();

        //commandBinder.Bind(NotificationCenter.SPIN).To<SpinCommand>();
        //commandBinder.Bind(NotificationCenter.VOLUMN).To<VolumnCommand>();

        StartSpinSec spin = GameObject.Find("SPIN").GetComponent<StartSpinSec>();
        injectionBinder.Bind<ISomeSpin>().ToValue(spin);
    }
}
