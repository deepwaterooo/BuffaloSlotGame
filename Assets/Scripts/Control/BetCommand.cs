using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.impl;

public class BetCommand : Command {
    private const string TAG = "BetCommand";
    
    [Inject]
    public UpdateBetSignal updateBetSignal { get; set; }

    public override void Execute() {
        Debug.Log(TAG + ": Execute() bgn"); 
        float value = (float)data;
        updateBetSignal.Dispatch(value);
        Debug.Log(TAG + ": Execute() end"); 
    }
}
