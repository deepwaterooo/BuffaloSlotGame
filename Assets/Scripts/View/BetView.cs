using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.signal.impl;

public class BetView : View {
    private const string TAG = "BetView";
    
    [Inject]
    public IEventDispatcher dispatcher { get; set; }    

    private Text betText;

    public void Init() {
        betText = GetComponent<Text>();
        //betText.text = "0.75";
    }

    public void ChangeBetText(float betAmount) {
        betText.text = betAmount.ToString();
    }
}
