using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage;
    [SerializeField] public GameObject _target;
    [SerializeField] public Vector3 startPosition;
    [SerializeField] public Vector3 targetPosition;

    private float distance;
    private float startTime;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
    }

    // Update is called once per frame
    void Update()
    {
        float timeInverval = Time.time - startTime;

        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInverval * speed / distance);

        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (_target != null)
            {
                Transform healthBarTransform = _target.transform.Find("HealthBarFull");
                EnemyHealthbar healthbar = healthBarTransform.gameObject.GetComponent<EnemyHealthbar>();
                healthbar.currentHealth -= Mathf.Max(damage, 0);

                if (healthbar.currentHealth <= 0)
                {
                    Destroy(_target);
                    //TODO: Sound abspielen, Coins dazupacken, Wave ändern ...
                    GameManager.singleton.SetCoins(GameManager.singleton.GetCoins() + 50);
                }


            }

            Destroy(gameObject);
        }
    }
}
