using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreValueText;
    public float scoreValue = 0f;
    public float pointIncreasedPerSecond = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public float getScoreValue() { return scoreValue; }
}
