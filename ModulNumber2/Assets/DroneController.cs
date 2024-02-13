using UnityEngine;
using Valve.VR;

public class DroneController : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Input_Sources handTypeLeft;
    public SteamVR_Action_Vector2 joystickAction;
    public SteamVR_Action_Vector2 secondJoystickAction;
    public SteamVR_Action_Boolean interactAction; 

    public float speed = 5f; 
    public float throwForce = 5f; 
    public float liftSpeed = 2f; 

    private Rigidbody rb;
    private GameObject carriedItem; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Получаем входное значение от джойстика
        Vector2 joystickValue = joystickAction.GetAxis(handType);
        Vector2 secondJoystickValue = secondJoystickAction.GetAxis(handTypeLeft);

        // Преобразуем входное значение в двумерный вектор и нормализуем его
        Vector3 movement = new Vector3(joystickValue.x, 0, joystickValue.y).normalized;

        // Двигаем дрон вперед/назад и влево/вправо с заданной скоростью
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);

        float liftValue = secondJoystickValue.y * liftSpeed;
        rb.velocity = new Vector3(rb.velocity.x, liftValue, rb.velocity.z);

        // Проверяем нажатие на кнопку взаимодействия
        if (interactAction.GetStateDown(handType))
        {
            if (carriedItem == null)
            {
                // Если предмет не поднят, пытаемся поднять ближайший предмет
                PickupItem();
            }
            else
            {
                // Если предмет поднят, бросаем его
                ThrowItem();
            }
        }
    }

    private void PickupItem()
    {
        // Проверяем сферой, есть ли рядом предметы
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Item") || collider.CompareTag("Sphere") || collider.CompareTag("Cube") || collider.CompareTag("Pistol"))
            {
                // Если найден предмет, поднимаем его и сохраняем ссылку на него
                carriedItem = collider.gameObject;
                carriedItem.transform.SetParent(transform);
                carriedItem.GetComponent<Rigidbody>().isKinematic = true;
                break;
            }
        }
    }

    private void ThrowItem()
    {
        // Бросаем предмет со силой вперед
        carriedItem.transform.SetParent(null);
        Rigidbody itemRb = carriedItem.GetComponent<Rigidbody>();
        itemRb.isKinematic = false;
        itemRb.velocity = rb.velocity + transform.forward * throwForce;
        carriedItem = null;
    }
}