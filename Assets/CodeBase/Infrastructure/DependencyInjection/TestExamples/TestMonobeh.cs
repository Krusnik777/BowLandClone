using CodeBase.Infrastructure.DependencyInjection;
using UnityEngine;

public class TestMonobeh : MonoBehaviour
{
    private Service1 service1;

    [Inject]
    public void Construct(Service1 service1)
    {
        this.service1 = service1;
    }

    private void Start()
    {
        Debug.Log(service1);
    }
}
