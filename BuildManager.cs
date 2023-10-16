using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public MoneyUI moneyUI;
    [HideInInspector]
    public TurretBlueprint turretToBuild;
    

    private void Awake()
    {
        instance = this;
        turretToBuild = null;
    }
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurret(Vector3 buildPosition, Quaternion buildRotation)
    {
        if (!CanBuild || !HasMoney) { return; }
        PlayerStats.Money -= turretToBuild.cost; //Abzug des Geldes
        moneyUI.updateMoney(); //Updaten des Geldes in der UI
        Instantiate(turretToBuild.prefab, buildPosition, buildRotation);
        turretToBuild = null;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        // Setze das �bergebene Turm-Gameobject als Turm, der gebaut werden soll
        turretToBuild = turret;
        // Hier k�nntest du den Shop aufrufen und den ausgew�hlten Turm �bergeben
    }
}
