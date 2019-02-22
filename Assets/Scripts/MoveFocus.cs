using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFocus : MonoBehaviour
{
    [SerializeField]
    private float amplitude; // distância que o objeto se desloca 
    [SerializeField]
    private float quickness; // quão rápido o objeto chega no deslocamento máximo, e quão rápido retorna pra posição inicial

    private void FixedUpdate()
    {
        Vector3 desloc = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical") * 3.0f); // cria o vector 3 do deslocamento
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition , desloc * amplitude , Time.deltaTime * quickness); // interpola entre a posição inicial e deslocamento máximo do objeto de acordo com o input horizontal e vertical
    }
}
