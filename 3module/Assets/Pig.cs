using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Pig : MonoBehaviour
{
    public GameObject player;
    public GameObject carrot;
    private bool isSitting = false;
    private bool hasCarrot = false;
    private bool isRunning = false;
    [SerializeField] private int speed =5;
 

    void Update()
    {
        // Проверяем, нажата ли кнопка на джойстике игрока
        if (SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.RightHand))
        {
            // Проверяем, находится ли игрок рядом с свинкой
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= 2f)
            {
                // Проверяем, есть ли морковка в руке игрока
                if (carrot.activeSelf)
                {
                    hasCarrot = true;
                    isRunning = true;
                }
                isSitting = true;
            }
        }

        if (isSitting)
        {
            // Действия, когда игрок сидит на свинке
            player.transform.position = transform.position + new Vector3(0f, 0.5f, 0f);
        }

        if (isRunning)
        {
            // Поворачиваем свинку в направлении морковки
            Vector3 direction = carrot.transform.position - transform.position;
            transform.LookAt(carrot.transform);
            // Свинка бежит за морковкой
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}