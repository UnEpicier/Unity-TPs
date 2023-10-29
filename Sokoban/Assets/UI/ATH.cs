using TMPro;
using UnityEngine;

public class ATH : MonoBehaviour
{
    private static TMP_Text _text;

    private void Start()
    {
        _text = transform.GetChild(0).gameObject.GetComponent<TMP_Text>();

        // 
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        GameObject[] endZones = GameObject.FindGameObjectsWithTag("EndZone");


        int boxesPlaced = 0;
        foreach (GameObject box in boxes)
        {
            foreach (GameObject endZone in endZones)
            {
                if (box.transform.position == endZone.transform.position)
                {
                    boxesPlaced++;
                }
            }
        }

        SetText(boxesPlaced);
    }

    public static void SetText(int boxesPlaced)
    {
        int boxesTotal = GameObject.FindGameObjectsWithTag("Box").Length;
        _text.SetText($"Boxes placed: {boxesPlaced} / {boxesTotal}");
    }
}
