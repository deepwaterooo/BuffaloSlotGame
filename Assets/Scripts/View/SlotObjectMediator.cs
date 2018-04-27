using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.mediation.impl;

public class SlotObjectMediator : Mediator {

    [Inject]
    public SlotObjectView view { get; set; }

    public override void OnRegister() {
        view.Init();
    }    
}
