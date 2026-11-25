using System.Collections.Generic;
using UnityEngine;

public class AreaInfo : MonoBehaviour
{
    public string AreaName { get; private set; }

    public List<Item> fishInArea = new();

    public static AreaInfo CurrentAreaInfo;

    private void Awake()
    {
        CurrentAreaInfo = this;
    }
}
