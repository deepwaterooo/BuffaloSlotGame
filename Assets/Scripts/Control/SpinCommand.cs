using System;
using UnityEngine;

using strange.extensions.command.impl;
using strange.extensions.context.api;

public class SpinCommand : EventCommand {

    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }

    [Inject]
    public StartSpin StartSpin { get; set; }
    [Inject]
    public StopSpin StopSpin { get; set; }
    
    public override void Execute() {
        StartSpin.Dispatch();
    }
}
