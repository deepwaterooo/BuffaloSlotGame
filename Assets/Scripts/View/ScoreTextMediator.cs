using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class ScoreTextMediator : EventMediator {
    private const string TAG = "ScoreTextView";
    
    [Inject]
    public ScoreTextView view { get; set; }
    [Inject]
    public StopSpin StopSpin { get; set; }
    [Inject("ScoreModel")]
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
        Debug.Log(TAG + ": ScoreChanged() score.Score: " + score.Score); 
        view.ChangeScoreText(score.Score); 
    }
}
