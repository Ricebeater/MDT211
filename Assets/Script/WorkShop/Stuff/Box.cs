using NUnit.Framework;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Box : Stuff, IInteractable, Idestoryable
{
    public Box() {
        Name = "Box";
    }
    public GameObject DropItem;
    
    public bool isInteractable { 
        get => CanUse; 
        set => CanUse = value; 
    }
    
    public int health { 
        get => _health; 
        set => _health = Mathf.Clamp(value, 0, _maxHealth); 
    }
    
    public int maxHealth { 
        get => _maxHealth; set => 
            _maxHealth = value; 
    }

    private int _health;
    private int _maxHealth = 25;

    Rigidbody _rb;

    public override void SetUP()
    {
        base.SetUP();
        _rb = GetComponent<Rigidbody>();
    }

    public event Action<Idestoryable> OnDestory;

    public void Interact(Player player)
    {
        _rb.isKinematic = !_rb.isKinematic;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            GameObject g = Instantiate(DropItem, transform.position, Quaternion.identity);
            OnDestory?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
