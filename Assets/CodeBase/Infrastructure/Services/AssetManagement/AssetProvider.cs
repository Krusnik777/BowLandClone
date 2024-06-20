using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CodeBase.Infrastructure.Services
{
    public class AssetProvider : IAssetProvider
    {
        private Dictionary<string, AsyncOperationHandle> cacheHandle = new Dictionary<string, AsyncOperationHandle>();
        private Dictionary<string, List<AsyncOperationHandle>> allHandles = new Dictionary<string, List<AsyncOperationHandle>>();

        public T GetPrefab<T>(string prefabPath) where T : Object
        {
            return Resources.Load<T>(prefabPath);
        }

        public T Instantiate<T>(string prefabPath) where T : Object
        {
            T obj = Resources.Load<T>(prefabPath);

            return GameObject.Instantiate(obj);
        }

        public async Task<TType> Load<TType>(AssetReference assetReference) where TType : class
        {
            return await LoadAsset<TType>(assetReference.AssetGUID, assetReference);

            /*
            if (cacheHandle.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle handle))
            {
                return handle.Result as TType;
            }

            AsyncOperationHandle<TType> loadOperationHandle = Addressables.LoadAssetAsync<TType>(assetReference);

            loadOperationHandle.Completed += (h) =>
            {
                cacheHandle[assetReference.AssetGUID] = h;
            };

            AddHandle(assetReference.AssetGUID, loadOperationHandle);

            return await loadOperationHandle.Task;
            */
        }

        public async Task<TType> Load<TType>(string address) where TType : class
        {
            return await LoadAsset<TType>(address);

            /*
            if (cacheHandle.TryGetValue(address, out AsyncOperationHandle handle))
            {
                return handle.Result as TType;
            }

            AsyncOperationHandle<TType> loadOperationHandle = Addressables.LoadAssetAsync<TType>(address);

            loadOperationHandle.Completed += (h) =>
            {
                cacheHandle[address] = h;
            };

            AddHandle(address, loadOperationHandle);

            return await loadOperationHandle.Task;*/
        }

        public void Cleanup()
        {
            foreach (var asyncOperationHandles in allHandles.Values)
            {
                foreach(var handle in asyncOperationHandles)
                {
                    Addressables.Release(handle);
                }
            }

            allHandles.Clear();
            cacheHandle.Clear();
        }

        private async Task<TType> LoadAsset<TType>(string key, object keyObject = null) where TType : class
        {
            if (cacheHandle.TryGetValue(key, out AsyncOperationHandle handle))
            {
                return handle.Result as TType;
            }

            return await GetAsyncOperationHandle<TType>(key, keyObject).Task;
        }

        private AsyncOperationHandle<TType> GetAsyncOperationHandle<TType>(string key, object keyObject = null) where TType : class
        {
            AsyncOperationHandle<TType> loadOperationHandle = Addressables.LoadAssetAsync<TType>(keyObject ?? key);

            loadOperationHandle.Completed += (h) =>
            {
                cacheHandle[key] = h;
            };

            AddHandle(key, loadOperationHandle);

            return loadOperationHandle;
        }

        private void AddHandle<TType>(string assetGUID, AsyncOperationHandle<TType> operationHandle) where TType : class
        {
            if (!allHandles.TryGetValue(assetGUID, out List<AsyncOperationHandle> handleList))
            {
                handleList = new List<AsyncOperationHandle>();
                allHandles[assetGUID] = handleList;
            }

            handleList.Add(operationHandle);
        }

    }
}
