using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class SlotView : View {
    private const string TAG = "SlotView";
    
    public const string START_SPIN = "START_SPIN";
    public const string STOP_SPIN = "STOP_SPIN";

    public float time = 5f;
    public float speed = 12f;
    public int slotObjCount = 6;
    public List<GameObject> slots;
    
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    float winScore;
    //float betCreditCost = 0.75f; // 0.75f so far, need to figure out how to inject and get the value from button array???

    int index;

    string [] res;
    string [,] board;
    int resIdx;
    
    List<GameObject> currentSlotObj;

    public float WinScore {
        get {
            float newScore = winScore;
            winScore = 0;
            return newScore;
        }
    }
    /*
    float betCreditCost = 0.75f; // 0.75f so far, need to figure out how to inject and get the value from button array???
    public float BetCreditCost {
        get {
            float newBetCredit = betCreditCost / 25.0f * (-1f); // cost ???
            //betCreditCost = 0f;
            Debug.Log(TAG + ": BetCreditCredit newBetCredit: " + newBetCredit); 
            return newBetCredit;
        }
    }
    */
    public float WinCredit {
        get {
            float newScore = winScore;
            winScore = 0;
            return newScore;
        }
    }
    
    public void Init() {
        res = new string[26];
        board = new string[5, 5];
        //betCreditCost = 0.75f;
        resIdx = 0;
        winItems = new Dictionary<string, int>();
        winRec = new Dictionary<string, List<int>>();
        
        index = 0;
        currentSlotObj = new List<GameObject>();
        Canvas canvas = FindObjectOfType<Canvas>();
        slots = slots.OrderBy(r => Random.value).ToList();
        //Debug.Log(TAG + ": Init() gameObject: " + gameObject);  // Slot2(UnityEngine.GameObject)
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
        firstSlot = true;
        StartCoroutine(Spin());
    }

    IEnumerator Spin() {
        float curentSpeed = speed; // Random.Range(speed * 0.8f, speed * 1.2f); // 这里暂时还不需要随机速度
        
        Canvas canvas = FindObjectOfType<Canvas>();
        if (currentSlotObj.Count < slotObjCount) 
            PlaceSlotObject(new Vector3(transform.position.x, currentSlotObj[currentSlotObj.Count - 1].transform.position.y + currentSlotObj[currentSlotObj.Count - 1].GetComponent<RectTransform>().sizeDelta.y * canvas.scaleFactor));
        while (time > 0) {
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
            time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(SpinResult(curentSpeed));
    }

    IEnumerator SpinResult(float slowSpeed) {
        float curentSpeed = speed; 
        int count = currentSlotObj.Count;
        /*for (int i = 0; i < currentSlotObj.Count; i++) {
            res[resIdx++] = currentSlotObj[i].name.Substring(0, 3);
            //Debug.Log(TAG + ": SpinResult() currentSlotObj[i].name: " + currentSlotObj[i].name); 
            //Debug.Log(TAG + ": SpinResult() currentSlotObj[i].GetComponent<SlotObjectView>().reward: " + currentSlotObj[i].GetComponent<SlotObjectView>().reward); 
        }*/
        Canvas canvas = FindObjectOfType<Canvas>();
        while (currentSlotObj[0].transform.position.y > transform.position.y) { // ori currentSlotObj.Count - 2
        //while (currentSlotObj[0].transform.position.y > transform.position.y + currentSlotObj[0].GetComponent<RectTransform>().sizeDelta.y * canvas.scaleFactor) { // ori currentSlotObj.Count - 2
            //if (slowSpeed > speed * 0.5f) 
                //slowSpeed *= 0.98f; // slowSpeed *= 0.98f;
            for (int i = 0; i < count; i++) {
                Vector3 newPos = new Vector3(currentSlotObj[i].transform.position.x, currentSlotObj[i].transform.position.y - currentSlotObj[i].GetComponent<RectTransform>().sizeDelta.y * canvas.scaleFactor);
                currentSlotObj[i].transform.position = Vector3.Lerp(currentSlotObj[i].transform.position, newPos, curentSpeed * Time.fixedDeltaTime);
            }
            yield return new WaitForEndOfFrame();
        }    
        while (currentSlotObj[0].transform.position.y <= transform.position.y) { //  + currentSlotObj[0].GetComponent<RectTransform>().sizeDelta.y * canvas.scaleFactor
            //currentSlotObj[0].transform.position = transform.position;
            if (slowSpeed > speed * 0.5f) 
                slowSpeed *= 0.6f; // slowSpeed *= 0.98f;
            for (int i = 0; i < count; i++) {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y + currentSlotObj[i].GetComponent<RectTransform>().sizeDelta.y * canvas.scaleFactor * i);                
                currentSlotObj[i].transform.position = Vector3.Lerp(currentSlotObj[i].transform.position, newPos, slowSpeed * Time.fixedDeltaTime);
            }
            yield return new WaitForEndOfFrame();
        }  
        
        //winScore = currentSlotObj[0].GetComponent<SlotObjectView>().reward;
        //winScore = getWinScore();
        //StartCoroutine(getWinScore());
        getWinScore();
        
        //Debug.Log(TAG + ": SpinResult() currentSlotObj[0].name: " + currentSlotObj[0].name); 
        //Debug.Log(TAG + ": SpinResult() currentSlotObj[0].GetComponent<SlotObjectView>().reward: " + currentSlotObj[0].GetComponent<SlotObjectView>().reward); 
        dispatcher.Dispatch(STOP_SPIN);
        //printResultBoard();
    }

    Dictionary<string, int> winItems; // at most 4 items
    //string [] winItems;
    //int [] winItemsCounts;
    Dictionary<string, List<int>> winRec;
    bool firstSlot = true;
    float bet = 0.75f; // for temp, needs to be passed in
    
    void getWinScore() {
        // 1st Slot: add all first slot items into set, keep winRecDic empty;
        // 2nd Slot: winRecDic.Count = 0, add candidates into winRecDic;
        // 3rd slot: update all win items in winRecDic, remove item from winItemsSet if no longer illegible for win
        // 4th & 5th slot: update existing items to win more

        //int winItemsCnt = slotObjCount - 1;
        //float winVal = 0;
        Debug.Log(TAG + ": getWinScore() firstSlot: " + firstSlot);
        Debug.Log("winRec.Count: " + winRec.Count);
        
        if (firstSlot) { // 1st slot
            for (int i = 0; i < slotObjCount - 1; i++) {
                if (winItems.ContainsKey(res[i]))
                    winItems[res[i]] += 1;
                else 
                    winItems.Add(res[i], 1);
            }
            firstSlot = false;
        } else if (winItems.Count > 0 && winRec.Count == 0) { // 2nd slot
            // record results from 1st slot
            foreach (string key in winItems.Keys) {
                List<int> tmp = new List<int>(winItems[key]);
                winRec[key] = tmp;
            }
            // Update results according to 2nd slot results
            UpdateWinItems();
            foreach (string key in winRec.Keys) {
                if (winItems.ContainsKey(key)) {
                    winRec[key].Add(winItems[key]);
                } else {
                    winRec.Remove(key);
                }
            }
            if (winRec.Count == 0) // 结果: (winItems.Count == 0) included
                winScore = 0;
        } else { // 3rd slot, 4th, 5th
            UpdateWinItems();
            if (winItems.Count == 0) { // buffalo or 9, 2 slots only
                // calculate score, clear winRec dic too
                winScore = 5f;
            } 
            foreach (string key in winRec.Keys) {
                if (winItems.ContainsKey(key)) {
                    winRec[key].Add(winItems[key]);
                } else {
                    winRec.Remove(key);
                }
            }
            winScore = 10f;
        }
        //yield return winScore; //WaitForSeconds(1);
    }
    
    void UpdateWinItems() {
        Debug.Log(TAG + ": UpdateWinItems() "); 
        Debug.Log("currentSlotObj.Count: " + currentSlotObj.Count);
        Debug.Log("slotObjCount: " + slotObjCount);
        int tmp = slotObjCount - 1; // slotObjCount
        int cnt;
        foreach (string key in winRec.Keys) {
            cnt = 0;
            for (int i = 0; i < tmp; i++) {
                Debug.Log("res[i]: " + res[i]);
                if (res[i] == key || res[i] == "wil") // for wild card
                    cnt++;
            }
            if (cnt > 0) 
                winItems[key] = cnt;
            else
                winItems.Remove(key);
        }
    }
    bool ContainsItem(string item) {
        // wild card, *1, *2, *3
        for (int i = 0; i < slotObjCount - 1; i++) {
            if (res[i] == "wil" || res[i] == item) // wild card
                return true;
        }
        return false;
    }
    
    public string getSlotName() {
        Debug.Log(TAG + ": getSlotName() gameObject.name: " + gameObject.name); 
        return gameObject.name;
    }
    
    public string [] getSlotObjects() {
        return res;
    }

    private static void DisplaySet(HashSet<int> set) {
        System.Console.Write("{");
        foreach (int i in set)
            System.Console.Write(" {0}", i);

        System.Console.WriteLine(" }");
    }
    void printResultBoard() {
        for (int x = 0; x < slotObjCount; x++) {
            Debug.Log("res[x]: " + res[x]);
        }
    }
}
