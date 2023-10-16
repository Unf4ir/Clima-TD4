using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    public void updateMoney()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
