﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//This is a class that contains information on who will trigger projectile, or any objects affect. Once triggered, who will be affected by the object? 
//Think of an explosion, it can be triggered by enemies, but when it explodes does it hurt everyone? or just the enemies. 
public class Sendable : MonoBehaviour{
    //make this a function class. for performance of AI being integrated
    public List<string> targets;
    public List<string> affected;
    public bool hitsBarriers = true;
    private void Start()
    {
        affected = affected ?? targets;
    }
    public bool IsReceiver(GameObject other)
    {
        if (targets.Contains(other.gameObject.tag) || (hitsBarriers && other.gameObject.CompareTag("Barrier")))
        {
            return true;
        }
        return false;
    }

}
