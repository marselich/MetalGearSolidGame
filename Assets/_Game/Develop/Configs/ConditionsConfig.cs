using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/ConditionsConfig", fileName = "ConditionsConfig")]
public class ConditionsConfig : ScriptableObject
{
    [field: SerializeField] public WinConditionType WinConditionType { get; private set; }
    [field: SerializeField] public DefeatConditionType DefeatConditionType { get; private set; }
}