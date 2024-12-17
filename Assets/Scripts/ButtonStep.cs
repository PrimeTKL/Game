using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStep : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] GameObject step;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            step.SetActive(true);
        }
    }
}
