using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
    
{
    public Transform cam;
    public Vector3 v2 = new Vector3(0,0,-50);
    public float pointIncreasedPerSecond;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cameraKaydırma();


    }
    public void cameraKaydırma()
    {
        v2.y -= pointIncreasedPerSecond*Time.deltaTime;
        cam.position = v2; 
    }
        
}
