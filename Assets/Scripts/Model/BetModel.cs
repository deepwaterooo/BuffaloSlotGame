using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetModel : IBet {
    private const string TAG = "BetModel";
    
    
    private float _prevBet;
    private float _currBet;

    public float prevBet {
        get {
            return _prevBet;
        }
    }
    
    public float currBet {
        get {
            return _currBet;
        }
    }

    public BetModel() {
        _prevBet = 0.75f;
        _currBet = 3.00f;
    }

    public void UpdateBetAmount(float value) {
        _prevBet = _currBet;
        _currBet = value;
        Debug.Log(TAG + ": UpdateBetAmount() _currBet: " + _currBet); 
    }
}
