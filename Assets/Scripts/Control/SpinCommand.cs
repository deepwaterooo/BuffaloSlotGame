using System;
using UnityEngine;

using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class SpinCommand : Command { 
    private const string TAG = "SpinCommand";

    [Inject]
    public ISomeSpin spin { get; set; }
    
    public override void Execute() {
        spin.Spin();
    }
}
