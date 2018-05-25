using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel : IScore {
    private const string TAG = "ScoreModel";
    
    private float _score;

    public float Score {
        get {
            return _score;
        }
    }

    public ScoreModel() {
        _score = 0;
    }

    public void AddScore(float value) {
        _score += value;
    }

    public void Reset() {
        _score = 0f;
    }
}
