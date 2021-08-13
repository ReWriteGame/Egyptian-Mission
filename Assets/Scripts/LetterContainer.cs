using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LetterContainer : MonoBehaviour
{
    public UnityEvent onTreeHitEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = transform;
        collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        onTreeHitEvent?.Invoke();
    }
}
