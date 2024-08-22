using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

    public GameObject[] foodPrefabs; 
    public Transform[] spawnPoints;  
    public GameObject panel; 
    private int totalFoodCount;
    private int collectedFoodCount = 0;

    void Start()
    {
        totalFoodCount = 0;  

        if (foodPrefabs.Length > 0 && spawnPoints.Length > 0)
        {
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

        // Assigner le tag "food" à la nourriture
        spawnedFood.tag = "food";

        totalFoodCount++;

        // Configurer le collider comme un trigger
        Collider collider = spawnedFood.GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
        else
        {
            Debug.LogWarning("Le prefab de nourriture n'a pas de collider.");
        }

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
    // Fonction appelée lorsqu'une nourriture est collectée
    public void FoodCollected()
    {
        collectedFoodCount++;
        CheckForWin();  // Vérifie si toutes les nourritures ont été collectées
    }

    // Vérifie si le joueur a gagné
    private void CheckForWin()
    {
        if (collectedFoodCount >= totalFoodCount)
        {
            // Affiche le message de victoire
            Debug.Log("Vous avez gagné !");
            // Affichez le panel de victoire ici, si nécessaire
            panel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
