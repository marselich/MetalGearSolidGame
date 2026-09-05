using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    private const string LoadingScreenText = "Loading";
    private const int DotRepeatCount = 3;

    [SerializeField] private TMP_Text _loadingText;

    private Coroutine _loadingProcess;

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    private void Start()
    {
        _loadingProcess = StartCoroutine(StartProcess());
    }

    private void OnDestroy()
    {
        StopCoroutine(_loadingProcess);
    }

    private IEnumerator StartProcess()
    {
        while (true)
        {
            for (int i = 0; i <= DotRepeatCount; i++)
            {
                _loadingText.text = LoadingScreenText + string.Concat(Enumerable.Repeat(".", i)).ToString();
                yield return new WaitForSeconds(0.2f);
            }

            yield return null;
        }

    }
}