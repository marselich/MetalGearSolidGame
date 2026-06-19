using UnityEngine;

public class HealItem : Item
{
    [SerializeField] private float _healValue;

    public override void ActivateAbilityTo(Player player)
    {
        player.Health.Add(_healValue);
    }
}
