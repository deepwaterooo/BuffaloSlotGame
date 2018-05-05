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
        Debug.Log(TAG + ": Launch() bgn"); 
        base.Launch();
        
        Signal startSignal = injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
        Debug.Log(TAG + ": Launch() end"); 
    } 
/*
    protected override void mapBindings() {
        base.mapBindings();

        commandBinder.Bind<StartSignal>().To<GameViewInitiateCommand>().Once(); // execute only once
        commandBinder.Bind<SpinSignal>().To<SpinCommand>().Pooled();
        
        injectionBinder.Bind<IBet>().To<BetModel>().ToSingleton();    
        injectionBinder.Bind<IScore>().To<ScoreModel>().ToSingleton();    
        //injectionBinder.Bind<ICredit>().To<CreditModel>().ToSingleton();
        injectionBinder.Bind<IScore>().To<ScoreModel>().ToName("ScoreModel");
        injectionBinder.Bind<IScore>().To<CreditModel>().ToName("CreditModel");
        
        injectionBinder.Bind<StartSpin>().ToSingleton();  //             
        injectionBinder.Bind<StopSpin>().ToSingleton();                
        injectionBinder.Bind<CHANGE_SCORE_Signal>().ToSingleton();  
        injectionBinder.Bind<CHANGE_CREDIT_Signal>().ToSingleton();                
        
        mediationBinder.Bind<LeverView>().To<LeverMediator>();            
        mediationBinder.Bind<SlotView>().To<SlotMediator>();
        mediationBinder.Bind<BetButtonsView>().To<BetButtonsMediator>();   // BetButtonsView: BetButtons buttons
        mediationBinder.Bind<GameView>().To<GameMediator>(); // SpinView
        
        mediationBinder.Bind<ScoreTextView>().To<ScoreTextMediator>(); 
        mediationBinder.Bind<CreditTextView>().To<CreditTextMediator>(); 
        mediationBinder.Bind<SlotObjectView>().To<SlotObjectMediator>();
        mediationBinder.Bind<MainUIView>().To<MainUIViewMediator>();

        commandBinder.Bind(Events.CHANGE_SCORE).To<ChangeScoreCommand>(); //.To<ChangeCreditCommand>(); InSequence().
        commandBinder.Bind(Events.CHANGE_CREDIT).To<ChangeScoreCommand>(); //commandBinder.Bind(Events.CHANGE_CREDIT).To<ChangeCreditCommand>();
        //commandBinder.Bind(Events.CHANGE_SCORE).Bind(Events.CHANGE_CREDIT).To<ChangeScoreCommand>(); // Events --> Signals

        //commandBinder.Bind(CHANGE_SCORE_Signal).To<ChangeScoreCommand>(); // Events --> Signals
        //commandBinder.Bind(CHANGE_CREDIT_Signal).To<ChangeCreditCommand>(); // Events --> Signals
        
        //commandBinder.Bind(NotificationCenter.SPIN).To<SpinCommand>();
        //commandBinder.Bind(NotificationCenter.VOLUMN).To<VolumnCommand>();

        StartSpinSec spin = GameObject.Find("SPIN").GetComponent<StartSpinSec>();
        injectionBinder.Bind<ISomeSpin>().ToValue(spin);
        */      
        
/*
        commandBinder.Bind<StartSignal>().To<GameViewInitiateCommand>().Once(); // execute only once
        commandBinder.Bind<SpinSignal>().To<SpinCommand>().Pooled();
                
        injectionBinder.Bind<IScore>().To<ScoreModel>().ToSingleton();    
        injectionBinder.Bind<ICredit>().To<CreditModel>().ToSingleton();  
        injectionBinder.Bind<StartSpin>().ToSingleton();               
        injectionBinder.Bind<StopSpin>().ToSingleton();                

        mediationBinder.Bind<GameView>().To<GameMediator>();
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

        StartSpinSec spin = GameObject.Find("GameView").GetComponent<StartSpinSec>();
        injectionBinder.Bind<ISomeSpin>().ToValue(spin);
    }
*/        
}
