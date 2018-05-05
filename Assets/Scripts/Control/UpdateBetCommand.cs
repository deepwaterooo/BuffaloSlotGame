using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

public class UpdateBetCommand : Command {
    private const string TAG = "UpdateBetCommand";

    [Inject]
    public IBet betAmount { get; set; }
    
    public override void Execute() {
        Debug.Log(TAG + ": Execute() bgn"); 
        float value = (float)data;
        betAmount.UpdateBetAmount(value);
        Debug.Log("currBetAmount: " + betAmount.currBet);
        Debug.Log(TAG + ": Execute() end"); 
    }
}
