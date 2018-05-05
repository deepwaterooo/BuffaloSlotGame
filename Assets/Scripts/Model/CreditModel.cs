using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class CreditModel : ICredit {
public class CreditModel : IScore{
    
    private float _score;

    public float Score {
        get {
            return _score;
        }
    }

    public CreditModel() {
        _score = 0f;
    }

    public float AddScore(float value) {
        _score += value;
        return Score;
    }
}
