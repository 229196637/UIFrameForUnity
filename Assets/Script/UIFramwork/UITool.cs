using System.IO;
using UnityEngine;

namespace UIFramwork
{
    /// <summary>
    /// UITool是BasePanel下，用于和Unity交互的工具类
    /// 这里包括了获取Component这个重要的功能
    /// </summary>
    public class UITool
    {
        GameObject activeObject;

        public UITool(GameObject pannel)
        {
            activeObject = pannel;
        }
        
        /// <summary>
        /// 获取或者添加组件
        /// 这个方法是这个预制体的最高的父级的对象
        /// </summary>
        /// <typeparam name="T">返回父亲的Componet</typeparam>
        /// <returns></returns>
        public T GetOrAddComponent<T>() where T : Component
        {
            if (activeObject.GetComponent<T>() == null)
            {
                activeObject.AddComponent<T>();
            }
            
            return activeObject.GetComponent<T>();
        }
        
        /// <summary>
        /// 通过名字获取所有的子集对象
        /// 这个获取的范围是这个UI预制体里面，如果超出了UI预制体，是不会检测到的
        /// </summary>
        /// <param name="name">你想要查找的名字</param>
        /// <returns></returns>

        public GameObject FindChildGameObject(string name)
        {
            Transform[] trans = activeObject.GetComponentsInChildren<Transform>(true);

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
        /// <summary>
        /// 这个是如果对应所有子对象中的Component不存在，则会进行添加，后返回
        /// 但是如果目标名字的对象不存在，则会返回null
        /// </summary>
        /// <param name="name">你想要查找的名字</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>

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
        
        /// <summary>
        /// 这个使用创建Item的，什么是Item呢？
        /// Item就是你在玩肉鸽等类型的游戏的时候，涉及到词条
        /// </summary>
        /// <param name="type"></param>
        /// <param name="transform"></param>
        /// <returns></returns>
        public GameObject CreateSingleItem(UIType type,Transform transform)
        {
            //GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(type.Path),transform);
            GameObject uiPrefab = Resources.Load<GameObject>(type.Path);
            
            GameObject ui = GameObject.Instantiate(uiPrefab,transform);
            ui.name =type.Name;
            return ui;
        }
        
        /// <summary>
        /// 删除所有的子对象
        /// </summary>
        /// <param name="name"></param>
        public void DeleteAllChildren(string name)
        {
            GameObject parent = FindChildGameObject(name);
            // 获取所有子对象的数量
            int childCount = parent.transform.childCount;

            // 使用一个循环来遍历所有子对象并删除它们
            for (int i = childCount - 1; i >= 0; i--)
            {
                GameObject child = parent.transform.GetChild(i).gameObject;
                GameObject.Destroy(child);
            }
        }
        
    }
    
}
