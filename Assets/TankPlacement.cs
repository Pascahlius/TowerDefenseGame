using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlacement : MonoBehaviour
{
    [SerializeField] GameObject tank;
    GameObject tankSpawner;
    
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
        if (CanPlaceTank())
        tankSpawner = Instantiate(tank, transform.position, tank.transform.rotation);
    }

    private bool CanPlaceTank()
    {
        if (tankSpawner == null)
        {
            return true;
        }else
        {
            return false;
        }
    }
}
