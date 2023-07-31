using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IClicked
{
    [Header("General")]
    [SerializeField] int lives = 3;
    private Rigidbody2D rb;

    private SpriteRenderer graphic;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        graphic = GetComponentInChildren<SpriteRenderer>();
        if (!graphic || graphic.gameObject.name != "Graphic") { Debug.LogWarning("Error in selecting graphic for: " + this.name); }
    }

    public void onClickAction()
    {
        graphic.color = Color.grey;
    }
}
