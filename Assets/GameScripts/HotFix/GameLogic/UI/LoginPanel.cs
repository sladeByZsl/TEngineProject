using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TEngine;

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
            
        }
        #endregion

    }
}