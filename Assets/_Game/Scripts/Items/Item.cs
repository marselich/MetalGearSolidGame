// SpeedUpItem, HealItem, PistolItem, PistolController на игрока, ItemCollector
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract void ActivateAbilityTo(Player player);
}
