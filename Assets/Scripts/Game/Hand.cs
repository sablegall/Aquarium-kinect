using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform mHandMesh;

    private void Update()
    {
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bubble bubble = collision.gameObject.GetComponent<Bubble>();
        if (collision.gameObject.CompareTag("Bubble"))
        {
            if (bubble != null)
            {
                bubble.StartDisappearing();
            }
        }
        
        // Arrêter le mouvement de la bulle
        if (bubble != null)
        {
            bubble.StopMovement();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            Bubble bubble = collision.gameObject.GetComponent<Bubble>();
            if (bubble != null)
            {
                bubble.StopDisappearing();
            }
        }
    }
}