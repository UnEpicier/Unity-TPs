using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool CanMoveInDirection(string direction)
    {
        List<GameObject> wallsAndBoxes = new(GameObject.FindGameObjectsWithTag("Box"));
        wallsAndBoxes.AddRange(GameObject.FindGameObjectsWithTag("Wall"));

        // Left
        if (direction == "Left")
        {
            foreach (GameObject obj in wallsAndBoxes)
            {
                if (obj.transform.position.x == transform.position.x - 0.64f && obj.transform.position.y == transform.position.y) return false;
            }
        }
        // Right
        else if (direction == "Right")
        {
            foreach (GameObject obj in wallsAndBoxes)
            {
                if (obj.transform.position.x == transform.position.x + 0.64f && obj.transform.position.y == transform.position.y) return false;
            }
        }
        // Down
        else if (direction == "Down")
        {
            foreach (GameObject obj in wallsAndBoxes)
            {
                if (obj.transform.position.x == transform.position.x - 0.64f && obj.transform.position.x == transform.position.x) return false;
            }
        }
        // Up
        else if  (direction == "Up")
        {
            foreach (GameObject obj in wallsAndBoxes)
            {
                if (obj.transform.position.y == transform.position.y + 0.64f && obj.transform.position.x == transform.position.x) return false;
            }
        }
        return true;
    }
}
