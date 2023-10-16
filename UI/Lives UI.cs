using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    public void updateLives()
    {
        livesText.text = PlayerStats.Lives.ToString();
    }
}
