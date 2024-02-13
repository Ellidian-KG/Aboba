using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class buttonVR : MonoBehaviour
{
    
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelese;
    GameObject presser;
    AudioSource sound;
    bool isPressed;
    private void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }
        private void OnTriggerExit(Collider other)
    {
        if (other == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelese.Invoke();
            isPressed = false;
        }
    }
    public void StartScript()
    {

    }
}

