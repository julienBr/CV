using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private AppDatas _datas;
    [SerializeField] private TextMeshProUGUI _textComponent;
    [SerializeField] private float _textSpeed;
    [SerializeField] private Player _player;
    
    private Animator _animator;

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
        if (_datas.actualLanguage.index < _datas.actualLanguage.sentences.Length -1)
        {
            _datas.actualLanguage.index++;
            _textComponent.text = string.Empty;
            StartCoroutine(TypeSentence());
        }
        else StartCoroutine(FadeOut());
    }

    private IEnumerator TypeSentence()
    {
        if(_datas.actualLanguage.index == 0) yield return new WaitForSeconds(1.1f);
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