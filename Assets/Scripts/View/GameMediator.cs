using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using UnityEngine.EventSystems;

public class GameMediator : Mediator {
    private const string TAG = "GameMediator";
    
    [Inject]
    public GameView view { get; set; }
    [Inject]
    public StopSpin StopSpin { get; set; }
    [Inject]
    public StartSpin StartSpin { get; set; }
    [Inject]
    public CHANGE_SCORE_Signal change_score_signal { get; set; }
    [Inject]
    public CHANGE_CREDIT_Signal change_credit_signal { get; set; }
    
    public override void OnRegister() {
        UpdateListeners(true);
        view.Init();
    }

    public override void OnRemove() {
        UpdateListeners(false);
    }

    private void UpdateListeners(bool value) {
        view.dispatcher.UpdateListener(value, GameView.STOP_SPIN, OnSpinStop);
        StartSpin.AddListener(OnSpinButtonClicked);
    }

    private void OnSpinButtonClicked() {
        view.isSlotsCurrentlySpinning();
    }

    private void OnSpinStop() {
        change_score_signal.Dispatch(view.WinScore);
        change_credit_signal.Dispatch(view.DeltaCredit);
        StopSpin.Dispatch();
    }
}
