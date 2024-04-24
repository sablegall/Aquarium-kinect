using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public int maxTargets = 1; // Nombre maximum d'objets autorisés
    private List<GameObject> spawnedTargets = new List<GameObject>();

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
