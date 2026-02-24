using UnityEngine;

public class PlayerController : MonoBehaviour
{
public float speed = 5f;
public Camera playerCamera;
private Rigidbody rb;
private bool inCar = false;
private CarController currentCar;
public GarageManager garage;

void Start() => rb = GetComponent<Rigidbody>();

void Update()
{
if (!inCar) MovePlayer();
if (Input.GetKeyDown(KeyCode.E)) TryEnterExitCar();
if (Input.GetKeyDown(KeyCode.G)) garage.OpenGarage(transform);
}

void MovePlayer()
{
float h = Input.GetAxis("Horizontal");
float v = Input.GetAxis("Vertical");
Vector3 dir = new Vector3(h, 0, v);
if (dir.magnitude > 1f) dir.Normalize();
rb.MovePosition(transform.position + dir * speed * Time.deltaTime);

if (dir.magnitude > 0.1f)
transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.15f);
}

void TryEnterExitCar()
{
if (inCar)
{
currentCar.ExitCar(transform);
currentCar = null;
inCar = false;
playerCamera.enabled = true;
}
else
{
Collider[] hits = Physics.OverlapSphere(transform.position, 3f);
foreach (var hit in hits)
{
CarController car = hit.GetComponent<CarController>();
if (car != null)
{
car.EnterCar(transform);
currentCar = car;
inCar = true;
playerCamera.enabled = false;
break;
}
}
}
}
}
