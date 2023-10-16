using UnityEngine;

public class Ground : MonoBehaviour
{
    BuildManager buildManager;

    private GameObject turret;
    public Color hoverColor;
    private Renderer rend;
    private Color startColor;
    private bool isMouseOver = false; // Variable, um den Mausstatus zu speichern
    private bool hasClicked = false; // Variable, um den Klickstatus zu speichern

    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        if (buildManager.CanBuild && buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
            isMouseOver = true;
        } else
        {
            rend.material.color = Color.red;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
        isMouseOver = false;
    }

    void OnMouseDown()
    {
        if (!hasClicked)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 29; //Ungerade Zahl aufgrund der Kamera höhe bei 30)
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Quaternion worldRotation = Quaternion.Euler(0,0,0); // Hier die Rotation einstellen, wie du es benötigst

            Debug.Log(worldPosition);

            if (HasTurretAtPosition(worldPosition))
            {
                Debug.Log("Hier wurde schon gebaut");
            }
            else
            {
                BuildManager.instance.BuildTurret(worldPosition, worldRotation); // Übergabe der Position und Rotation an den BuildManager
            }
            rend.material.color = startColor;
            hasClicked = true;
        }
    }

    private bool HasTurretAtPosition(Vector3 position)
    {
        if (turret != null)
        {
            return true; // Es gibt bereits einen Turm
        }
        else
        {
            return false; // Es gibt keinen Turm an dieser Position
        }
    }

    private void Update()
    {
        if (isMouseOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnMouseDown();
            }
        }
        else
        {
            hasClicked = false; // Zurücksetzen, wenn die Maus das Objekt verlässt
        }
    }
}