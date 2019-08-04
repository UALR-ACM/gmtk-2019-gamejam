using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    private int totalDeathCount;

    public int getTotalDeathCount() {
        return totalDeathCount;
    }

    public void incrementTotalDeathCount() {
        totalDeathCount += 1;
    }
}
