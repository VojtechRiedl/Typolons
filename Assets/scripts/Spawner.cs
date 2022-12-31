using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> prefabs = new List<GameObject>();
    [SerializeField]
    private float SpawnRate;


    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (AnimationController.IsPaused)
        {
            return;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            timer = SpawnRate;
        }
    }

    private void SpawnEnemy(){
        int index = Random.Range(0, prefabs.Count);
        var enemy = prefabs[index];
        var position = new Vector3(transform.position.x, enemy.GetComponent<ISpawn>().SpawnPositonY);

        Debug.Log("Spawning enemy at " + position);
        Instantiate(prefabs[index], position, Quaternion.identity);
        
    }
}
