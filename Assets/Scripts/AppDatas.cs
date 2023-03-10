using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AppData")]
public class AppDatas : ScriptableObject
{
    public Language actualLanguage;
    
    public List<Language> languageList;
}