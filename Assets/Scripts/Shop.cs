using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TurretBlueprint standardTurret;
    public TurretBlueprint archerTurret;
    public TurretBlueprint swordTurret;

    void Start()
    {
        buildManager = BuildManager.instance;

    }


    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectArcherTurret()
    {
        Debug.Log("Standard Archer Selected");
        buildManager.SelectTurretToBuild(archerTurret);
    }

    public void SelectSwordTurret()
    {
        Debug.Log("Standard Sword Selected");
        buildManager.SelectTurretToBuild(swordTurret);
    }

}
