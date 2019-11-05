using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Adapted from:
https://youtu.be/eSLx1-iA9RM

Class takes care of creation / destruction of game objects
 */
public class GameMaster : MonoBehaviour
{
    public static void KillPlayer(Player player) // Passing Player class as type --> Do same for enemy
    {
        // destroy player
        Destroy(player.gameObject);
    }
}
