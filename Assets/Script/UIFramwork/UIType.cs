using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFramwork
{
    /// <summary>
    /// 记录BasePanel继承者下对应在Resource的预制体路径信息
    /// </summary>
    public class UIType
    {
        /// <summary>
        /// UI名字
        /// </summary>
        public string Name{get;private set;}
        /// <summary>
        /// 路径设置
        /// </summary>
        public string Path{get;private set;}

        public UIType(string path)
        {
            Path = path;
            Name = path.Substring(path.LastIndexOf('/')+1);
        }
    }
}
