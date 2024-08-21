using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : PrincessState
{
    public Items items;
    private float rotation = 100f;
    private bool hasWeapon;
    private GameObject princessObject;
    public override void Enter(Princess princess)
    {
        princessObject = princess.gameObject;
        Debug.Log("weapon state masokk");
        princess.StartCoroutine(Attack());
    }

    public override void Execute(Princess princess)
    {
        if(princess.gameObject.transform.childCount > 0)
        {
            CheckItem(princess);
        }
        else 
        {
            princess.ChangeState(princess.noWeapon);
        }
        // melakukan serangan melingkar 360 derajat untuk melee
        // kalau batu serangan langsung ngincer ke musuh
    }

    public override void Exit(Princess princess)
    {
        princess.StopCoroutine(Attack());
    }

    
    void CheckItem(Princess princess)
    {
        items = princess.GetComponentInChildren<Items>();
        hasWeapon = true;
    }

    void MeleeAttack()
    {
        // 360 derajat
        GameObject weapon = items.gameObject;
        weapon.transform.RotateAround(princessObject.transform.position, Vector3.forward, rotation * Time.deltaTime);
    }

    void RangeAttack()
    {

    }

    IEnumerator Attack()
    {
        while(hasWeapon)
        {
            hasWeapon = false;
            if(items.itemType == ItemType.Sword)
            {
                MeleeAttack();
            }
            else if(items.itemType == ItemType.Bow)
            {
                RangeAttack();
            }
            yield return new WaitForSeconds(1f);
            hasWeapon = true;
        }
    }
}
