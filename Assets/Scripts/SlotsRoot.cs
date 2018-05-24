using System;
using UnityEngine;
using strange.extensions.context.impl;

public class SlotsRoot : ContextView {
    
    void Awake() {
        context = new SlotsGameContext(this); 
    }
}
