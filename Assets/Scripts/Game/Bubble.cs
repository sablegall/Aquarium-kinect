using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Vector3 mMovementDirection = Vector3.zero;
    private Coroutine mCurrentChanger = null;

    private BoxCollider2D cadreCollider; // Référence au Box Collider attaché au cadre

    private bool mDisappearing = false;
    private float mDisappearTime = 3.0f; // Temps avant que la bulle ne disparaisse
    private float mElapsedTime = 0.0f;


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

    private void Start()
    {
        // Obtenez la référence au Box Collider du cadre
        cadreCollider = GameObject.FindWithTag("Bounds").GetComponent<BoxCollider2D>();

        if (cadreCollider == null)
        {
            Debug.LogError("Aucun Box Collider trouvé pour le cadre.");
        }
        else
        {
            // Appel de la méthode pour définir la position initiale de la bulle
            SetInitialPosition();
        }
    }

    private void SetInitialPosition()
    {
        if (cadreCollider != null)
        {
            // Obtenez les limites du cadre
            float minX = cadreCollider.bounds.min.x;
            float maxX = cadreCollider.bounds.max.x;
            float minY = cadreCollider.bounds.min.y;
            float maxY = cadreCollider.bounds.max.y;

            // Générez une position aléatoire à l'intérieur des limites du cadre
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            // Définissez la position de départ de la bulle sur la position aléatoire générée
            transform.position = new Vector3(randomX, randomY, transform.position.z);
        }
        else
        {
            Debug.LogError("Box Collider du cadre non assigné à la bulle.");
        }
    }

    private void Update()
    {
        //Movement horizontal de la bulle
        //transform.position += new Vector3(mMovementDirection.x, 0f, 0f) * Time.deltaTime * 0.9f;

        if (cadreCollider != null)
    {
        // Limitez la position de la bulle dans les limites horizontales du cadre
        float newX = Mathf.Clamp(transform.position.x + mMovementDirection.x * Time.deltaTime * 1.8f, cadreCollider.bounds.min.x, cadreCollider.bounds.max.x);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
    else
    {
        Debug.LogError("Box Collider du cadre non assigné à la bulle.");
    }

        if (mDisappearing)
        {
            mElapsedTime += Time.deltaTime;
            if (mElapsedTime >= mDisappearTime)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bounds"))
        {
            //Debug.Log("Collision with bounds detected!");
        }
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
            // Génère une direction horizontale aléatoire entre -1 et 1
            float randomX = Random.Range(-1f, 1f);
        
            // Assigne la nouvelle direction avec une composante x aléatoire et une composante y nulle
            mMovementDirection = new Vector2(randomX, 0f).normalized;
            
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
