public interface IBet {

    float currBet {
        get;
    }

    float prevBet {
        get;
    }

    void UpdateBetAmount(float value);
}
