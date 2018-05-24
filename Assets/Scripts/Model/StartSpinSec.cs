using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpinSec : MonoBehaviour, ISomeSpin {
    private const string TAG = "StartSpinSec";
    
    private bool _isSpinning;

    [Inject]
    public StartSpin StartSpin { get; set; }
    
    public bool isSpinning {
        get {
            return _isSpinning;
        }
    }
    
    public StartSpinSec() {
        _isSpinning = true;
    }

    public void Spin() {
        //Debug.Log(TAG + ": Spin() start"); 
        StartSpin.Dispatch();
    }
}
