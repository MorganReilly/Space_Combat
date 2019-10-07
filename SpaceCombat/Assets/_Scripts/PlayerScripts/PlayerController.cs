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

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move(){
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
} // class
