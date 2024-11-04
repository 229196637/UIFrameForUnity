using System.Collections.Generic;
using System.IO;
using GameFrame;
using UnityEngine;

namespace UIFramwork
{
    /// <summary>
    /// 储存所有UI信息 创建与销毁
    /// 负责管理所有的Panel
    /// </summary>
    public class UIManager
    {
        private Dictionary<UIType,GameObject> dicUI;
        GameObject parent = null;

        public UIManager()
        {
            dicUI = new Dictionary<UIType, GameObject>();
        }
        
        public void InitUiManager()
        {
            //将这里的通过名字查找进行修改
            //只需要能找到画布对象就可以了
            parent = GameObject.Find("Canvas");
        }

        public GameObject GetSingleUI(UIType type)
        {
            //GameObject parent = GameObject.Find("Canvas");

            if (!parent)
            {
                Debug.Log("Canvas is not existed");
                return null;
            }

            if (dicUI.ContainsKey(type))
            {
                return dicUI[type];
            }
            GameObject uiPrefab = Resources.Load<GameObject>(type.Path);

            
            GameObject ui = GameObject.Instantiate(uiPrefab,parent.transform);
            ui.name = type.Name;
            dicUI[type] = ui;
            return ui;
        }
        
        public void DestoryUI(UIType type)
        {
            if (dicUI.ContainsKey(type))
            {
                GameObject.Destroy(dicUI[type]);
                dicUI.Remove(type);
            }
        }
    }
}
