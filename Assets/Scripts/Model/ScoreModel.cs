using System;

public class ScoreModel : IScore {

    private int _score;

    public int Score {
        get {
            return _score;
        }
    }

    public ScoreModel() {
        _score = 0;
    }

    public int AddScore(int value) {
        _score += value;
        return Score;
    }
}
