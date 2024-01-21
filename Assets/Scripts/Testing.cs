using com.ARTillery.Core;
using UnityEngine;

public class Testing : MonoBehaviour, ITimeUpdatable
{
    [SerializeField]
    private float _speed = 5f;
    private void Start()
    {
        TimeController.Instance.AddToUpdatables(this);
    }
    public void AddToUpdatables(ITimeUpdatable updatable)
    {
        //
    }

    public void UpdateObject(float deltaTime)
    {
        transform.Translate(Vector3.right * deltaTime * _speed);
    }
}
