using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject paint;
    public GameObject player;
    public GameObject bg_first;
    public GameObject bg_next;
    private SpriteRenderer backgroundRenderer;
    // Start is called before the first frame update
    void Start()
    {
        backgroundRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bg_first.SetActive(false);
            bg_next.SetActive(true);
            paint.SetActive(false);
        }
    }

}
