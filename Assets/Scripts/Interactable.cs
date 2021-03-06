﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//This class is currently under developement.
//Once you select an object to interact with this generates its possible interactions.
public class Interactable : MonoBehaviour {

    private GameObject interactionGrid;
    private GameObject interactable;
    public bool moveable = false;

    private Variables vs;
    void Start()
    {
        vs = GetComponent<Variables>();

        interactable = gameObject;
        interactionGrid = GameObject.Find("GlobalScripts").GetComponent<MenuScript>().interactionGrid;
    }
    public void CloseInteractions()
    {
        var children = new List<GameObject>();
        foreach (Transform child in interactionGrid.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

    }
    public void GetInteractions()
    {
        
        ImpactDamage ids = interactable.GetComponent<ImpactDamage>();
        if (ids)
        {
            GameObject buttonObj = Instantiate(Create.GetPrefab("Grid Button"), interactionGrid.transform);
            ClickableObject cs = buttonObj.AddComponent<ClickableObject>();
            Button button = buttonObj.GetComponent<Button>();
            Text txt = buttonObj.GetComponentInChildren<Text>();
            txt.text = "Increase Damage";
            cs.leftClick = () => ids.impactDamage += 1;
            //cs.rightClick = delegate { Upgrade(pair.Key, txt); };
        }
        if(interactable.name == "townhall")
        {

        }
        if (true)
        {
            GameObject v3Obj = Instantiate(Create.GetPrefab("Vector3 Input"), interactionGrid.transform);
            GameObject buttonObj = v3Obj.transform.Find("Button").gameObject;
            ClickableObject cs = buttonObj.AddComponent<ClickableObject>();
            Button button = buttonObj.GetComponent<Button>();
            Text txt = buttonObj.GetComponentInChildren<Text>();
            txt.text = "Set Position";
            GameObject attachedTo = GetComponent<FixedJoint>().connectedBody.gameObject;

            float x;
            float y;
            float z;
            Vector3 relative = vs.displacement;

            v3Obj.transform.Find("X").GetComponent<InputField>().text = Math.Round((decimal)relative.x,2).ToString();
            v3Obj.transform.Find("Y").GetComponent<InputField>().text = Math.Round((decimal)relative.y,2).ToString();
            v3Obj.transform.Find("Z").GetComponent<InputField>().text = Math.Round((decimal)relative.z,2).ToString();
            cs.leftClick = () =>
            {
                Destroy(GetComponent<FixedJoint>());
                try { x = float.Parse(v3Obj.transform.Find("X").GetComponent<InputField>().text); } catch (FormatException) {x = 0; }
                try { y = float.Parse(v3Obj.transform.Find("Y").GetComponent<InputField>().text); } catch (FormatException) { y = 0; }
                try { z = float.Parse(v3Obj.transform.Find("Z").GetComponent<InputField>().text); } catch (FormatException) { z = 0; }
                Create.AttachFixed(gameObject, attachedTo, new Vector3(x, y, z));
            };
        }


    }
}
    //AddInteractions
    /*
    // Use this for initialization
    List<Action<int>> iNums;
    List<Action<float>> iFloats;
    GameObject interactable;
    public GameObject menu;
    void Start () {
        ImpactDamage ims = interactable.GetComponent<ImpactDamage>();
        if (ims)
        {
            iNums.Add((newVal) => ims.impactDamage = newVal);
        }
        
        
	}
    */



