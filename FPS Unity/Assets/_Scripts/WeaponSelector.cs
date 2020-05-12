using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    //this defines a custom class that we're using to associate a reference to a weapon along with whether we have collected it or not.
    [System.Serializable]
    public class SelectableWeapon
    {
        public GameObject weaponGameObject;
        public bool collected = false;
    }

    //this is a list of the selectableweapon class. this is where the actual data is stored
    public List<SelectableWeapon> weapons = new List<SelectableWeapon>();   

    // Update is called once per frame
    void Update()
    {
            //select the associated weapon for each weapon button
            if (Input.GetButtonDown("SelectWeapon1"))
        {
            SelectWeapon(0);
        }
        else if(Input.GetButtonDown("SelectWeapon2"))
        {
            SelectWeapon(1);
        }
        else if(Input.GetButtonDown("SelectWeapon3"))
        {
            SelectWeapon(2);
        }
        else if(Input.GetButtonDown("SelectWeapon4"))
        {
            SelectWeapon(3);
        }
    }

    //select the weapon at the specified index of our array list
    public void SelectWeapon (int selectedIndex)
    {
        //make sure that the selection is valid - it needs to be in the array range and
        //also needs to refer to a weapon we have collected
        if (selectedIndex < 0 ||
            selectedIndex >= weapons.Count ||
            weapons[selectedIndex] == null ||
            weapons[selectedIndex].collected == false)
        {
            return;
        }

        //activate the selected weapon, deactive the other
        for (int index = 0; index < weapons.Count; index++)
        {
            if (weapons[index] != null)
            {
                weapons[index].weaponGameObject.SetActive(index == selectedIndex);
            }
        }
    }

    public void CollectWeapon (string collectedWeaponName)
    {
        //look at each weapon in our list of selectable weapons
        for (int i = 0; i < weapons.Count; i++)
        {
            //and if we find a match, set its "collected" flag to true
            if (weapons[i] != null && weapons[i].weaponGameObject.name == collectedWeaponName)
            {
                weapons[i].collected = true;

                //and also select it
                SelectWeapon(i);
            }
        }
    }
}
