using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
  public float damageMultiplier = 0.1f;
  void OnCollisionEnter(Collision collision)
  {
    Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    if (collision.gameObject.tag == "Enemy")
    {
      Vector3 collisionForce = collision.impulse / Time.fixedDeltaTime;
      print(collisionForce.magnitude * damageMultiplier);

      enemy.TakeDamage(collisionForce.magnitude * damageMultiplier);
    }
  }
}