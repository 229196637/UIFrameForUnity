using UnityEngine;

namespace UIFramwork
{
    public class BaseItem : MonoBehaviour
    {
        public GameObject FindChildGameObject(string name)
        {
            Transform[] trans = gameObject.GetComponentsInChildren<Transform>(true);

            foreach (var item in trans)
            {
                if (item.name == name)
                {
                    return item.gameObject;
                }
            }
            Debug.Log($"The name of {name} is not found");
            return null;
        }
        public T GetOrAddComponentInChildren<T>(string name) where T : Component
        {
            GameObject child = FindChildGameObject(name);

            if (child)
            {
                if (child.GetComponent<T>() == null)
                {
                    child.AddComponent<T>();
                }
                return child.GetComponent<T>();
            }
            return null;
        }
    }
    
}
