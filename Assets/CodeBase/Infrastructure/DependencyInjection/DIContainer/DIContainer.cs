using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace CodeBase.Infrastructure.DependencyInjection
{
    public class DIContainer : IService
    {
        private readonly Dictionary<Type, IService> services = new Dictionary<Type, IService>();

        #region Registration

        public void RegisterSingle<TypeService>()
            where TypeService : class, IService
        {
            services.Add(typeof(TypeService), (IService)CreateImplementation(typeof(TypeService)));
        }

        public void RegisterSingle<TypeService>(TypeService implementation)
            where TypeService : class, IService
        {
            services.Add(typeof(TypeService), implementation);
        }

        public void RegisterSingle<TypeService, TImplementation>()
            where TypeService : class, IService
            where TImplementation : class, IService
        {
            services.Add(typeof(TypeService), (IService)CreateImplementation(typeof(TImplementation)));
        }

        public void UnregisterSingle<TypeService>()
            where TypeService : class, IService
        {
            services.Remove(typeof(TypeService));
        }

        private object GetService(Type type)
        {
            if (services.ContainsKey(type)) return services[type];
            else return null;
        }

        private object CreateImplementation(Type type)
        {
            ConstructorInfo constructorInfo = type.GetConstructors()[0];

            ParameterInfo[] parameterInfos = constructorInfo.GetParameters();

            object[] parameters = new object[parameterInfos.Length];

            for (int i = 0; i < parameterInfos.Length; i++)
            {
                parameters[i] = GetService(parameterInfos[i].ParameterType);

                if (parameters[i] == null)
                {
                    Debug.LogError("Dependency for Service wasn't implemented");
                }
            }

            return Activator.CreateInstance(type, parameters);
        }

        #endregion

        #region MonoInject

        public void InjectToMonoBehaviour(MonoBehaviour monoBehaviour)
        {
            MethodInfo[] allMethods = monoBehaviour.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            for (int i = 0; i < allMethods.Length; i++)
            {
                object[] attributes = allMethods[i].GetCustomAttributes(false);

                for (int j = 0; j < attributes.Length; j++)
                {
                    if (attributes[j] is InjectAttribute)
                    {
                        allMethods[i].Invoke(monoBehaviour, GetAllServicesToInject(allMethods[i]));
                    }
                }
            }
        }

        public void InjectToGameObject(GameObject gameObject)
        {
            MonoBehaviour[] monoBehaviours = gameObject.GetComponents<MonoBehaviour>();

            for (int i = 0; i < monoBehaviours.Length; i++)
            {
                InjectToMonoBehaviour(monoBehaviours[i]);
            }
        }

        public void InjectToAllMonoBehaviours()
        {
            MonoBehaviour[] monoBehaviours = GameObject.FindObjectsOfType<MonoBehaviour>(true);

            for (int i = 0; i < monoBehaviours.Length; i++)
            {
                InjectToMonoBehaviour(monoBehaviours[i]);
            }
        }

        private object[] GetAllServicesToInject(MethodInfo methodInfo)
        {
            ParameterInfo[] parameterInfos = methodInfo.GetParameters();

            object[] parameters = new object[parameterInfos.Length];

            for (int i = 0; i < parameterInfos.Length; i++)
            {
                IService objToInject;
                services.TryGetValue(parameterInfos[i].ParameterType, out objToInject);

                if (objToInject == null)
                {
                    Debug.LogError("Dependency for MonoBehaviour Service wasn't created");
                }

                parameters[i] = objToInject;
            }

            return parameters;
        }

        #endregion

        #region Instantiate

        public GameObject Instantiate(GameObject gameObject)
        {
            GameObject newObj = GameObject.Instantiate(gameObject);

            InjectToGameObject(newObj);

            return newObj;
        }

        #endregion
    }
}
