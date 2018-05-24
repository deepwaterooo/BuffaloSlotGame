using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyWheel : MonoBehaviour {

    public RectTransform wheel;
    //public GameObject wheel;
    public RectTransform ticker;
    public float wheelRotationSpeed = 200f;

    private int spinningDirection = 1;
    private int tapsLeft = 100;
    
    void Start() {
    }

    void Udpate() {
        if (tapsLeft > 0) {
            wheel.Rotate(0, 0, wheelRotationSpeed * Time.deltaTime * spinningDirection);
            //wheel.Rotate(Vector3.forward * wheelRotationSpeed * Time.deltaTime * spinningDirection, Space.Self);
        }
    }
    
    public void OnWheellTap() {
        Debug.Log("Wheel tapped1");
        tapsLeft --;

        Debug.Log("tapsLeft: " + tapsLeft);
        Debug.Log("(tapsLeft > 0): " + (tapsLeft > 0));
        while (tapsLeft > 0) {
            wheel.Rotate(0, 0, wheelRotationSpeed * Time.deltaTime * spinningDirection);
            tapsLeft --;
        }
    }    
}
