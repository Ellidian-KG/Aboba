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
        // ���������, ������ �� ������ �� ��������� ������
        if (SteamVR_Input.GetStateDown("GrabPinch", SteamVR_Input_Sources.RightHand))
        {
            // ���������, ��������� �� ����� ����� � �������
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= 2f)
            {
                // ���������, ���� �� �������� � ���� ������
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
            // ��������, ����� ����� ����� �� ������
            player.transform.position = transform.position + new Vector3(0f, 0.5f, 0f);
        }

        if (isRunning)
        {
            // ������������ ������ � ����������� ��������
            Vector3 direction = carrot.transform.position - transform.position;
            transform.LookAt(carrot.transform);
            // ������ ����� �� ���������
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}