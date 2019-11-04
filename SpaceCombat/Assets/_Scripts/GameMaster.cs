﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static void KillPlayer(PlayerController player)
    {
        Destroy(player.gameObject);
    }

    public static void KillEnemy(GameObject enemy)
    {
        Destroy(enemy.gameObject);
    }
}