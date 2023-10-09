using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar: MonoBehaviour
{
  [SerializeField] private Image foregroundImage;

  public void UpdateHealthBar(float currentValue, float maxValue)
  {
    float currentFraction = currentValue / maxValue;
    foregroundImage.fillAmount = currentFraction;
  }

  void Update(){
    transform.position = transform.parent.parent.position + new Vector3(0, 1.5f, 0);
    transform.rotation = Quaternion.Euler(0, 0, 0);
  }

}