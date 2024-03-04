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
            // Проверяем наличие касания на экране

            rotationAngle += 90.0f; // Увеличиваем угол поворота на 90 градусов
                                    // Ограничиваем угол поворота до 360 градусов
            rotationAngle = rotationAngle % 360;

        }
        // Вращаем объект на указанный угол
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