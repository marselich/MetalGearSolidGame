public class CharacterDiedCondition : IConditionable
{
    private Character _character;

    public CharacterDiedCondition(Character character)
    {
        _character = character;
    }

    public bool IsCompleted => _character.IsDied;

    public void Dispose() { }
}