using System;

public interface IScore {

    float Score {
        get;
    }

    float AddScore(float value);
}
