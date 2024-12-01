using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private Image mainHealthBar;
    [SerializeField] private Image backgroundHealthBar;
    [SerializeField] private GameObject parentHealthBar;
    [SerializeField] private float healthDeceleration = 0.5f;
    [SerializeField] private GameObject diePanel;
    private bool _isDamage;


    public void TakeDamage(float damage)
    {
        Debug.Log("Player Health TakeDamage");
        health -= damage;
    }

    private void Update()
    {
        backgroundHealthBar.fillAmount = Mathf.Lerp(backgroundHealthBar.fillAmount, health / 100f,
            healthDeceleration * Time.deltaTime);
        mainHealthBar.fillAmount = health / 100f;

        if (Mathf.Approximately(0, backgroundHealthBar.fillAmount))
        {
            diePanel.SetActive(true);
        }
    }
}