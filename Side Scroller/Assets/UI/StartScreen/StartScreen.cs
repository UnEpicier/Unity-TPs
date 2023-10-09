using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField]
    private TMP_Text countdown;

    private int count = 3;

    private void Start()
    {
        StartCoroutine(DecreaseCountDown());
    }

    private IEnumerator DecreaseCountDown()
    {
        while (count > -1)
        {
            yield return new WaitForSecondsRealtime(1f);
            count--;

            countdown.text = count.ToString();
        }
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
