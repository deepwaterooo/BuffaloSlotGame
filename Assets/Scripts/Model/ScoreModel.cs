using System;

public class ScoreModel : IScore {

    private float _score;

    public float Score {
        get {
            return _score;
        }
    }

    public ScoreModel() {
        _score = 0;
    }

    public float AddScore(float value) {
        _score += value;
        return Score;
    }
}
