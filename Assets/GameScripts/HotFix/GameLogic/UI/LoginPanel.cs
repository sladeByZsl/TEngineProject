using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TEngine;
using YooAsset;

namespace GameLogic
{
    [Window(UILayer.UI)]
    class LoginPanel : UIWindow
    {
        #region 脚本工具生成的代码
        private Button m_btn;
        public override void ScriptGenerator()
        {
            m_btn = FindChildComponent<Button>("parent/m_btn");
            m_btn.onClick.AddListener(OnClickBtn);
        }
        #endregion

        #region 事件
        private void OnClickBtn()
        {
            Log.Info("click btn");
            string sceneName = "game";
            GameModule.Resource.LoadSceneAsync(sceneName);
            
            var operation = GameModule.Resource.LoadSceneAsync(sceneName);
            operation.Completed += Operation_Completed;
        }

        private void Operation_Completed(SceneOperationHandle obj)
        {
            Debug.LogError("加载成功");
            GameModule.UI.CloseWindow<LoginPanel>();
        }
        
        #endregion

        
      
    }
}