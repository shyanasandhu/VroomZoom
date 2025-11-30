using UnityEngine;

[System.Serializable]
public class LapData
{
    public float L1;
    public float L2;
    public float L3;

//all 3 laps set to 0 at the begining of the game
    public LapData(){
        L1 = 0f;
        L2 = 0f;
        L3 = 0f;
    }
}
