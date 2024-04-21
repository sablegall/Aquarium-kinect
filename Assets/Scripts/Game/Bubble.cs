using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Vector3 mMovementDirection = Vector3.zero;
    private Coroutine mCurrentChanger = null;

    private bool mDisappearing = false;
    private float mDisappearTime = 3.0f; // Temps avant que la bulle ne disparaisse
    private float mElapsedTime = 0.0f;

    // private float cadreWidth = 4.0f;
    // private float cadreHeight = 4.0f;

    private void OnEnable()
    {
        mCurrentChanger = StartCoroutine(DirectionChanger());
    }

    private void OnDisable()
    {
        StopCoroutine(mCurrentChanger);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);

        //Return to BubbleManager
    }

    private void Update()
    {
        //Movement
        transform.position += mMovementDirection * Time.deltaTime * 0.5f;

        if (mDisappearing)
        {
            mElapsedTime += Time.deltaTime;
            if (mElapsedTime >= mDisappearTime)
            {
                gameObject.SetActive(false);
            }
        }

        //Debug.Log("default" + mElapsedTime);

        // if (transform.position.x <= cadreWidth){
        //     transform.position += new Vector3 (pos.x, 0, 0);
        // }
        // if (transform.position.y <= cadreHeight){
        //     transform.position += new Vector3 (0, pos.y, 0);
        // }
    //     //Rotation
    }

    public void StartDisappearing()
    {
            mDisappearing = true;
            mElapsedTime = 0.0f;
    }

    public void StopDisappearing()
    {
        mDisappearing = false;
        mElapsedTime = 0.0f;
    }

    private IEnumerator DirectionChanger()
    {
        while (gameObject.activeSelf)
        {
            mMovementDirection = new Vector2(Random.Range(0, 100) * 0.01f, Random.Range(0, 100) * 0.01f);

            yield return new WaitForSeconds(3.0f);
        }
    }

    // Méthode pour arrêter le mouvement de la bulle
    public void StopMovement()
    {
        // Arrêtez le mouvement en définissant la direction sur zéro
        mMovementDirection = Vector3.zero;
    }
}
