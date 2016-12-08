using UnityEngine;
using System.Collections;

public static class FindObjectExtensions
{
    public static GameObject GetPlayer() { return GameObject.Find("Player"); }
}
