using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AppDatas _datas;
    [SerializeField] private TMP_Text _textComponent;
    [SerializeField] private float _textSpeed;
    [SerializeField] private Player _player;
    
    private Animator _animator;
    private bool isRetyped;

    private void OnEnable() { GameManager.ChangeLanguage += RetypeSentence; }

    private void OnDisable() { GameManager.ChangeLanguage -= RetypeSentence; }
    
    private void Start()
    {
        _datas.actualLanguage.index = 0;
        _animator = GetComponent<Animator>();
        _textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        _player.enabled = false;
        foreach (Language language in _datas.languageList) language.index = _datas.actualLanguage.index;
    }

    private void StartDialogue()
    {
        StartCoroutine(TypeSentence());
    }

    private void NextSentence()
    {
        if (_datas.actualLanguage.index < _datas.actualLanguage.sentences.Count - 1)
        {
            _datas.actualLanguage.index++;
            _textComponent.text = string.Empty;
            StartCoroutine(TypeSentence());
        }
        else StartCoroutine(FadeOut());
    }

    private IEnumerator TypeSentence()
    {
        if (_datas.actualLanguage.index == 0)
        {
            if (!isRetyped) yield return new WaitForSeconds(1.1f);
            else yield return null;
        }
        foreach (char c in _datas.actualLanguage.sentences[_datas.actualLanguage.index])
        {
            _textComponent.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }
    
    private IEnumerator FadeOut()
    {
        _animator.SetTrigger("Out");
        yield return new WaitForSeconds(0.6f);
        _player.enabled = true;
        gameObject.SetActive(false);
    }

    private void RetypeSentence()
    {
        StopAllCoroutines();
        isRetyped = true;
        _textComponent.text = string.Empty;
        StartCoroutine(TypeSentence());
        isRetyped = false;
    }
    
    public void ContinueButton()
    {
        if (_textComponent.text == _datas.actualLanguage.sentences[_datas.actualLanguage.index]) NextSentence();
        else
        {
            StopAllCoroutines(); 
            _textComponent.text = _datas.actualLanguage.sentences[_datas.actualLanguage.index];
        }
    }
}