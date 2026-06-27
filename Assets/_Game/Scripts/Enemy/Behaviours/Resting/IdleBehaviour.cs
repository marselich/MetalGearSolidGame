using UnityEngine;

public class IdleBehaviour : IRestingBehaviour
{
    public void ProcessResting(Enemy enemy)
    {
        Debug.Log("стою отдыхаю");
    }
}
