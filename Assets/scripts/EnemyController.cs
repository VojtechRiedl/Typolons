using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Entity, ISpawn
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float spawnPositonY;
    private PlayerController player = PlayerController.GetInstance();

    public float SpawnPositonY { get => spawnPositonY; }

    public void Awake()
    {
        if(player != null)
        {
            lvl = Random.Range(1, player.Lvl + 3);
            text.text = "Level: " + lvl;
            MaxHp *= lvl;
            damage *= lvl / 2;
            defense *= lvl / 2;
            xp *= lvl;
            base.Awake();
        }

    }

    void Update()
    {
        if (AnimationController.IsPaused)
        {
            return;
        }
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    public override void attack(Entity entity)
    {
        animator.SetBool("idle", false);
        animator.SetTrigger("attack");
        entity.TakeDamage(damage - (player.Defense / 8));

    }
    public void EnemyAttackEnd()
    {
        if (player == null)
        {
            return;
        }
        player.attack(this);
        defend();
    }
    public override void defend()
    {
        healthBar.SetValue((float)hp / maxHp);
        animator.SetBool("idle", true);
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

}
