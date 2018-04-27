using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.api;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

public class SlotMediator : EventMediator {

    [Inject]
    public SlotView view { get; set; }
    [Inject]
    public StartSpin StartSpin { get; set; }
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
        view.dispatcher.UpdateListener(value, SlotView.STOP_SPIN, OnSpinStop);
        StartSpin.AddListener(OnSpinStart);
    }
    
    private void OnSpinStop() {
        dispatcher.Dispatch(Events.CHANGE_SCORE, view.WinScore);
        //dispatcher.Dispatch(Events.CHANGE_CREDIT, view.WinCredit); // solve this one after redesigned structure
        StopSpin.Dispatch();
    }

    private void OnSpinStart() {
        view.StartSpin();
    }
}
