using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public enum LinkMapIndex
    {
        Up,
        Down,
        Left,
        Right
    }

    public Map[] LinkMapList;
}