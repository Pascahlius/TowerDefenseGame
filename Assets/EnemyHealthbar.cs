using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealthbar : MonoBehaviour
{
    public float maxHealth = 100;
    [SerializeField] float currentHealth;
    float originalScale;
    
    // Start is called before the first frame update
    void Start()
    {
        originalScale = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempScale = gameObject.transform.localScale;
        tempScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tempScale;
    }
}
