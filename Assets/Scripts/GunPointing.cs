using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPointing : MonoBehaviour
{
    public GameObject aimFocus;

    void Update()
    {
        this.transform.LookAt(aimFocus.transform.position);
    }
}
