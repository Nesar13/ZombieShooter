using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots; 

    [System.Serializable]
    //Didar remove this comment
    // creating a class for ammos which will be used to get ammotype
    // and the ammoAmount
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount; 

    }


    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }
    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount+= ammoAmount;
    }
    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {   // search through bullet types to match it 
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType) 
            {
                return slot;
            }
        }
        return null; 
    }


}
