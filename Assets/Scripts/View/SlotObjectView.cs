using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.mediation.impl;

public class SlotObjectView : View {
    public float reward;

    public void Init() {
        GetComponentInChildren<Text>().text = reward.ToString();
    }
}
