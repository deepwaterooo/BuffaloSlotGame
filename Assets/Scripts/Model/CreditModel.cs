using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditModel : ICredit {

    private float _score;

    public float Credit {
        get {
            return _score;
        }
    }

    public CreditModel() {
        _score = 0f;
    }

    public float AddCredit(float value) {
        _score += value;
        return Credit;
    }
}
