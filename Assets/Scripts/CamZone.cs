using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamZone : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCam2 = null;
    [SerializeField] private CinemachineVirtualCamera virtualCam1 = null;
    // Start is called before the first frame update
    void Start()
    {
        virtualCam2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player");
            if(other.transform.position.x> transform.position.x)
            {
                virtualCam1.enabled = false;
                virtualCam2.enabled = true;
            }
            else
            {
                virtualCam1.enabled = true;
                virtualCam2.enabled = false;

            }
        }
    }
}
