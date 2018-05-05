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
        commandBinder.Bind<BetSignal>().To<BetCommand>(); //.Pooled();
        commandBinder.Bind<UpdateBetSignal>().To<UpdateBetCommand>(); //.Pooled();
        
        injectionBinder.Bind<IBet>().To<BetModel>().ToSingleton();    
        //injectionBinder.Bind<IScore>().To<ScoreModel>().ToSingleton();    
        //injectionBinder.Bind<ICredit>().To<CreditModel>().ToSingleton();
        injectionBinder.Bind<IScore>().To<ScoreModel>().ToName("ScoreModel");
        injectionBinder.Bind<IScore>().To<CreditModel>().ToName("CreditModel");
        
        injectionBinder.Bind<StartSpin>().ToSingleton();  //             
        injectionBinder.Bind<StopSpin>().ToSingleton();                
        injectionBinder.Bind<CHANGE_SCORE_Signal>().ToSingleton();  
        injectionBinder.Bind<CHANGE_CREDIT_Signal>().ToSingleton();                
        
        mediationBinder.Bind<LeverView>().To<LeverMediator>();            
        mediationBinder.Bind<SlotView>().To<SlotMediator>();
        mediationBinder.Bind<BetView>().To<BetMediator>();   // BetView: Bet buttons
        mediationBinder.Bind<GameView>().To<GameMediator>(); // SpinView
        
        mediationBinder.Bind<ScoreTextView>().To<ScoreTextMediator>(); 
        mediationBinder.Bind<CreditTextView>().To<CreditTextMediator>(); 
        mediationBinder.Bind<SlotObjectView>().To<SlotObjectMediator>();
        mediationBinder.Bind<MainUIView>().To<MainUIViewMediator>();

        //commandBinder.Bind(Events.CHANGE_SCORE).To<ChangeScoreCommand>(); //.To<ChangeCreditCommand>(); InSequence().
        //commandBinder.Bind(Events.CHANGE_CREDIT).To<ChangeScoreCommand>(); //commandBinder.Bind(Events.CHANGE_CREDIT).To<ChangeCreditCommand>();
        //commandBinder.Bind(Events.CHANGE_SCORE).Bind(Events.CHANGE_CREDIT).To<ChangeScoreCommand>(); // Events --> Signals

        //commandBinder.Bind(CHANGE_SCORE_Signal).To<ChangeScoreCommand>(); // Events --> Signals
        //commandBinder.Bind(CHANGE_CREDIT_Signal).To<ChangeCreditCommand>(); // Events --> Signals
        // Bind(CHANGE_CREDIT_Signal).
        
        //commandBinder.Bind(NotificationCenter.SPIN).To<SpinCommand>();
        //commandBinder.Bind(NotificationCenter.VOLUMN).To<VolumnCommand>();

        StartSpinSec spin = GameObject.Find("SPIN").GetComponent<StartSpinSec>();
        injectionBinder.Bind<ISomeSpin>().ToValue(spin);
    }
}
