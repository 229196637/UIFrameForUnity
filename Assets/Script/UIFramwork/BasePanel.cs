using UnityEngine;

namespace UIFramwork
{
    public abstract class BasePanel
    {
        public UIType UIType{get;private set;}
        
        public UITool UITool{get;private set;}
        
        public BasePanel(UIType type)
        {
            UIType = type;
        }

        public void Initialize(UITool tool)
        {
            UITool = tool;
        }
        
        
        /// <summary>
        /// 在实例化出预制体对象的时候调用
        /// </summary>
        public virtual void OnEnter()
        {
            
        }

        /// <summary>
        /// 在预制体还存在，打开一个新的UI的时候，会暂停这个UI，调用这个方法
        /// </summary>
        public virtual void OnPause()
        {
            
        }

        /// <summary>
        /// 上层的UI在关闭的时候，返回到下层UI，也就是当前的UI会调用
        /// </summary>
        public virtual void OnResume()
        {
            
        }
        
        /// <summary>
        /// 在Ui被销毁的时候调用这个方法
        /// </summary>
        public virtual void OnExit()
        {
            
        }
        
        
    }
}
