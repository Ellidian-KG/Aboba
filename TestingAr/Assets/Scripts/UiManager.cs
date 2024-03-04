using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject _gameObject;


    public void OnPrefabs()
    {
        Debug.Log("sucsesss");
        _gameObject.SetActive(true);
    }
}
