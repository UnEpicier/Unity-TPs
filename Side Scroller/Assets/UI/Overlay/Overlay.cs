using TMPro;
using UnityEngine;

public class Overlay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    private PlayerManager player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    private void Update()
    {
        text.SetText(player.Score.ToString());
    }
}
