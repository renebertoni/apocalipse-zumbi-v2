using UnityEngine;
using TMPro;
using System;

public class UI_Counter : MonoBehaviour
{
    public TMP_Text textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();
        textMeshPro.text = "0";
    }

    void OnEnable()
    {
        EnemyHealth.EnemyDead += AddCounter;
    }
    
    void OnDisable()
    {
        EnemyHealth.EnemyDead -= AddCounter;
    }

    void AddCounter()
    {
        var number = Convert.ToInt32(textMeshPro.text);
        var numberStr = number + 1;
        textMeshPro.text = numberStr.ToString();
    }
}
