using TMPro;
using UnityEngine;

public class TextDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    public void DisplayText(string text) => _text.text = text;
}
