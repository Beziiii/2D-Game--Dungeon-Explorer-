using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouch : MonoBehaviour
{
    private int TreasureCounter = 0;

    public void AddTreasure()
    {
        TreasureCounter += 1;
        Debug.Log($"Treasure Number: {TreasureCounter}");
    }

    public int GetCollectedTreasure()
    {
        return TreasureCounter;
    }
}
