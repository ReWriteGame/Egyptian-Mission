using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Needle : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    public UnityEvent onHitLetter;
    public UnityEvent onHitArrow;
    public float Speed { get => speed; set => speed = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Letter>())
        {
            collision.gameObject.GetComponent<Destroyable>().destroy();
            onHitLetter?.Invoke();
        }
       


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Needle>())
        {
            onHitArrow?.Invoke();
        }

    }



}
