public class ControllersFactory
{
    public CharacterDirectionalMovableController CreateCharacterDirectionalMovableController(
        IDirectionalMovable movable
        ) => new CharacterDirectionalMovableController(movable);

    public AlongMovableVelocityRotatableController CreateAlongMovableVelocityRotatableController(
        IDirectionalMovable movable,
        IDirectionalRotatable rotatable
        ) => new AlongMovableVelocityRotatableController(movable, rotatable);

    public ShooterController CreateShooterController(IShooter shooter, float damage) => new ShooterController(shooter, damage);

    public CompositeController CreateMainHeroCompositeController(Character character, IShooter shooter, float damage)
        => new CompositeController(
            CreateCharacterDirectionalMovableController(character),
            CreateAlongMovableVelocityRotatableController(character, character),
            CreateShooterController(shooter, damage)
            );

    public CompositeController CreateEnemyCompositeController(Character enemy, float timeToChangeDirection)
        => new CompositeController(
            new RandomAIDirectionalMovableController(enemy, timeToChangeDirection),
            CreateAlongMovableVelocityRotatableController(enemy, enemy)
            );
}