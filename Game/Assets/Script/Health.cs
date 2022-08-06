using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public Image health;
    [SerializeField] private GameObject lostPanel;
    public float maxHealth = 100f;
    void Start()
    {
        health.fillAmount = maxHealth / 100f;
        if(health.fillAmount < 0)
        {
            lostPanel.SetActive(true);
        }
    }

    
    void Update()
    {
    }
}
