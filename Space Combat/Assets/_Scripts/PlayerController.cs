using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: https://www.youtube.com/watch?v=rVSLczG1M1E

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
    private float moveSpeed = 7.0f;

    // == private methods ==
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // find the change signal from the keyboard/input device
        // create a value for the change
        // Time.deltaTime - frame rate independent - same experience
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

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

}
