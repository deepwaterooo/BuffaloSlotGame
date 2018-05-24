using System;
using System.Collections.Generic;

public static class Constants {

    public static Dictionary<string, List<float>> Rewards;

    static Constants() {
        Rewards = new Dictionary<string, List<float>>();
        Rewards["buf"] = new List<float>(new float[]{0f, 0.20f, 1.00f, 1.50f, 3.00f});
        Rewards["eag"] = new List<float>(new float[]{0f, 0f, 0.40f, 0.80f, 1.50f});
        Rewards["cou"] = new List<float>(new float[]{0f, 0f, 0.40f, 0.80f, 1.50f});
        Rewards["wol"] = new List<float>(new float[]{0f, 0f, 0.20f, 0.50f, 1.00f});
        Rewards["dee"] = new List<float>(new float[]{0f, 0f, 0.20f, 0.50f, 1.00f});
        Rewards["aaa"] = new List<float>(new float[]{0f, 0f, 1f, 1f, 1f});
        Rewards["kkk"] = new List<float>(new float[]{0f, 0f, 1f, 1f, 1f});
        Rewards["qqq"] = new List<float>(new float[]{0f, 0f, 1f, 1f, 1f});
        Rewards["jjj"] = new List<float>(new float[]{0f, 0f, 1f, 1f, 1f});
        Rewards["ten"] = new List<float>(new float[]{0f, 0f, 1f, 1f, 1f});
        Rewards["nin"] = new List<float>(new float[]{0f, 0.02f, 1f, 1f, 1f}); 
        Rewards["wil"] = new List<float>(new float[]{0f, 1.00f, 1.00f, 1.00f, 1.00f});
    }
}
