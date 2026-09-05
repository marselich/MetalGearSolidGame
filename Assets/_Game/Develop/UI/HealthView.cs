using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour, IInitializable
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Character _character;

    public void Initialize()
    {
        ChangeSliderValue();

        _character.Health.Changed += OnHealthChanged;
    }

    private void OnHealthChanged(float oldValue, float newValue)
    {
        ChangeSliderValue();
    }

    private void ChangeSliderValue() => _slider.value = _character.Health.Value / _character.Health.MaxValue;

    private void OnDestroy()
    {
        _character.Health.Changed -= OnHealthChanged;
    }
}