using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

public class MainUIViewMediator : EventMediator {

    [Inject]
    public MainUIView view { get; set; }

    public override void OnRegister() {
        view.dispatcher.AddListener(MainUIView.SPIN_CLICK, spinBtnClickHandler);
        view.dispatcher.AddListener(MainUIView.VOLUMN_CLICK, volumnBtnClickHandler);
        view.Init();
    }

    public override void OnRemove() {
        view.dispatcher.RemoveListener(MainUIView.SPIN_CLICK, spinBtnClickHandler);
        view.dispatcher.RemoveListener(MainUIView.VOLUMN_CLICK, volumnBtnClickHandler);
    }

    private void spinBtnClickHandler(IEvent evt) {
        dispatcher.Dispatch(NotificationCenter.SPIN);
    }

    private void volumnBtnClickHandler(IEvent evt) {
        dispatcher.Dispatch(NotificationCenter.VOLUMN);
    }

}
