using UnityEngine;
using System.Collections;
using MelonLoader;

namespace PIR_TestMod
{
    public class AssetBundleLoader : MonoBehaviour
    {
        // Путь к бандлу
        public string assetBundlePath = "AssetBundles/argemia";
        // Имя бандла
        public string assetName = "assets/resources/models/red_argemia.prefab";



        public IEnumerator Start()
        {
            // Путь к AssetBundle
            string path = System.IO.Path.Combine(Application.dataPath, assetBundlePath);

            // Загрузка AssetBundle
            var assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(path);
            yield return assetBundleCreateRequest;

            // Если загрузка успешна
            if (assetBundleCreateRequest.assetBundle != null)
            {
                // Загрузка префаба из AssetBundle
                var assetBundle = assetBundleCreateRequest.assetBundle;
                var assetLoadRequest = assetBundle.LoadAssetAsync<GameObject>(assetName);
                yield return assetLoadRequest;

                // Если префаб успешно загружен
                if (assetLoadRequest.asset != null)
                {
                    // Создание префаба на сцене
                    GameObject prefab = assetLoadRequest.asset as GameObject;

                    // Находим все объекты с тегом "Cube"
                    GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

                    // Проходим по каждому объекту "Cube"
                    foreach (GameObject cube in cubes)
                    {
                        // Удаляем все дочерние объекты
                        foreach (Transform child in cube.transform)
                        {
                            Destroy(child.gameObject);
                        }

                        // Задаём размеры и положение
                        prefab.transform.localPosition = new Vector3(cube.transform.localPosition.x, cube.transform.localPosition.y + 0.35f, cube.transform.localPosition.z);
                        prefab.transform.localScale = cube.transform.localScale * 165f;

                        // Прикрепляем новый префаб
                        Instantiate(prefab, prefab.transform.localPosition, cube.transform.rotation, cube.transform);
                    }

                    MelonLogger.Msg("Prefabs were attached to cubes successfully.");
                }

                string[] allAssetNames = assetBundle.GetAllAssetNames();
                foreach (string name in allAssetNames)
                {
                    // Отображает все доступные имена ассетов в бандле
                    MelonLogger.Msg("Asset Name: " + name);
                }

                // Выгрузка AssetBundle из памяти
                assetBundle.Unload(false);
            }
            else
            {
                MelonLogger.Msg("Failed to load AssetBundle!");
            }
        }



        public IEnumerator AddNew()
        {
            // Путь к AssetBundle
            string path = System.IO.Path.Combine(Application.dataPath, assetBundlePath);

            // Загрузка AssetBundle
            var assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(path);
            yield return assetBundleCreateRequest;

            // Если загрузка успешна
            if (assetBundleCreateRequest.assetBundle != null)
            {
                // Загрузка префаба из AssetBundle
                var assetBundle = assetBundleCreateRequest.assetBundle;
                var assetLoadRequest = assetBundle.LoadAssetAsync<GameObject>(assetName);
                yield return assetLoadRequest;

                // Если префаб успешно загружен
                if (assetLoadRequest.asset != null)
                {
                    // Создание префаба на сцене
                    GameObject prefab = assetLoadRequest.asset as GameObject;
                    // Задаём размеры и положение
                    prefab.transform.localPosition = new Vector3(prefab.transform.localPosition.x, prefab.transform.localPosition.y + 0.35f, prefab.transform.localPosition.z);
                    prefab.transform.localScale = prefab.transform.localScale * 165f;

                    Instantiate(prefab);
                    MelonLogger.Msg("Prefab was loaded successfully.");
                }

                string[] allAssetNames = assetBundle.GetAllAssetNames();
                foreach (string name in allAssetNames)
                {
                    // Отображает все доступные имена ассетов в бандле
                    MelonLogger.Msg("Asset Name: " + name);
                }

                // Выгрузка AssetBundle из памяти
                assetBundle.Unload(false);
            }
            else
            {
                MelonLogger.Msg("Failed to load AssetBundle!");
            }
        }
    }
}
