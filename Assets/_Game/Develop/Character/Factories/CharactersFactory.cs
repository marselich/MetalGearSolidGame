using UnityEngine;

public class CharactersFactory
{
    public Character CreateCharacter(
        Character prefab,
        Vector3 spawnPosition,
        float moveSpeed,
        float rotationSpeed,
        float healthValue)
    {
        Character instance = Object.Instantiate(prefab, spawnPosition, Quaternion.identity, null);

        DirectionalMover mover = new CharacterControllerDirectionMover(instance.GetComponent<CharacterController>(), moveSpeed);
        DirectionalRotator rotator = new TransformDirectionalRotator(instance.transform, rotationSpeed);
        Health health = new Health(healthValue);

        instance.Initialize(mover, rotator, health);

        return instance;
    }
}