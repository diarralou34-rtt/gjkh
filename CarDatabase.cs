using UnityEngine;

public class GarageManager : MonoBehaviour
{
public CarDatabase carDatabase;

public void OpenGarage(Transform spawnPoint)
{
Debug.Log("Garage ouvert ! Sélectionne une voiture dans l'Inspector");
// Exemple simple : faire apparaître toutes les voitures autour du joueur
float distance = 3f;
for (int i = 0; i < carDatabase.cars.Length; i++)
{
Vector3 pos = spawnPoint.position + new Vector3(distance * i, 0, 0);
Instantiate(carDatabase.cars[i].prefab, pos, Quaternion.identity);
}
}
}
