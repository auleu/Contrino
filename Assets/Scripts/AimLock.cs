using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLock : MonoBehaviour
{
    private Camera cam;
    private Transform tgt;

    //[SerializeField]
    //private GameObject lookAtTgt;
    //[SerializeField]
    //private GameObject parent;

    //private Vector3 aimPos;
    private void Start()
    {
        cam = Camera.main;
    }
    private void FixedUpdate()
    {
        Vector3 aimScreenPos = cam.WorldToScreenPoint(transform.position);
        Vector3 tgtScreenPos = cam.WorldToScreenPoint(tgt.position);
        RaycastHit hit;
        int layerMask = 1 << 8;

        if (Physics.Raycast(aimScreenPos, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.tag == "Enemy")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, hit.transform.position.z);
            }
        }
            //Vector3 deslocAimToInput = new Vector3(Input.GetAxis("HAim"), Input.GetAxis("VAim"), 0f) * amplitude;
            //Vector3 playerPos = parent.transform.position;

            //transform.LookAt (lookAtTgt.transform.position);
            //RaycastHit hit;
            //int layerMask = 1 << 8;
            //if (Physics.Raycast(transform.position, -transform.forward, out hit, Mathf.Infinity, layerMask))
            //{
            //    if (hit.collider.tag == "Enemy")
            //    {
            //        aimPos = hit.transform.position;
            //    }
            //}
            //else if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
            //{
            //    if (hit.collider.tag == "Enemy")
            //    {
            //        aimPos = hit.transform.position;
            //    }
            //}
            //else
            //{
            //    aimPos = playerPos;
            //}
            //transform.position = aimPos + deslocAimToInput;
    }
}