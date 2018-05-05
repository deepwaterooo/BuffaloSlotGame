using System;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class ChangeCreditCommand : EventCommand {

    [Inject("CreditModel")]
    public IScore Credit { get; set; }

    public override void Execute() {
        float value = (float)evt.data;
        //float newCredit = Credit.AddCredit(value);
        float newCredit = Credit.AddScore(value); // AddCredit()
    }
}
