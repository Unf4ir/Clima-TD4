using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standartTurretPrefab;
    public TurretBlueprint missleLauncherPrefab;
    public TurretBlueprint laserBeamerPrefab;

    public Button chooseStandardTurret;
    public Button chooseMissleLauncher;
    public Button chooseLaserBeamer;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void StandardTurretChosen()
    {
        // Rufe die Methode im BuildManager auf und übergib den Turmtyp "StandardTurret"
        buildManager.SelectTurretToBuild(standartTurretPrefab);
    }

    public void MissleLauncherChosen()
    {
        // Rufe die Methode im BuildManager auf und übergib den Turmtyp "MissileLauncher"
        buildManager.SelectTurretToBuild(missleLauncherPrefab);
    }
    public void LaserBeamerChosen()
    {
        // Rufe die Methode im BuildManager auf und übergib den Turmtyp "MissileLauncher"
        buildManager.SelectTurretToBuild(laserBeamerPrefab);
    }
}
