using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform mHandMesh;

    private bool mIsTouchingBubble = false;
    private float mTouchTime = 0.0f;
    private float mDisappearTime = 3.0f; // Temps avant que l'objet ne disparaisse

    private void Update()
    {
        mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);

        if (mIsTouchingBubble)
        {
            mTouchTime += Time.deltaTime;
            Debug.Log("" + mTouchTime);
            if (mTouchTime >= mDisappearTime)
            {
                // Faites quelque chose lorsque l'objet doit disparaître, par exemple le désactiver
                gameObject.SetActive(false);
            }
        }
        else
        {
            // Réinitialiser le temps si la main n'est plus en collision avec la bulle
            mTouchTime = 0.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            mIsTouchingBubble = true;
            //Debug.Log("triggered enter");
            //Debug.Log(mIsTouchingBubble);
        }
        
        // Arrêter le mouvement de la bulle
        Bubble bubble = collision.gameObject.GetComponent<Bubble>();
        if (bubble != null)
        {
            bubble.StopMovement();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            mIsTouchingBubble = false;
        }
    }
}