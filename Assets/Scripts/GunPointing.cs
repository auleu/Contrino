using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPointing : MonoBehaviour
{
    [SerializeField]
    private GameObject focusAim;

    void Update()
    {
        this.transform.LookAt(focusAim.transform.position);
    }
}
