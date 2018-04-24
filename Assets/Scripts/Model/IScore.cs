using System;

public interface IScore {

    int Score {
        get;
    }

    int AddScore(int value);
}
