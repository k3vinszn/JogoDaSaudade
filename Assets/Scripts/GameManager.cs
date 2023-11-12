using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int score;
    public TextMeshProUGUI text;
    private void OnEnable()
    {
        score = PlayerPrefs.GetInt("Score");
        text.text = (" "+score);
    }
}
