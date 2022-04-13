using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    string monName = "Training Dummy";
    int maxHP = 10;
    int shields = 0;
    int abilityShields = 0;
    int gold = 7;
    int victoryPoints = 0;
    int commonTreasure = 3;
    int qualityTreasure = 0;

    public string GetName(){
        return monName;
    }
    public int[] getStats(){
        int[] stats = new int[3];
        stats[0] = maxHP; stats[1] = shields;  stats[2] = abilityShields;
        return stats;
    }
    public int[] getRewards(){
        int[] rewards = new int[4];
        rewards[0] = gold; rewards[1] = commonTreasure; rewards[2] = qualityTreasure; rewards[3] = victoryPoints;
        return rewards;
    }
}
