using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;  // Le Transform de l'objet que la caméra doit suivre
    public float fixedYPosition = 15f;  // La position fixe en Y pour la caméra

    // Update est appelé à chaque frame
    void Update()
    {
        // Vérifier si la cible est assignée
        if (target != null)
        {
            // Position de la caméra mise à jour pour suivre la cible en X et Z, mais rester fixe en Y
            Vector3 newPosition = new Vector3(target.position.x, fixedYPosition, target.position.z);
            transform.position = newPosition;
        }
        else
        {
            Debug.LogWarning("La cible de la caméra n'est pas assignée.");
        }
    }
}
