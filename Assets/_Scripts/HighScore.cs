using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public Text highScore;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
