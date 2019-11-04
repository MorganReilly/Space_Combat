using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* References:
 * https://www.youtube.com/watch?v=XCOTK-a-1cc
 * https://www.youtube.com/watch?v=rVSLczG1M1E
 * https://youtu.be/eSLx1-iA9RM
 */

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    // Inner class for player statistics
    [SerializeField]
    public class PlayerStats
    {
        public int maxPlayerHealth;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            // Setting a clamp on the setter so players health is set correctly to value
            set { _curHealth = Mathf.Clamp(value, 0, maxPlayerHealth); }
        }

        public void Init()
        {
            curHealth = maxPlayerHealth;
        }
    }

    // PlayerStats Instance
    PlayerStats playerStats = new PlayerStats();

    [SerializeField]
    private StatusIndicator statusIndicator;

    public Boundary boundary;

    [SerializeField]
    private float movementSpeed = 5.0f;

    [SerializeField]
    private GameObject player_bullet;

    [SerializeField]
    private Transform attack_point; // Used for player bullet spawn point

    // Restricting shooting
    public float attack_timer = 0.35f;
    private float current_attack_timer;
    private bool canAttack;

    // Start is called before the first frame update
    void Start()
    {

        playerStats.Init();

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(playerStats.curHealth, playerStats.maxPlayerHealth);
        }

        // Check health on start
        Debug.LogError("Player Health on Start: " + playerStats.maxPlayerHealth);

        // Check for null on firepoint -- debugging
        if (attack_point == null)
        {
            Debug.LogError("No attack point set for player - Player cannot fire");
        }
        current_attack_timer = attack_timer;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();

        // Find collision for 
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;

        // add the change to the current position
        var newXPos = transform.position.x + deltaX;
        var newYPos = transform.position.y + deltaY;

        transform.position = new Vector2(newXPos, newYPos);

        transform.position = new Vector2
            (
                Mathf.Clamp(newXPos, boundary.xMin, boundary.xMax),
                Mathf.Clamp(newYPos, boundary.yMin, boundary.yMax)
            );
    }

    void Attack()
    {
        attack_timer += Time.deltaTime;
        if (attack_timer > current_attack_timer)
        {
            canAttack = true;
        }

        // Player can attack, assuming canAttack is true
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canAttack)
            {
                Shoot();
                // Play sound FX
            }
        }
    }

    void Shoot()
    {
        // Set canAttack to False and reset attack_timer
        canAttack = false;
        attack_timer = 0.0f;
        Debug.LogError("CanAttack: " + canAttack);

        // Create new bullet at the attack point
        Instantiate(player_bullet, attack_point.position, Quaternion.identity);
    }

    public void DamagePlayer(int damage)
    {
        playerStats.curHealth -= damage;

        // Check if health is <= 0
        // If yes, kill player
        if (playerStats.curHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }

        // Setting health for status bar
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(playerStats.curHealth, playerStats.maxPlayerHealth);
        }

    }

} // class
