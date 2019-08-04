using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCounter : MonoBehaviour
{
    private static int totalDeathCount;

    public static int GetTotalDeathCount() {
        return totalDeathCount;
    }

    public static void IncrementTotalDeathCount() {
        totalDeathCount += 1;
    }
}
