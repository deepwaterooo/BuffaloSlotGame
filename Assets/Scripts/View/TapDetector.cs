using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using strange.extensions.mediation.impl;

public class TapDetector : EventView, IPointerDownHandler, IPointerUpHandler {

    public const string TAP = "TAP";
    public const string RELEASE = "RELEASE";
    
    public void OnPointerDown(PointerEventData eventData) {
        dispatcher.Dispatch(TAP);
    }

    public void OnPointerUp(PointerEventData eventData) {
        dispatcher.Dispatch(RELEASE);
    }
}
