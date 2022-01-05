using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlacementMINE : MonoBehaviour
{
    [SerializeField] GameObject[] tank;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        
        Instantiate (tank[0], transform.position, tank[0].transform.rotation);
    }
}
