using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;

public class BetButtonsMediator : EventMediator {
    private const string TAG = "BetButtonsMediator";
    
    [Inject]
    public BetButtonsView betView { get; set; }
    [Inject]
    public IBet bet { get; set; }
    [Inject]
    public UpdateBetSignal updateBetSignal { get; set; }
    
    public override void OnRegister() {
        betView.Init();
        betView.betSignal.AddListener(OnBetClicked); 
    }
    
    void OnBetClicked(float value) {
        bet.UpdateBetAmount(value);

        updateBetSignal.Dispatch();
    }
}

