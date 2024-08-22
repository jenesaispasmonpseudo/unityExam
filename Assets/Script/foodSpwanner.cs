using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs; // Array de prefabs de nourriture
    public Transform[] spawnPoints;  // Array des points de spawn

    void Start()
    {
        // Vérifier que des prefabs de nourriture et des points de spawn sont bien assignés
        if (foodPrefabs.Length > 0 && spawnPoints.Length > 0)
        {
            // Pour chaque point de spawn, on instancie une nourriture aléatoire
            foreach (Transform spawnPoint in spawnPoints)
            {
                SpawnFood(spawnPoint);
            }
        }
        else
        {
            Debug.LogError("Assurez-vous d'avoir assigné des foodPrefabs et des spawnPoints dans l'inspecteur.");
        }
    }

    void SpawnFood(Transform spawnPoint)
{
    // Choisir un prefab de nourriture aléatoire
    int randomIndex = Random.Range(0, foodPrefabs.Length);
    GameObject foodToSpawn = foodPrefabs[randomIndex];

    // Instancier la nourriture au point de spawn
    GameObject spawnedFood = Instantiate(foodToSpawn, spawnPoint.position, spawnPoint.rotation);

    // Mettre à l'échelle la nourriture spawnée à 3 sur tous les axes
    spawnedFood.transform.localScale = new Vector3(3, 3, 3);

    // Vérification dans la console
    if (spawnedFood != null)
    {
        Debug.Log("Nourriture spawnée : " + spawnedFood.name + " à " + spawnPoint.position);
    }
    else
    {
        Debug.LogError("La nourriture n'a pas été spawnée correctement.");
    }
}

}
