using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;

public class BetMediator : EventMediator {
    private const string TAG = "BetMediator";

    [Inject]
    public BetView betView { get; set; }
    [Inject]
    public IBet bet { get; set; }
    [Inject]
    public UpdateBetSignal updateBetSignal { get; set; }
    
    public override void OnRegister() {
        UpdateListeners(true);
        betView.Init();
    }

    public override void OnRemove() {
        UpdateListeners(false);
    }

    private void UpdateListeners(bool value) {
        updateBetSignal.AddListener(BetChanged); // not StopSpin signal, other signal
    }

    private void BetChanged() {
        Debug.Log(TAG + ": BetChanged() bet.currBet: " + bet.currBet); 
        betView.ChangeBetText(bet.currBet); 
    }    
}
