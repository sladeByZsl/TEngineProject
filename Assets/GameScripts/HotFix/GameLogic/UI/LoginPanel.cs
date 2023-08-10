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
        private Button m_btnLogin;
        private Text m_textTitle;
        public override void ScriptGenerator()
        {
            m_btn = FindChildComponent<Button>("parent/m_btn");
            m_btnLogin = FindChildComponent<Button>("parent/m_btnLogin");
            m_textTitle = FindChildComponent<Text>("parent/m_textTitle");
            m_btn.onClick.AddListener(OnClickBtn);
            m_btnLogin.onClick.AddListener(OnClickLoginBtn);
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
        
        
        private void OnClickLoginBtn()
        {
            var skillBaseConfig = ConfigLoader.Instance.Tables.TbItem.Get(10000);
            m_textTitle.text = "aaaaaaaaaaaaa";
            Debug.LogError("登陆成功2222");
        }
        #endregion

        
      
    }
}