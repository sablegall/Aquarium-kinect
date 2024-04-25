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

    private void OnTriggerStay2D(Collider2D collision)
    {
        Bubble bubble = collision.gameObject.GetComponent<Bubble>();
        if (collision.gameObject.CompareTag("Bubble"))
        {
            Debug.Log("enter");
            if (bubble != null)
            {
                GameManager.Instance.StartDisappearing();
                // Arrêter le mouvement de la bulle
                bubble.StopMovement();

            }
        }
    }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
        
    //     if (collision.gameObject.CompareTag("Bubble"))
    //     {
    //         Debug.Log("exit");
    //         Bubble bubble = collision.gameObject.GetComponent<Bubble>();
    //         if (bubble != null)
    //         {
    //            // GameManager.Instance.StopDisappearing();
    //         }
    //     }
    // }
}