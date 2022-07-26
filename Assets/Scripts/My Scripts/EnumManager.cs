using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObjectTypes
{
    environment,
    enemyHead,
    enemy,
    dynamite
}

public class EnumManager : MonoBehaviour
{
    public ObjectTypes myObjectType;
}
