using System;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class ChangeScoreCommand : EventCommand {

    [Inject]
    public IScore Score { get; set; }

    public override void Execute() {
        float value = (float)evt.data;
        float newScore = Score.AddScore(value);
        Debug.Log("Add Score: " + newScore);
    }
}
