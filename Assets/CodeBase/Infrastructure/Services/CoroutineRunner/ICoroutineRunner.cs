using CodeBase.Infrastructure.DependencyInjection;
using System.Collections;
using UnityEngine;

namespace CodeBase.Services.CoroutineRunner
{
    public interface ICoroutineRunner : IService
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
