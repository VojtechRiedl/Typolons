using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireController : MonoBehaviour, ISpawn
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float spawnPositonY;

    public float SpawnPositonY => spawnPositonY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AnimationController.IsPaused)
        {
            return;
        }
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

}
