using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveAim : MonoBehaviour
{
    private void FixedUpdate()
    {
        Vector3 deslocAim = new Vector3(Input.GetAxis("MouseHAim"),Input.GetAxis("MouseVAim"),0f); // cria o vector 3 do deslocamento
        this.transform.Translate (deslocAim);
        
    }
}
