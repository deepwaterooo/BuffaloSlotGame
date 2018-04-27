using System;
using System.Collections;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class LeverView : View {
    private const string TAG = "LeverView";
    
    internal const string RELEASE_EVENT = "RELEASE_EVENT";
    
    [Inject]
    public IEventDispatcher dispatcher { get; set; }
    
    private Vector3 origin;
    private GameObject lever;

    
    float betCreditCost = 0.75f; // 0.75f so far, need to figure out how to inject and get the value from button array???
    public float BetCreditCost {
        get {
            float newBetCredit = betCreditCost / 5.0f * (-1f); // cost ???
            //betCreditCost = 0f;
            Debug.Log(TAG + ": BetCreditCredit newBetCredit: " + newBetCredit); 
            return newBetCredit;
        }
    }

    
    internal void Init() {
        betCreditCost = 0.75f;
        
        lever = transform.GetChild(0).gameObject;
        origin = lever.transform.position;
        //Debug.Log(TAG + ":  Init() origin: " + origin);
        
        TapDetector detector = lever.GetComponent<TapDetector>() as TapDetector;
        detector.dispatcher.AddListener(TapDetector.TAP, OnTap);
        detector.dispatcher.AddListener(TapDetector.RELEASE, OnRelease);
    }

    void OnTap() {
        //dispatcher.Dispatch(Events.CHANGE_CREDIT, view.BetCreditCost);
        StopAllCoroutines();
        StartCoroutine(LeverMove());
    }

    void OnRelease() {
        Canvas canvas = FindObjectOfType<Canvas>();
/*
        Debug.Log(TAG + ": OnRelease() lever.transform.position.y: " + lever.transform.position.y);
        Debug.Log("Screen.height: " + Screen.height);            // 537
        Debug.Log("(lever.GetComponent<RectTransform>().sizeDelta.y / 2): " + (lever.GetComponent<RectTransform>().sizeDelta.y / 2));  // 50
        Debug.Log("canvas.scaleFactor: " + canvas.scaleFactor);  // 0.49
        Debug.Log("origin.y: " + origin.y);                      // 369.8
        Debug.Log("(lever.GetComponent<RectTransform>().sizeDelta.y / 2 * canvas.scaleFactor - origin.y): " + (lever.GetComponent<RectTransform>().sizeDelta.y / 2 * canvas.scaleFactor - origin.y));
        Debug.Log("(Screen.height + lever.GetComponent<RectTransform>().sizeDelta.y / 2 * canvas.scaleFactor - origin.y): " + (Screen.height + lever.GetComponent<RectTransform>().sizeDelta.y / 2 * canvas.scaleFactor - origin.y));
        */
        if (lever.transform.position.y < Screen.height + lever.GetComponent<RectTransform>().sizeDelta.y / 2 * canvas.scaleFactor - origin.y) {
            dispatcher.Dispatch(RELEASE_EVENT);
        }
        StopAllCoroutines();
        StartCoroutine(LeverReturn());
    }

    IEnumerator LeverReturn() {
        float time = 0;

        while (lever.transform.position != origin) {
            time += Time.deltaTime;
            lever.transform.position = Vector3.Lerp(lever.transform.position, origin, time * 4);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator LeverMove() {
        float touchRange = lever.transform.position.y - Input.mousePosition.y;
        //Debug.Log(TAG + ": LeverMove() touchRange: " + touchRange); // changing or not ????

        while (true) {
            //Debug.Log(TAG + ": LeverMove() Input.mousePosition.y: " + Input.mousePosition.y);
            //Debug.Log("(Input.mousePosition.y + touchRange): " + (Input.mousePosition.y + touchRange));
            //Debug.Log("origin.y: " + origin.y);
            //Debug.Log("(Input.mousePosition.y + touchRange <= origin.y): " + (Input.mousePosition.y + touchRange <= origin.y));
            //Debug.Log("Screen.height: " + Screen.height);
            //Debug.Log("(Screen.height - origin.y): " + (Screen.height - origin.y));
            //Debug.Log("(Input.mousePosition.y + touchRange >= Screen.height - origin.y): " + (Input.mousePosition.y + touchRange >= Screen.height - origin.y));
            
            if (Input.mousePosition.y + touchRange <= origin.y &&
                Input.mousePosition.y + touchRange >= Screen.height - origin.y) {
                lever.transform.position = new Vector3(lever.transform.position.x, Input.mousePosition.y + touchRange);
            } else {
                //Debug.Log("lever.transform.position.y: " + lever.transform.position.y);
                //Debug.Log("(lever.transform.position.y - Input.mousePosition.y): " + (lever.transform.position.y - Input.mousePosition.y));
                touchRange = lever.transform.position.y - Input.mousePosition.y;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}