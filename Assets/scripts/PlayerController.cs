using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerController : Entity
{
    private static PlayerController instance;

    [SerializeField]
    private int neededExp;

    [SerializeField]
    private BarController expBar;
    [SerializeField]
    private EnemyController currentEnemy;

    public int NeededExp { get => neededExp; set => neededExp = value; }
    // Update is called once per frame
    public void Start()
    {
        lvl = 1;
        instance = this;
    }
    void Update()
    {
        if(Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        AnimationController.Pause();
        if (collision.gameObject.tag == "Enemy")
        {
            currentEnemy = collision.gameObject.GetComponent<EnemyController>();
            attack(currentEnemy);
            currentEnemy.defend();
        }
        else if (collision.gameObject.tag == "Campfire")
        {
            Heal();
        }

    }

    public void AttackAnimEnd()
    {
        Debug.Log("attackAnimEnd");
        if (currentEnemy == null)
        {
            return;
        }
        currentEnemy.attack(this);
        defend();

        if (currentEnemy.Hp <= 0)
        {
            xp += currentEnemy.Xp;
            expBar.SetValue((float)xp / neededExp);
            if (xp >= neededExp)
            {
                LevelUp();
            }
            AnimationController.UnPause();
            animator.SetBool("idle", false);
            currentEnemy.Die();
            currentEnemy = null;
            
        }
    }
    public override void attack(Entity entity)
    {
        animator.SetBool("idle", false);
        animator.SetTrigger("attack");
        entity.TakeDamage(damage - (currentEnemy.Defense / 8));
    }

    public override void defend()
    {
        animator.SetBool("idle", true);
        healthBar.SetValue((float)hp / maxHp);
    }

    public override void Die()
    {
        Destroy(gameObject);
        AnimationController.Pause();
    }

    public void LevelUp()
    {
        lvl += 1;
        xp = xp - neededExp;
        expBar.SetValue((float)xp / neededExp);
        neededExp += 10;
        maxHp += 10;
        hp = maxHp;
        healthBar.SetValue((float)hp / maxHp);
        this.text.text = "Level: " + lvl;
    }
    public void Heal()
    {
        hp = maxHp;
        healthBar.SetValue((float)hp / maxHp);
    }
    public static PlayerController GetInstance()
    {
        return instance;
    }


}
