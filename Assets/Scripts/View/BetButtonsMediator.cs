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
    
	// unity初始运行时,slotsroot的start方法实例context,然后strangeioc发出ContextEvent.START指令,通过指令与startcommand的绑定,执行startcommand逻辑生成新的GameObject
    // 当新的GameObject生成后,因为 mediationBinder.Bind<BetView>().To<BetMediator>();的绑定,BetMediator的onregister逻辑也会被出发.    
    public override void OnRegister() {
        betView.betSignal.AddListener(OnBetClicked); 

        // 现在当GameObject生成后给它添加一个监听,监听是否有点击发生,当有点击发生时,执行onclick方法.
        // betView.dispatcher.AddListener(Events.BET_EVENT, OnClick); // if I choose to use this method
    }
    
    void OnBetClicked(float value) {
        bet.UpdateBetAmount(value);

        updateBetSignal.Dispatch();
    }
}

