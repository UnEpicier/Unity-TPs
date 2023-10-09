using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float distanceBeforeEnd = 20f; // Kilometers

    private static GameObject menu;
    private static TMP_Text text;

    private void Start()
    {
        InvokeRepeating("minusDistanceToEnd", 0, 0.2f);
        menu = transform.GetChild(0).gameObject;
        text = menu.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
    }

    private void minusDistanceToEnd()
    {
        distanceBeforeEnd -= 0.1f;
    }

    private void FixedUpdate()
    {
        if (distanceBeforeEnd <= 0)
        {
            Time.timeScale = 0f;
            menu.SetActive(true);
        }
    }

    public static void EndByLoosing()
    {
        text.SetText("Perdu !");
        Time.timeScale = 0f;
        menu.SetActive(true);
    }
}
