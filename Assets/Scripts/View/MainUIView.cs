using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class MainUIView : View {
	// 调节音量 和 转动
    public const string SPIN_CLICK = "spinClick";
    public const string VOLUMN_CLICK = "volumnClick";

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    private Button spinBtn;
    private Button volumnBtn;

    public void Init() {
        spinBtn = this.gameObject.transform.FindChild("spinBtn").GetComponent<Button>();
        spinBtn.onClick.AddListener(spinBtnClickHandler);

        volumnBtn = this.gameObject.transform.FindChild("volumnBtn").GetComponent<Button>();
        volumnBtn.onClick.AddListener(volumnBtnClickHandler);

    }

    private void spinBtnClickHandler() {
        dispatcher.Dispatch(SPIN_CLICK);
    }

    private void volumnBtnClickHandler() {
        dispatcher.Dispatch(VOLUMN_CLICK);
    }
}
