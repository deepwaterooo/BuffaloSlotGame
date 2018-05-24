using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;

public class GameViewInitiateCommand : Command { 
    private const string TAG = "GameViewInitiateCommand";
    
    // 因为testroot继承于ContextView, 我们通过[Inject(ContextKeys.CONTEXT_VIEW)]这句逻辑便可以得到contextView = SlotsRoot;
    [Inject(ContextKeys.CONTEXT_VIEW)]
    public GameObject contextView { get; set; }
    
    public override void Execute() {
    }
}
