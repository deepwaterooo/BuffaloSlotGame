using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class CreditTextView : View {
    private const string TAG = "CreditTextView";
    
    public const string CREDIT_CHANGE = "CREDIT_CHANGE";

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    private Text creditText;

    public void Init() {
        creditText = GetComponent<Text>();
        creditText.text = "20.00";
    }

    public void ChangeCreditText(float credit) {
/*        Debug.Log(TAG + ": ChangeCreditText() creditText.text: " + creditText.text); 
        Debug.Log(TAG + ": ChangeCreditText() float.Parse(creditText.text): " + float.Parse(creditText.text));
        Debug.Log(TAG + ": ChangeCreditText() credit: " + credit); 
        */
        creditText.text = (float.Parse(creditText.text) + credit).ToString();
        //Debug.Log(TAG + ": ChangeCreditText() creditText.text: " + creditText.text); 
    }
}
