using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Symbol : MonoBehaviour {

    public Sprite [] symbolArray;

    [System.NonSerialized]
    public int symbolType;
    
    void Start() {
        GetComponent<SpriteRenderer>().sprite = symbolArray[symbolType];
    }

    public int getIdx() {
        return symbolType;
    }

    public SpriteRenderer getSpriteRenderer() {
        return GetComponent<SpriteRenderer>();
    }
}
