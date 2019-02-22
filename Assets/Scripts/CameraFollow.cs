using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject focusObject; //objeto para o qual a câmera aponta
    [SerializeField]
    private GameObject aimFocus;

    void Update()
    {
        this.transform.LookAt(Vector3.Lerp(focusObject.transform.position, aimFocus.transform.position, 0.5f));// faz a câmera sempre olhar para o objeto
    }
}
