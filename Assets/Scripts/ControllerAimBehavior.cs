using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAimBehavior : MonoBehaviour
{
    [SerializeField]
    private float amplitude;
    [SerializeField][Range(0f,1f)]
    private float quickness;
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private bool aimLocked = false;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Vector3 deslocAim = new Vector3(Input.GetAxis("HAim"), Input.GetAxis("VAim"), 0f);
        Vector3 aimDephtCorrection = new Vector3(0f, 0f, -0.5f);
        Vector3 direction = (cam.transform.position - transform.position);
        RaycastHit hit;
        Component halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
        int layerMask = 1 << 8;

        if (Physics.Raycast(cam.transform.position, -direction.normalized, out hit, Mathf.Infinity, layerMask))
        {
            halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
            Vector3 constrainedDeslocAim = new Vector3(Input.GetAxis("HAim") * hit.collider.bounds.extents.x * 0.75f, Input.GetAxis("VAim") * hit.collider.bounds.extents.y * 0.75f, 0f);

            if (hit.collider.tag == "Enemy")
            {
                if (Input.GetButtonDown("AimLock") == true)
                {
                    aimLocked = !aimLocked;
                }
                if (aimLocked)
                {
                    transform.position = hit.transform.position + constrainedDeslocAim;
                    Debug.Log(hit.collider.tag);
                }
                else
                {
                    transform.localPosition = Vector3.Lerp(transform.localPosition, deslocAim * amplitude + aimDephtCorrection, quickness);
                }
            }
            else
            {
                aimLocked = false;
            }
        }
        else
        {
            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
            aimLocked = false;
        }
        if (!aimLocked)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, deslocAim * amplitude + aimDephtCorrection, quickness);
        }
    }
}