using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundDisplay : MonoBehaviour
{
    [Header("Dynamic")]
    private TextMeshProUGUI gt;

    public EnemySpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        gt = GetComponent<TextMeshProUGUI>();
        spawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        gt.text = "Round: " + spawner.GetRound();
    }
}
