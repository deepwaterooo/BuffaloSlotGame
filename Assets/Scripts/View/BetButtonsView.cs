using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.signal.impl;

public class BetButtonsView : View {
    private const string TAG = "BetButtonsView";
    
    // 通过[Inject],我们可以得到dispatcher = strangeioc的事件分发器
    // 如果没有[Inject], dispatcher的值 == null
    [Inject]
    public IEventDispatcher dispatcher { get; set; }    

    public BetSignal betSignal = new BetSignal(); // 直接实例信号进行派发

    public float prevBetAmount = 3.0f;
    public float currBetAmount = 1.50f;
    
    private Rect bet1Rect = new Rect(250, 465, 50, 50); 
    private Rect bet2Rect = new Rect(310, 465, 50, 50); 
    private Rect bet3Rect = new Rect(370, 465, 50, 50); 
    private Rect bet4Rect = new Rect(430, 465, 50, 50); 
    private Rect bet5Rect = new Rect(490, 465, 50, 50); 
    
    public float CurrBetAmount {
        get {
            return currBetAmount;
        }
    }
    
    void OnGUI() { // SPIN:  510, 465, 50, 50
        if (GUI.Button(bet1Rect, "Bet\n$0.75")) { // "Bet\n$0.75" to look better
            prevBetAmount = currBetAmount;
            currBetAmount = 0.75f;
            betSignal.Dispatch(currBetAmount);
        } else if (GUI.Button(bet2Rect, "Bet\n$1.50")) { // "Bet\n$0.75" to look better
            prevBetAmount = currBetAmount;
            currBetAmount = 1.50f;
            betSignal.Dispatch(currBetAmount);
        } else if (GUI.Button(bet3Rect, "Bet\n$2.25")) { // "Bet\n$0.75" to look better
            prevBetAmount = currBetAmount;
            currBetAmount = 2.25f;
            betSignal.Dispatch(currBetAmount);
        } else if (GUI.Button(bet4Rect, "Bet\n$3.00")) { // "Bet\n$0.75" to look better
            prevBetAmount = currBetAmount;
            currBetAmount = 3.00f;
            betSignal.Dispatch(currBetAmount);
        } else if (GUI.Button(bet5Rect, "Bet\n$3.75")) { // "Bet\n$0.75" to look better
            prevBetAmount = currBetAmount;
            currBetAmount = 3.75f;
            betSignal.Dispatch(currBetAmount);
        }
    }
}
