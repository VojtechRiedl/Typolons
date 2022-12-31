using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Entity : MonoBehaviour
{
    protected int lvl;
    protected int hp;
    [SerializeField]
    protected int maxHp;
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected int defense;
    [SerializeField]
    protected int xp;
    
    public int Hp { get => hp; set => hp = value; }
    public int MaxHp { get => maxHp; set => maxHp = value; }
    public int Xp { get => xp; set => xp = value; }
    public int Defense { get => defense; set => defense = value; }
    public int Damage { get => damage; set => damage = value; }
    public int Lvl { get => lvl; set => lvl = value; }

    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected BarController healthBar;
    [SerializeField]
    protected Text text;

    public void Awake()
    {
        hp = maxHp;
    }

    public abstract void attack(Entity entity);

    public abstract void defend();

    public abstract void Die();

    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
    }
}
