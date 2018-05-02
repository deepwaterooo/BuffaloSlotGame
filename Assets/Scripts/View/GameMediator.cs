using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;

public class GameMediator : Mediator {

    [Inject]
    public GameView view { get; set; }
    [Inject]
    public SpinSignal Spin { get; set; }

    public override void OnRegister() {
        view.spinButtonClicked.AddListener(Spin.Dispatch);
    }
}
