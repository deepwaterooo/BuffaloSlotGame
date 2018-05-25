public interface IScore {

    float Score {
        get;
    }

    void AddScore(float value);

    // Restore game model to default state (as on startup)
    void Reset();
}
