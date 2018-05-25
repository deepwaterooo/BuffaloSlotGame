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

        commandBinder.Bind<StartSignal>().To<GameViewInitiateCommand>().Once();  // execute only once
        //commandBinder.Bind<SpinSignal>().To<SpinCommand>().Pooled();
        
        injectionBinder.Bind<IBet>().To<BetModel>().ToSingleton();    

        injectionBinder.Bind<IScore>().To<ScoreModel>().ToSingleton();    
        injectionBinder.Bind<ICredit>().To<CreditModel>().ToSingleton();
        injectionBinder.Bind<IScore>().To<ScoreModel>().ToName("ScoreModel");
        injectionBinder.Bind<ICredit>().To<CreditModel>().ToName("CreditModel");

        injectionBinder.Bind<StartSpin>().ToSingleton();  
        injectionBinder.Bind<StopSpin>().ToSingleton();                

        injectionBinder.Bind<UpdateBetSignal>().ToSingleton();
        injectionBinder.Bind<Spin_Button_Clicked_Signal>().ToSingleton();
        injectionBinder.Bind<Bet_More_Round_Signal>().ToSingleton();
        injectionBinder.Bind<Start_Force_Stop_Signal>().ToSingleton();

        injectionBinder.Bind<Update_Game_Result_Signal>().ToSingleton();
        injectionBinder.Bind<CHANGE_SCORE_Signal>().ToSingleton();  
        injectionBinder.Bind<CHANGE_CREDIT_Signal>().ToSingleton();
        injectionBinder.Bind<Game_Update_Done_Signal>().ToSingleton();
        
        mediationBinder.Bind<SlotView>().To<SlotMediator>();
        mediationBinder.Bind<GameView>().To<GameMediator>();
        mediationBinder.Bind<BetButtonsView>().To<BetButtonsMediator>();  
        mediationBinder.Bind<BetView>().To<BetMediator>();                
        mediationBinder.Bind<SpinView>().To<SpinMediator>();              
        
        mediationBinder.Bind<ScoreTextView>().To<ScoreTextMediator>(); 
        mediationBinder.Bind<CreditTextView>().To<CreditTextMediator>(); 

        //StartSpinSec spin = GameObject.Find("spinButton").GetComponent<StartSpinSec>(); //SPIN
        //injectionBinder.Bind<ISomeSpin>().ToValue(spin);
    }
}
