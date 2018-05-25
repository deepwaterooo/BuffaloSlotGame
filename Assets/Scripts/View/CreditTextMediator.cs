using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.signal.impl;

public class CreditTextMediator : EventMediator {
    private const string TAG = "CreditTextMediator";
    
    [Inject]
    public CreditTextView view { get; set; }
    [Inject]
    public Bet_More_Round_Signal betAnotherGameSignal { get; set; }
    [Inject]
    public CHANGE_CREDIT_Signal change_credit_signal { get; set; }
    
    [Inject]
    public IBet bet { get; set; }
    [Inject("CreditModel")]
    public ICredit credit { get; set; }

    public override void OnRegister() {
        UpdateListeners(true);
        view.Init();
    }

    public override void OnRemove() {
        UpdateListeners(false);
    }

    private void UpdateListeners(bool value) {             
        betAnotherGameSignal.AddListener(GameBetAnotherRound);
        change_credit_signal.AddListener(CreditChanged);
    }

    private void GameBetAnotherRound() {
        float betLoss = bet.currBet * (-1f);
        view.ChangeCreditText(betLoss);
    }

    private void CreditChanged(float value) {
        float currBet = bet.currBet;
        int multiplier = (int) (currBet / 0.75f);
        view.ChangeCreditText(value * multiplier);
    }
}
