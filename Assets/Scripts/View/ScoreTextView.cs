using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class ScoreTextView : View {
    public const string SCORE_CHANGE = "SCORE_CHANGE";

    [Inject]
    public IEventDispatcher dispatcher {
        get;
        set;
    }

    private Text scoreText;

    public void Init() {
        scoreText = GetComponent<Text>();
        scoreText.text = "0";
    }

    public void ChangeScoreText(int score) {
        scoreText.text = score.ToString();
    }
}
