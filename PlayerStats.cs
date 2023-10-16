using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 100;

    public MoneyUI moneyUI;
    public LivesUI livesUI;

    public static bool obtainedDamage = false;
    public static bool moneyChange = false;
    private void Awake()
    {
        Money = startMoney;
        moneyUI.updateMoney();
        Lives = startLives;
        livesUI.updateLives();
    }
    private void Update()
    {
        if (obtainedDamage) {
            livesUI.updateLives();
            obtainedDamage = false;
        }
        if (moneyChange)
        {
            moneyUI.updateMoney();
            moneyChange = false;
        }
    }
}
