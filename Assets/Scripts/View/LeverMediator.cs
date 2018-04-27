using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class LeverMediator : EventMediator {
    private const string TAG = "LeverMediator";

    [Inject]
    public LeverView view { get; set; }
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
        view.dispatcher.UpdateListener(value, LeverView.RELEASE_EVENT, OnViewRelease);

        StopSpin.AddListener(OnSpinStop);
    }

    private void OnViewRelease() {
        UpdateListeners(false);
        dispatcher.Dispatch(Events.CHANGE_CREDIT, view.BetCreditCost); // not working as expected     
        StartSpin.Dispatch();
    }

    public void OnSpinStop() {
        OnRegister();
    }
}
