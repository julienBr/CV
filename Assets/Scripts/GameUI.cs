using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AppDatas _datas;
    [SerializeField] private List<TMP_Text> _listToTranslate;
    
    private void OnEnable() { GameManager.ChangeLanguage += Translate; }

    private void OnDisable() { GameManager.ChangeLanguage -= Translate; }

    private void Translate()
    {
        for (int i = 0; i < _listToTranslate.Count; i++) _listToTranslate[i].text = _datas.actualLanguage.listToTranslate[i];
    }
}