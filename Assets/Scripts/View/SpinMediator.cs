using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using UnityEngine.EventSystems;

public class SpinMediator : Mediator {
    private const string TAG = "SpinMediator";
    
    [Inject]
    public SpinView view { get; set; }
    [Inject]
    public StartSpin StartSpin { get; set; }
    //public SpinSignal Spin { get; set; }
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
        //view.dispatcher.UpdateListener(value, SpinView.Click_Event, OnSpinClicked);
        view.spinButtonClicked.AddListener(OnSpinClicked);
        StopSpin.AddListener(OnSpinStop);
    }

    private void OnSpinClicked() { 
        UpdateListeners(false);
        StartSpin.Dispatch();
    }

    private void OnSpinStop() {
        OnRegister();
    }
}
