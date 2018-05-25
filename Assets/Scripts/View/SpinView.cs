using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine.UI;

public class SpinView : View {
    public const string TAG = "GameView";

    internal const string Click_Event = "Click_Event";
    
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    [Inject]
    public Spin_Button_Clicked_Signal spinButtonClickedSignal { get; set; }

    private Button spinButton; 

    internal void Init() {
        spinButton = gameObject.GetComponent<Button>();
    }

    public void SpinButtonClicked() {
        spinButtonClickedSignal.Dispatch();
    }
}
