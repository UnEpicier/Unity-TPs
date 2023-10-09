using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerManager : MonoBehaviour
{
    /** --- STATS ---------------------------------- */
    public float health = 100;
    public bool godmode = false;

    /** --- COMPONENTS ----------------------------- */
    public Sprite deathSprite;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") && godmode == false)
        {
            Death();
        }
    }

    private void Death()
    {
        health = 0;
        sr.sprite = deathSprite;
        GameManager.EndByLoosing();
    }
}
