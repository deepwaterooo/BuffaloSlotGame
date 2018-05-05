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
    public StopSpin StopSpin { get; set; }
    
    [Inject("CreditModel")]
    public IScore credit { get; set; }

    public override void OnRegister() {
        UpdateListeners(true);
        view.Init();
    }

    public override void OnRemove() {
        UpdateListeners(false);
    }

    private void UpdateListeners(bool value) {
        StopSpin.AddListener(CreditChanged);
    }

    private void CreditChanged() {
        //Debug.Log(TAG + ": CreditChanged() credit.Credit: " + credit.Credit); 
        view.ChangeCreditText(credit.Score);  // credit.Credit
    }    
}
