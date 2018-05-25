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
    [Inject]
    public StopSpin StopSpin { get; set; }
    [Inject]
    public Spin_Button_Clicked_Signal spinButtonClickedSignal { get; set; }
    
    public override void OnRegister() {
        UpdateListeners(true);
        view.Init();
    }

    public override void OnRemove() {
        UpdateListeners(false);
    }

    private void UpdateListeners(bool value) {
        //view.dispatcher.UpdateListener(value, SpinView.Click_Event, OnSpinClicked);
        spinButtonClickedSignal.AddListener(OnSpinClicked);
        
        //StopSpin.AddListener(OnSpinStop); // GameView init twice
    }

    private void OnSpinClicked() {
		//UpdateListeners(false); // 这句话根本就不会起作用
        //spinButtonClickedSignal.RemoveListener(OnSpinClicked); // can NOT do this

        StartSpin.Dispatch();
    }

/*    private void OnSpinStop() {
        OnRegister();
    }  */
}
