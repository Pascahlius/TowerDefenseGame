using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public List<GameObject> _enemiesInRange;

    private float lastShotTime;
    private TankData _data;
    
    // Start is called before the first frame update
    void Start()
    {
        _enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
        _data = gameObject.GetComponentInChildren<TankData>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject _target = null;
        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in _enemiesInRange)
        {
            float distanceToGoal = enemy.GetComponent<Enemy>().DistanceToGoal();

            if (distanceToGoal < minimalEnemyDistance)
            {
                _target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }

        if (_target != null)
        {
            if(Time.time - lastShotTime > _data.currentLevel.fireRate)
            {
                Shoot(_target.GetComponent<Collider2D>());
                lastShotTime = Time.time;
            }
        }
        
        //Drehen und Schiessen der Tanks
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            _enemiesInRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            _enemiesInRange.Remove(collision.gameObject);
        }
    }

    private void Shoot(Collider2D target)
    {
        GameObject bulletPrefab = _data.currentLevel.bullet;

        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;

        startPosition.z = bulletPrefab.transform.position.z;
        targetPosition.z = bulletPrefab.transform.position.z;

        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        Bullet bulletComp = newBullet.GetComponent<Bullet>();

        bulletComp._target = target.gameObject;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;
    }
}
