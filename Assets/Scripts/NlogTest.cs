using Microsoft.MixedReality.Toolkit.UI;
using NLog;
using UnityEngine;

namespace BirchmeierGame.NLogTest
{
    public class NlogTest : MonoBehaviour
    {
        private NLog.Logger logger = LogManager.GetCurrentClassLogger();
        public Interactable DebugButton;
        public Interactable InfoButton;
        public Interactable WarnButton;
        public Interactable ErrorButton;
        // Start is called before the first frame update
        void Start()
        {
            DebugButton.OnClick.AddListener(OnDebugClicked);
            InfoButton.OnClick.AddListener(OnInfoClicked);
            WarnButton.OnClick.AddListener(OnWarnClicked);
            ErrorButton.OnClick.AddListener(OnErrorClicked);
        }

        private void OnErrorClicked()
        {
            logger.Error($"This is an error");
        }

        private void OnWarnClicked()
        {
            logger.Warn($"This is a warn");
        }

        private void OnInfoClicked()
        {

            logger.Info($"This is an info");
        }

        private void OnDebugClicked()
        {
            logger.Debug($"This is a debug");
        }
    }
}