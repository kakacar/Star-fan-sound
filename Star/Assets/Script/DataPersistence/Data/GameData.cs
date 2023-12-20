using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public int deathCount;
    public int level;
    public float normalCollected;
    public float rareCollected;
    public int money;

    public GameData()
    {
        money = 0;
        deathCount = 0;
        this.level = 0;
        normalCollected = 0;
        rareCollected = 0;
    }
}
