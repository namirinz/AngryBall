using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy: MonoBehaviour
{
  [SerializeField] private float health, maxHealth = 3f;

  Rigidbody rb;

  [SerializeField] private FloatingHealthBar healthBar;

  private void Awake()
  {
    rb = GetComponent<Rigidbody>();
    healthBar = GetComponentInChildren<FloatingHealthBar>();
  }

  public void TakeDamage(float damageAmount){
    health -= damageAmount;
    healthBar.UpdateHealthBar(health, maxHealth);
    if(health <= 0){

      rb.constraints = RigidbodyConstraints.None;
      rb.AddForce(new Vector3(0, 0, 1) * 1000);

      // Wait for 2 seconds before destroying the game object
      Destroy(gameObject, 2f);
    }
  }
}