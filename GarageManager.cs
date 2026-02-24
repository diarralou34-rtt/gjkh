 UnityEngine;

[System.Serializable]
public class CarData
{
public string carName;
public GameObject prefab;
public float maxSpeed;
public float acceleration;
}

[CreateAssetMenu(fileName = "CarDatabase", menuName = "Cars/Database")]
public class CarDatabase : ScriptableObject
{
public CarData[] cars;
}
