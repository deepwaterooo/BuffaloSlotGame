using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine.UI;

public class GameView : View {
    public const string TAG = "GameView";

    public const string STOP_SPIN = "STOP_SPIN";
    
    [Inject]
    public IEventDispatcher dispatcher { get; set; }
    
    private GameObject[] slots;
    
    private Dictionary<string, int> winItems; 
    private Dictionary<string, List<int>> winRec;
    private int objectCount;
    private List<string> dictionaryKeysList;

    private float winScore, deltaCredit;

    public float WinScore {
        get {
            float newScore = winScore;
            deltaCredit = winScore;
            winScore = 0;
            return newScore;
        }
    }

    public float DeltaCredit {
        get {
            float newCredit = deltaCredit;
            deltaCredit = 0f;
            return newCredit;
        }
    }

    internal void Init() {
        winItems = new Dictionary<string, int>();
        winRec = new Dictionary<string, List<int>>();
        slots = new GameObject[5];
        slots[0] = GameObject.Find("Slot1").gameObject;
        slots[1] = GameObject.Find("Slot2").gameObject;
        slots[2] = GameObject.Find("Slot3").gameObject;
        slots[3] = GameObject.Find("Slot4").gameObject;
        slots[4] = GameObject.Find("Slot5").gameObject;
    }

    IEnumerator CheckIfSpinFinished() {
        yield return new WaitForSeconds(3.9f);
        int spinFinished = 0;
        for (int i = 0; i < slots.Length; i++) {
            spinFinished += slots[i].GetComponent<SlotView>().spinFinished;
        }
        while (spinFinished < 5) {
            yield return new WaitForSeconds(0.2f);

            spinFinished = 0;
            for (int i = 0; i < slots.Length; i++) {
                spinFinished += slots[i].GetComponent<SlotView>().spinFinished;
            }   
        }
        GetWinScore();
        dispatcher.Dispatch(STOP_SPIN);
    }

    public void WaitForSpinFinish() {
        StartCoroutine(CheckIfSpinFinished());
    }

    public void GetWinScore() {
        // 1st Slot: add all first slot items into set, keep winRecDic empty;
        // 2nd Slot: winRecDic.Count = 0, add candidates into winRecDic;
        // 3rd slot: update all win items in winRecDic, remove item from winItemsSet if no longer illegible for win
        // 4th & 5th slot: update existing items to win more
		
        objectCount = 4;   // 1st slot:
        for (int i = 0; i < objectCount; i++) {
            string name = slots[0].GetComponent<SlotView>().currentSlotObj[i].name.Substring(0, 3);
            if (name != "whe") { // to consider wheels events later
                if (winItems.ContainsKey(name))
                    winItems[name] += 1;
                else 
                    winItems.Add(name, 1);
            }
        }
        
        objectCount = 5;  // 2nd slot
        foreach (string key in winItems.Keys) {  // record results from 1st slot
            List<int> counts = new List<int>();
            counts.Add(winItems[key]);
            winRec[key] = counts;
        }
        UpdateWinItems(1); // Update results according to 2nd slot results
        
        dictionaryKeysList = new List<string>(winRec.Keys);
        foreach (string key in dictionaryKeysList) {
            if (winItems.ContainsKey(key)) {
                winRec[key].Add(winItems[key]);
                //foreach (int val in winRec[key]) 
                    //Debug.Log("val: " + val);
            } else {
                winRec.Remove(key);
            }
        }
        if (winRec.Count == 0) {
            winScore = 0; 
            return;
        } // result: (winItems.Count == 0) included
        
        UpdateWinItems(2); // 3rd slot
        UpdateGameResultBasedOnCurrentSlot(2);
        if (winItems.Count == 0) 
            return;
        
        UpdateWinItems(3); // 4th
        UpdateGameResultBasedOnCurrentSlot(3);
        if (winItems.Count == 0) 
            return;
        
        objectCount = 4;  // 5th
        UpdateWinItems(4);
        UpdateGameResultBasedOnCurrentSlot(4);
    }

    public void UpdateGameResultBasedOnCurrentSlot(int slotIndex) {
        if (winRec.Count == 0) {
            winScore = 0;
            return;
        }
        switch (slotIndex) {
        case 2: 
            CalculateWinScore(slotIndex);
            UpdateWinRec();
            break;
        case 3:
            CalculateWinScore(slotIndex);
            UpdateWinRec();
            break;
        case 4:
            CalculateWinScore(slotIndex);
            break;
        default:
            break;
        }
    }

    public void CalculateWinScore(int slotIndex) {
        if (winRec.Count > 0) {
            float reward;
            dictionaryKeysList = new List<string>(winRec.Keys);
            foreach (string key in dictionaryKeysList) {
                if (!winItems.ContainsKey(key) || slotIndex == 4) {
                    if (!winItems.ContainsKey(key)) 
                        reward = Constants.Rewards[key][slotIndex - 1]; 
                    else
                        reward = Constants.Rewards[key][slotIndex]; 
                    //Debug.Log("reward: " + reward);
                    winScore += reward * GetMultiplierFromList(winRec[key]);
                    //Debug.Log("winScore: " + winScore);
                    winRec.Remove(key);
                }
            }
        }
    }

    public int GetMultiplierFromList(List<int> list) {
        int result = 1;
        for (int i = 0; i < list.Count; i++) {
            result *= list[i];
        }
        //Debug.Log("result: " + result);
        return result;
    }

    public void UpdateWinRec() { 
        dictionaryKeysList = new List<string>(winRec.Keys);
        foreach (string key in dictionaryKeysList) {
            if (winItems.ContainsKey(key)) {
                winRec[key].Add(winItems[key]);  
                //foreach (int val in winRec[key]) 
                    //System.Console.WriteLine("val: " + val);
            } else {
                winRec.Remove(key);
            }
        }
    }

    public void UpdateWinItems(int slotIndex) {
        int tmp = objectCount - 1; 
        int cnt;
        string name;
        dictionaryKeysList = new List<string>(winRec.Keys);
        foreach (string key in winRec.Keys) {
            cnt = 0;
            for (int i = 0; i <= tmp; i++) {
                name = slots[slotIndex].GetComponent<SlotView>().currentSlotObj[i].name.Substring(0, 3);
                if (name == key || name == "wil") {
                    //Debug.Log("name: " + name);
                    //Debug.Log("key: " + key);
                    cnt++;
                }
            }
            if (cnt > 0) 
                winItems[key] = cnt;
            else
                winItems.Remove(key);   // potential miscalculation
        }
    }
/*
    public void PrintGameBetResult() {
        for (int i = 0; i < slots.Length; i++) {
            for (int x = 0; x < slots[i].GetComponent<SlotView>().currentSlotObj.Count; x++) {
                Debug.Log("slots[i].currentSlotObj[x].name: " + slots[i].GetComponent<SlotView>().currentSlotObj[x].name);
            }
            Debug.Log("\n");
        }
    }
    */    
}
