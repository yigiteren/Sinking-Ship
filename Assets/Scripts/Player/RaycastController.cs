using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{

    Camera cam;
    [SerializeField] float maximumInteractionDistance = 5f;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, maximumInteractionDistance))
        {
            if(hit.transform.tag == "Hole" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                hit.transform.GetComponent<Hole>().DamageHole();
            }
        }
        
    }

}
