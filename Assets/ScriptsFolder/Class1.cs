using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PIR_TestMod
{
    public class Class1 : MelonMod
    {
        private GameObject assetBundleLoaderObject; // Ссылка на объект AssetBundleLoader
        private AssetBundleLoader assetBundleLoader; // Ссылка на компонент AssetBundleLoader

        public override void OnApplicationStart()
        {
            SceneManager.sceneLoaded += OnSceneLoaded; // Подписываемся на событие загрузки сцены
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // Создаем новый игровой объект на сцене
            assetBundleLoaderObject = new GameObject("AssetBundleLoader");
            // Присоединяем компонент AssetBundleLoader к созданному объекту
            assetBundleLoader = assetBundleLoaderObject.AddComponent<AssetBundleLoader>();
        }

        public override void OnUpdate()
        {
            // Проверяем, была ли нажата кнопка K
            if (Input.GetKeyDown(KeyCode.K))
            {
                // Вызываем метод Start из AssetBundleLoader
                if (assetBundleLoader != null)
                {
                    
                    assetBundleLoader.StartCoroutine(assetBundleLoader.AddNew());
                }
            }
        }
    }
}
