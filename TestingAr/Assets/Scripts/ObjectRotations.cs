using UnityEngine;

public class ObjectRotations : MonoBehaviour
{
    private float rotationAngle = 0.0f;
    private Vector3 offset;
    private float zCoord;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ��������� ������� ������� �� ������

            rotationAngle += 90.0f; // ����������� ���� �������� �� 90 ��������
                                    // ������������ ���� �������� �� 360 ��������
            rotationAngle = rotationAngle % 360;

        }
        // ������� ������ �� ��������� ����
        transform.rotation = Quaternion.Euler(0, rotationAngle, 0);
    }
    void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        Vector3 newPos = GetMouseWorldPos() + offset;
        newPos.y = transform.position.y; // Keep the same y position
        transform.position = newPos;
    }
}