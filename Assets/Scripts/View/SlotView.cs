using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class SlotView : View {
    private const string TAG = "SlotView";
    
    //public static float spinTimer = 4.0f;
    public int spinFinished = 0;
    
    public const string START_SPIN = "START_SPIN";
    public const string STOP_SPIN = "STOP_SPIN";

    public float slotSpinTime = 5f;
    public float speed = 12f;
    public int slotObjCount = 6;
    public List<GameObject> slots;
    
    [Inject]
    public IEventDispatcher dispatcher { get; set; }
/*    [Inject]
    public StopSpin StopSpin { get; set; }  */
    
    int index;

    public List<GameObject> currentSlotObj;

    private float currSlotSpinTimer = 0f;

    public float CurrentSlotSpinTimer {
        get {
            return currSlotSpinTimer;
        }
    }

    public void SetCurrentSlotSpinTimer(float time) {
        currSlotSpinTimer = time;
    }
    
    public void GameReset() {
        currSlotSpinTimer = slotSpinTime;
        spinFinished = 0;
    }
    
    public void Init() {
        currSlotSpinTimer = slotSpinTime;
        spinFinished = 0;
        index = 0;
        currentSlotObj = new List<GameObject>();
        Canvas canvas = FindObjectOfType<Canvas>();
        slots = slots.OrderBy(r => Random.value).ToList();
        for (int j = 0; j < slotObjCount; j++) {
            if (j == 0) 
                PlaceSlotObject(transform.position);
            else 
                PlaceSlotObject(new Vector3(transform.position.x, transform.position.y + slots[index].GetComponent<RectTransform>().sizeDelta.y * canvas.scaleFactor * j));
        }
    }

    void PlaceSlotObject(Vector3 newPos) {
        GameObject go = Instantiate(slots[index]) as GameObject;
        go.transform.SetParent(transform, false);
        go.transform.position = newPos;
        currentSlotObj.Add(go);
        index++; 
        if (index >= slots.Count) 
            index = 0;
    } 

    public void StartSpin() {
        StartCoroutine(Spin());
    }

    IEnumerator Spin() {
        float curentSpeed = speed; // Random.Range(speed * 0.8f, speed * 1.2f); 
        
        Canvas canvas = FindObjectOfType<Canvas>();
        if (currentSlotObj.Count < slotObjCount) 
            PlaceSlotObject(new Vector3(transform.position.x, currentSlotObj[currentSlotObj.Count - 1].transform.position.y + currentSlotObj[currentSlotObj.Count - 1].GetComponent<RectTransform>().sizeDelta.y * canvas.scaleFactor));
        while (currSlotSpinTimer > 0) { // slotSpinTime
            int count = currentSlotObj.Count;
            if (currentSlotObj.Count < slotObjCount) 
                PlaceSlotObject(new Vector3(transform.position.x, currentSlotObj[currentSlotObj.Count - 1].transform.position.y + currentSlotObj[currentSlotObj.Count - 1].GetComponent<RectTransform>().sizeDelta.y * canvas.scaleFactor));
            for (int i = 0; i < count; i++) {
                Vector3 newPos = new Vector3(currentSlotObj[i].transform.position.x, currentSlotObj[i].transform.position.y - currentSlotObj[i].GetComponent<RectTransform>().sizeDelta.y * canvas.scaleFactor);
                currentSlotObj[i].transform.position = Vector3.Lerp(currentSlotObj[i].transform.position, newPos, curentSpeed * Time.fixedDeltaTime); 
            }
            if (currentSlotObj[0].transform.position.y <= transform.position.y - currentSlotObj[0].GetComponent<RectTransform>().sizeDelta.y * 1.0f * canvas.scaleFactor) { // 1.5f
                Destroy(currentSlotObj[0]);
                currentSlotObj.RemoveAt(0);
            }
            currSlotSpinTimer -= Time.deltaTime; // slotSpinTime
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(SpinResult(curentSpeed));
    }

    IEnumerator SpinResult(float slowSpeed) {
        float curentSpeed = speed; 
        int count = currentSlotObj.Count;
        //for (int i = 0; i < currentSlotObj.Count; i++) 
            //slotObjectsNames[resIdx++] = currentSlotObj[i].name.Substring(0, 3);

        Canvas canvas = FindObjectOfType<Canvas>();
        while (currentSlotObj[0].transform.position.y > transform.position.y) { 
        //while (currentSlotObj[0].transform.position.y > transform.position.y + currentSlotObj[0].GetComponent<RectTransform>().sizeDelta.y * canvas.scaleFactor) { // ori currentSlotObj.Count - 2
            //if (slowSpeed > speed * 0.5f) 
                //slowSpeed *= 0.98f; // slowSpeed *= 0.98f;
            for (int i = 0; i < count; i++) {
                Vector3 newPos = new Vector3(currentSlotObj[i].transform.position.x, currentSlotObj[i].transform.position.y - currentSlotObj[i].GetComponent<RectTransform>().sizeDelta.y * canvas.scaleFactor);
                currentSlotObj[i].transform.position = Vector3.Lerp(currentSlotObj[i].transform.position, newPos, curentSpeed * Time.fixedDeltaTime);
            }
            yield return new WaitForEndOfFrame();
        }    
        //while (currentSlotObj[0].transform.position.y < transform.position.y) { //  + currentSlotObj[0].GetComponent<RectTransform>().sizeDelta.y * canvas.scaleFactor
            //currentSlotObj[0].transform.position = transform.position;
            if (slowSpeed > speed * 0.5f) 
                slowSpeed *= 0.6f; // slowSpeed *= 0.98f;
            for (int i = 0; i < count; i++) {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y + currentSlotObj[i].GetComponent<RectTransform>().sizeDelta.y * canvas.scaleFactor * i);                
                //currentSlotObj[i].transform.position = Vector3.Lerp(currentSlotObj[i].transform.position, newPos, slowSpeed * Time.fixedDeltaTime);
                currentSlotObj[i].transform.position = newPos;
            }
            //yield return new WaitForEndOfFrame();
        //}  

            //float waitForSeconds = spinTimer - time;
            //yield return new WaitForSeconds(waitForSeconds);

            spinFinished = 1;
            //dispatcher.Dispatch(STOP_SPIN);
    }
}
