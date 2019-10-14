using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* References:
 * https://www.youtube.com/watch?v=XCOTK-a-1cc
 * https://www.youtube.com/watch?v=rVSLczG1M1E
 */

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{

    // == public fields ==
    public Boundary boundary;

    // == private fields ==
    [SerializeField]
    private float movementSpeed = 5.0f;

    [SerializeField]
    private GameObject player_bullet;

    [SerializeField]
    private Transform attack_point;

    // Restricting shooting
    public float attack_timer = 0.35f;
    private float current_attack_timer;
    private bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        current_attack_timer = attack_timer;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
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
                // Set canAttack to False and reset timer
                canAttack = false;
                attack_timer = 0.0f;

                // Create new bullet at the attack point
                Instantiate(player_bullet, attack_point.position, Quaternion.identity);

                // Play sound FX
            }
        }
    }
} // class
