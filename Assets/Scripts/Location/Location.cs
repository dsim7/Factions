﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Location : ScriptableObject
{
    public string locationName;
    public string description;
    public Mission[] potentialMissions;
}
