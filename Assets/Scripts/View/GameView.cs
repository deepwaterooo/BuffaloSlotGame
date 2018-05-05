using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class GameView : View {
    public const string TAG = "GameView";
    
    //[Inject]
    //public IEventDispatcher dispatcher { get; set; }

    float winScore;
    float betCreditCost; // need a way to inject and get the value

    int index;

    string [] res;
    string [,] board;
    int resIdx;

    public Signal spinButtonClicked = new Signal();
    private Rect buttonRect = new Rect(580, 465, 50, 50); // 510, 465, 50, 50

    public void OnGUI() {
        if (GUI.Button(buttonRect, "SPIN")) { // newSPIN
            Debug.Log(TAG + ": onGUI() bef spinButtonClicked.Dispatch()"); 
            spinButtonClicked.Dispatch();
            Debug.Log(TAG + ": onGUI() aft spinButtonClicked.Dispatch()"); 
        }
    }
    
    public float WinScore {
        get {
            float newScore = winScore;
            winScore = 0;

            GameBoard();
            
            return newScore;
        }
    }

    void GameBoard() {
        board = new string[5, 5];
        board[4, 0] = "NA";
        board[4, 4] = "NA";
        GameObject [] slots = GameObject.FindGameObjectsWithTag("slot");
        for (int i = 0; i < slots.Length; i++) {
            Debug.Log("slots[i].getSlotName(): " + slots[i].name);
        }
        List<GameObject> currSlotObjs;
        /*
        for (int i = 0; i < 5; i++) {
            currSlotObjs = slots[i].getSlotObjects();
            for (int j = 0; j < currSlotObjs.Count; j++) {
                board[j][i] = currSlotObjs[j];
                
            }
        } */
    }
}
