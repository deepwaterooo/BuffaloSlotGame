using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class ScoreTextMediator : EventMediator {

    [Inject]
    public ScoreTextView view { get; set; }
    [Inject]
    public StopSpin StopSpin { get; set; }
    [Inject]
    public IScore score { get; set; }

    public override void OnRegister() {
        UpdateListeners(true);
        view.Init();
    }

    public override void OnRemove() {
        UpdateListeners(false);
    }

    private void UpdateListeners(bool value) {
        StopSpin.AddListener(ScoreChanged);
    }

    private void ScoreChanged() {
        view.ChangeScoreText(score.Score); // score.Score() NO!!!  public int Score {}  in ScoreModel.cs
    }
}
