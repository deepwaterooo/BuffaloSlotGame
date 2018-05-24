using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class CreditModel : ICredit {
public class CreditModel : ICredit{
    private const string TAG = "CreditModel";
    
    private float _credit;

    public float Credit {
        get {
            return _credit;
        }
    }

    public CreditModel() {
        _credit = 0f;
    }

    public void AddCredit(float value) {
        _credit += value;
        //Debug.Log(TAG + ": AddCredit() _credit: " + _credit); 
    }
}
