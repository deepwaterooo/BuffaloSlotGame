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
        //Debug.Log("bet.currBet: " + bet.currBet);  // initiate bet amount
        betView.ChangeBetText(bet.currBet);
    }

    public override void OnRemove() {
        UpdateListeners(false);
    }

    private void UpdateListeners(bool value) {
        //view.dispatcher.UpdateListener(value, betView.BET_CHANGED, OnBetChanged);
        updateBetSignal.AddListener(BetChanged); 
    }

    private void BetChanged() {
        betView.ChangeBetText(bet.currBet); 
    }    
}
