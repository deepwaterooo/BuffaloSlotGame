using System;
using UnityEngine;
using strange.extensions.context.impl;

public class SlotsRoot : ContextView {
    private const string TAG = "SlotsRoot";
    
    void Awake() {
        Debug.Log(TAG + ": Awake() bgn"); 
        this.context = new SlotsGameContext(this); // change this one to something else
        Debug.Log(TAG + ": Awake() end"); 
    }
}
