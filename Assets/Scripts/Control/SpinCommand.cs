using System;
using UnityEngine;

using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class SpinCommand : Command { // EventCommand
    private const string TAG = "SpinCommand";

    //[Inject]
    //public StartSpin StartSpin { get; set; }
    //[Inject]
    //public StopSpin StopSpin { get; set; }
    
    [Inject]
    public ISomeSpin spin { get; set; }
    
    public override void Execute() {
        Debug.Log(TAG + ": Execute() bgn");
        Debug.Log(TAG + ": Execute() bef spin.Spin()");
        spin.Spin();
        Debug.Log(TAG + ": Execute() aft spin.Spin()");
/*
        Debug.Log(TAG + ": Execute() bef StartSpin.Dispatch()");
        StartSpin.Dispatch();
        Debug.Log(TAG + ": Execute() aft StartSpin.Dispatch()");
        */
        Debug.Log(TAG + ": Execute() end"); 
    }
}
