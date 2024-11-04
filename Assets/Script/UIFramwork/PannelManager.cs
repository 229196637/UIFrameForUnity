using System.Collections.Generic;
using GameFrame;
using UnityEngine;

namespace UIFramwork
{
    /// <summary>
    /// 对外的一个类，所有进行的方法都是通过这个类进行的
    /// 
    /// </summary>
    public class PanelManager : PersistentSingletonMono<PanelManager>
    {
        private Stack<BasePanel> stackPanel;
        public UIManager UiManager{get;private set;}
        private BasePanel pannel;

        /*public PanelManager()
        {
            stackPanel = new Stack<BasePanel>();
            UiManager = new UIManager();
        }*/

        protected override void Awake()
        {
            base.Awake();
            stackPanel = new Stack<BasePanel>();
            UiManager = new UIManager();
            UiManager.InitUiManager();
        }

        /// <summary>
        /// 层级打开，不会关闭之前的UI
        /// </summary>
        /// <param name="nextPannel"></param>
        public void Push(BasePanel nextPannel)
        {
            if (stackPanel.Count>0)
            {
                pannel = stackPanel.Peek();
                pannel.OnPause();
            }
            stackPanel.Push(nextPannel);
            GameObject pannelGO = UiManager.GetSingleUI(nextPannel.UIType);
            nextPannel.Initialize(new UITool(pannelGO));
            nextPannel.OnEnter();
        }
        
        /// <summary>
        /// 退出当前的UI，打开一个新的UI
        /// </summary>
        public void Pop()
        {
            if (stackPanel.Count>0 )
            {
                BasePanel p = stackPanel.Peek();
                p.OnExit();
                UiManager.DestoryUI(p.UIType);
                stackPanel.Pop();
            }

            if (stackPanel.Count >0)
            {
                stackPanel.Peek().OnResume();
            }
        }
        
        /// <summary>
        /// 退出当前的UI之后
        /// 打开新的UI
        /// 这是覆盖打开
        /// </summary>
        /// <param name="nextPannel"></param>
        public void PopAndPush(BasePanel nextPannel)
        {
            Pop();
            Push(nextPannel);
        }
        
        /// <summary>
        /// 清除所有的UI对象
        /// 用于你想要清理掉所有的UI对象的地方
        /// </summary>
        public void ClearAllPanel()
        {
            while (stackPanel.Count>0 )
            {
                BasePanel p = stackPanel.Pop();
                UiManager.DestoryUI(p.UIType);
                p.OnExit();
            }
        }
    }
}
