using System;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class ChangeCreditCommand : EventCommand {

    [Inject]
    public ICredit Credit { get; set; }

    public override void Execute() {
        float value = (float)evt.data;
        float newCredit = Credit.AddCredit(value);
    }
}
