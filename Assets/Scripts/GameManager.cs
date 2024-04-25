using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public int maxTargets = 1; // Nombre maximum d'objets autorisés
    private List<GameObject> spawnedTargets = new List<GameObject>();

    public static GameManager Instance {get; private set;}

   // public GameObject bulle = targets[0];
    public GameObject hand;

    private bool mDisappearing = false;
    private float mDisappearTime = 3.0f; // Temps avant que la bulle ne disparaisse
    private float mElapsedTime = 0.0f;

    private void Awake()
    {
        if (Instance != null){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }

    private void Update()
    {
        //Faire disparaître la bulle au bout de 3s dès que le curseur reste dessus
        if (mDisappearing)
        {
            mElapsedTime += Time.deltaTime;
            if (mElapsedTime >= mDisappearTime)
            {

                GameObject bulle = spawnedTargets[0];

                var xb = bulle.transform.position.x;
                var xh = hand.transform.position.x;
                if(Mathf.Abs(xb - xh) < 0.5f){
                    bulle.SetActive(false);
                    StopDisappearing();
                }
                //gameObject.SetActive(false);
                Debug.Log("bulle pos x " + bulle.transform.position.x);
                Debug.Log("hand pos x " + hand.transform.position.x);
            }
            Debug.Log("test " + mElapsedTime);
        }
    }

    public void StartDisappearing()
    {
            mDisappearing = true;
            mElapsedTime = 0.0f;
            Debug.Log("start mDisappearing "+mDisappearing);
            //StopCoroutine(DirectionChanger());
    }

    public void StopDisappearing()
    {
        mDisappearing = false;
        mElapsedTime = 0.0f;
        Debug.Log("Stop mDisappearing "+mDisappearing);
        //StopCoroutine(DirectionChanger());
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnAllTargets();
    }

    private void SpawnAllTargets()
    {
        int targetsSpawned = 0; // Nombre d'objets instanciés

        while (targetsSpawned < maxTargets)
        {
            // Mélanger la liste des cibles pour obtenir un ordre aléatoire à chaque itération
            Shuffle(targets);

            for (int i = 0; i < targets.Count && targetsSpawned < maxTargets; i++)
            {
                GameObject newTarget = Instantiate(targets[i]); // Instancier la cible actuelle
                spawnedTargets.Add(newTarget);
                targetsSpawned++;
            }
        }
    }

    // Fonction pour mélanger une liste
    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
