using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;

public class ScoreTextMediator : EventMediator { // for Win Score
    private const string TAG = "ScoreTextMediator";
    
    [Inject]
    public ScoreTextView view { get; set; }
    [Inject]
    public StartSpin StartSpin { get; set; }
    [Inject]
    public StopSpin StopSpin { get; set; } 
    [Inject]
    public IScore score { get; set; }
    [Inject]
    public IBet bet { get; set; }
    
    [Inject]
    public CHANGE_SCORE_Signal change_score_signal { get; set; }
    
    public override void OnRegister() {
        UpdateListeners(true);
        view.Init();
    }

    public override void OnRemove() {
        UpdateListeners(false);
    }

    private void UpdateListeners(bool value) {
        StopSpin.AddListener(ScoreChanged);
        change_score_signal.AddListener(WinScoreAdded);
        StartSpin.AddListener(ResetWinScore);
    }

    private void WinScoreAdded(float value) {
        float currBet = bet.currBet;
        int multiplier = (int)(currBet / 0.75f);
        score.AddScore(value * multiplier);
        ScoreChanged(); 
    }

    private void ScoreChanged() {
        view.ChangeScoreText(score.Score);
    }

    private void ResetWinScore() {
        score.Reset(); 
        view.ChangeScoreText(score.Score);
    }
 }
