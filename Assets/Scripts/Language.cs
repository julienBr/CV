using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Language")]
public class Language : ScriptableObject
{
    public int index;
    [TextArea(3, 10)]
    public string[] sentences;
}