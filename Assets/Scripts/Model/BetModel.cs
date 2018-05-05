using System;

public class BetModel : IBet {

    private float _prevBet;
    private float _currBet;

    public float prevBet {
        get {
            return _prevBet;
        }
    }
    
    public float currBet {
        get {
            return _currBet;
        }
    }

    public BetModel() {
        _prevBet = 0.75f;
        _currBet = 3.00f;
    }

    public void UpdateBetAmount(float value) {
        _prevBet = _currBet;
        _currBet = value;
    }
}
