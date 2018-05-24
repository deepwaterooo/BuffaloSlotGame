using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.signal.impl;

public class BetButtonsView : View {
    private const string TAG = "BetButtonsView";
    
    [Inject]
    public IEventDispatcher dispatcher { get; set; }    

    public float CurrBetAmount {
        get {
            return currBetAmount;
        }
    }

    public Button[] betButtons;
    
    public BetSignal betSignal = new BetSignal(); // 直接实例信号进行派发

    public float prevBetAmount = 0.75f;
    public float currBetAmount = 3.75f;

    internal void Init() {
        betButtons[0].onClick.AddListener(() => betButtonsClickedCallback(betButtons[0]));
        betButtons[1].onClick.AddListener(() => betButtonsClickedCallback(betButtons[1]));
        betButtons[2].onClick.AddListener(() => betButtonsClickedCallback(betButtons[2]));
        betButtons[3].onClick.AddListener(() => betButtonsClickedCallback(betButtons[3]));
        betButtons[4].onClick.AddListener(() => betButtonsClickedCallback(betButtons[4]));
    }

    private void betButtonsClickedCallback(Button button) {
        prevBetAmount = currBetAmount;
        if (button == betButtons[0]) {
            currBetAmount = 0.75f;
        } else if (button == betButtons[1]) {
            currBetAmount = 1.50f;
        } else if (button == betButtons[2]) {
            currBetAmount = 2.25f;
        } else if (button == betButtons[3]) {
            currBetAmount = 3.00f;
        } else if (button == betButtons[4]) {
            currBetAmount = 3.75f;
        } 
        betSignal.Dispatch(currBetAmount);
    }
}
