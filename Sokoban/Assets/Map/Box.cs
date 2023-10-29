using System;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool TryMoveInDirection(string direction)
    {
        if (direction == "Up")
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0f, 0.34f, 0f), Vector2.up, 0.1f);

            if (hit.collider != null && (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("Box")))
            {
                return false;
            }
        }
        else if (direction == "Down")
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0f, -0.34f, 0f), Vector2.down, 0.1f);

            if (hit.collider != null && (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("Box")))
            {
                return false;
            }
        }
        else if (direction == "Right")
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0.34f, 0f, 0f), Vector2.right, 0.1f);

            if (hit.collider != null && (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("Box")))
            {
                return false;
            }
        }
        else if (direction == "Left")
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-0.34f, 0f, 0f), Vector2.left, 0.1f);

            if (hit.collider != null && (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("Box")))
            {
                return false;
            }
        }

        return true;
    }
}
