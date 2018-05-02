using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceStopSpin : MonoBehaviour {
    private const string TAG = "ForceStopSpin";

    private bool _isSpinning;

    [Inject]
    public StopSpin StopSpin { get; set; }

    public bool isSpinning {
        get {
            return _isSpinning;
        }
    }

    public ForceStopSpin() {
        _isSpinning = false;
    }

    public void Spin() {
        StopSpin.Dispatch();
    }
}
