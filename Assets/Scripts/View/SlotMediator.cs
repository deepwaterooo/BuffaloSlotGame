using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.api;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.signal.impl;

public class SlotMediator : EventMediator {
    private const string TAG = "SlotMediator";
    
    [Inject]
    public SlotView view { get; set; }
    [Inject]
    public Start_Force_Stop_Signal startOrForceStopSpinSignal { get; set; }
    //public StartSpin StartSpin { get; set; }
    [Inject]
    public StopSpin StopSpin { get; set; }

    public override void OnRegister() {
        UpdateListeners(true);
        view.Init();
    }

    public override void OnRemove() {
        UpdateListeners(false);
    }

    private void UpdateListeners(bool value) {
        //StartSpin.AddListener(OnSpinStart);
        startOrForceStopSpinSignal.AddListener(OnSpinStart);

        StopSpin.AddListener(OnSpinStop); 
    }

    private void OnSpinStop() {
        UpdateListeners(true); // 不起作用
        view.GameReset();
    }

    private void OnSpinStart() {
        view.StartSpin();
    }
}
