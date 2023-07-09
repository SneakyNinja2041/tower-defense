using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    

    private Renderer rend;
    private Color startColor;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    public bool isFinal = false;

  

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret (TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("U BROKE!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        Debug.Log("Turret Built" + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money for Upgrade");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        // get rid of old turret for upgraded turret
        Destroy(turret);

        // building new upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;


        Debug.Log("Turret Upgraded");

    }

    public void FinalTurret()
    {

        if (PlayerStats.Money < turretBlueprint.finalCost)
        {
            Debug.Log("Not enough money for Upgrade");
            return;
        }

        if (isUpgraded == true)
        {
            PlayerStats.Money -= turretBlueprint.finalCost;

            // get rid of old turret for upgraded turret
            Destroy(turret);

            // building new upgraded turret
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.finalPrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;

            isFinal = true;

            Debug.Log("Turret Upgraded");
        }
       
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;
        isFinal = false;
    }
    
    void OnMouseEnter()
    {
        

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
