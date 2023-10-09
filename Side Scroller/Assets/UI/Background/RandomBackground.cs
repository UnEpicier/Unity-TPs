using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomBackground : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> backgrounds = new();

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        sr.sprite = backgrounds[Random.Range(0, backgrounds.Count - 1)];
        sr.size = new Vector2(5.932881f, 3.337702f);
    }
}
