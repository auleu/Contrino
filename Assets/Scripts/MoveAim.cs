using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAim : MonoBehaviour
{
    [SerializeField]
    private float amplitude; // distância que o objeto se desloca 
    [SerializeField]
    private float quickness; // quão rápido o objeto chega no deslocamento máximo, e quão rápido retorna pra posição inicial

    private void FixedUpdate()
    {
        Vector3 deslocAim = new Vector3(Input.GetAxis("HAim"),Input.GetAxis("VAim"),-0.05f); // cria o vector 3 do deslocamento
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition , deslocAim * amplitude , Time.deltaTime * quickness); // interpola entre a posição inicial e deslocamento máximo do objeto de acordo com o input horizontal e vertical
        
    }
}
