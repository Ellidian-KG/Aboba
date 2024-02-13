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
        // �������� ������� �������� �� ���������
        Vector2 joystickValue = joystickAction.GetAxis(handType);
        Vector2 secondJoystickValue = secondJoystickAction.GetAxis(handTypeLeft);

        // ����������� ������� �������� � ��������� ������ � ����������� ���
        Vector3 movement = new Vector3(joystickValue.x, 0, joystickValue.y).normalized;

        // ������� ���� ������/����� � �����/������ � �������� ���������
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);

        float liftValue = secondJoystickValue.y * liftSpeed;
        rb.velocity = new Vector3(rb.velocity.x, liftValue, rb.velocity.z);

        // ��������� ������� �� ������ ��������������
        if (interactAction.GetStateDown(handType))
        {
            if (carriedItem == null)
            {
                // ���� ������� �� ������, �������� ������� ��������� �������
                PickupItem();
            }
            else
            {
                // ���� ������� ������, ������� ���
                ThrowItem();
            }
        }
    }

    private void PickupItem()
    {
        // ��������� ������, ���� �� ����� ��������
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Item") || collider.CompareTag("Sphere") || collider.CompareTag("Cube") || collider.CompareTag("Pistol"))
            {
                // ���� ������ �������, ��������� ��� � ��������� ������ �� ����
                carriedItem = collider.gameObject;
                carriedItem.transform.SetParent(transform);
                carriedItem.GetComponent<Rigidbody>().isKinematic = true;
                break;
            }
        }
    }

    private void ThrowItem()
    {
        // ������� ������� �� ����� ������
        carriedItem.transform.SetParent(null);
        Rigidbody itemRb = carriedItem.GetComponent<Rigidbody>();
        itemRb.isKinematic = false;
        itemRb.velocity = rb.velocity + transform.forward * throwForce;
        carriedItem = null;
    }
}