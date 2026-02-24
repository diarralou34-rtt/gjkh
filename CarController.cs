using UnityEngine;

public class CarController : MonoBehaviour
{
public float maxSpeed = 50f;
public float acceleration = 30f;
public float turnSpeed = 70f;

private Rigidbody rb;
private bool occupied = false;

void Start() => rb = GetComponent<Rigidbody>();

void Update()
{
if (!occupied) return;

float v = Input.GetAxis("Vertical") * acceleration * Time.deltaTime;
float h = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

rb.MovePosition(rb.position + transform.forward * v);
transform.Rotate(0, h, 0);
}

public void EnterCar(Transform player)
{
occupied = true;
player.gameObject.SetActive(false);
}

public void ExitCar(Transform player)
{
occupied = false;
player.position = transform.position + transform.right * 2f;
player.gameObject.SetActive(true);
}
}
