using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    [Header("Dynamic")]
    private TextMeshProUGUI gt;

    public EnemySpawner spawner;

    void Start()
    {
        gt = GetComponent<TextMeshProUGUI>();
        spawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
    }

    void Update()
    {
        gt.text = "Kills: " + spawner.GetKills();
    }
}
