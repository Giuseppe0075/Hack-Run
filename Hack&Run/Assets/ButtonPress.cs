using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private Transform tr;
    [SerializeField] private float offsetTime = 0.2f;
    public float offset = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        if (tr == null)
            Debug.LogError("No Trasform component for: " + this.name);
    }

    private void Update()
    {
        if(offset >= 0)
            offset -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tr.localScale = new Vector2(tr.localScale.x, 0.8f);
        offset = offsetTime;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        tr.localScale = new Vector2(tr.localScale.x, 1f);
    }
}
