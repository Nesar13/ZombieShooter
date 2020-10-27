using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
    }
    // Update is called once per frame
    void Update()
    {
        int previousWeapon = currentWeapon;
        ProcessKeyInput(); // number input to switch weapons
        ProcessScrollWheel(); // scroll wheel input 
        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();//toggle through until we reach desired weapon
        }
    }
    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) //positive values are for scrolling up
        {
            if (currentWeapon >= transform.childCount - 1) //"-1" since index start at 0, childcount is the number of chidlren under gameobject
            {
                currentWeapon = 0;//reset index to "0" once we mouse scroll through all items
            }
            else
            {
                currentWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) //negative values are for scrolling down
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
            }
        }
    }
    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //key #1
        {
            currentWeapon = 0;//first weapon in index
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //key #2
        {
            currentWeapon = 1;//second weapon in index
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) //key #3
        {
            currentWeapon = 2;//third weapon in index
        }
    }
    private void SetWeaponActive()
    {
        int weaponIndex = 0; //current index
        foreach (Transform weapon in transform)//uses transform as the tag to identify each weapon
        {
            if (weaponIndex == currentWeapon)//if the weaponIndex match what gun holded you will make it active
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);//all other guns will be inactive
            }
            weaponIndex++;//keep increamnting untill we reach true weapon
        }
    }

}