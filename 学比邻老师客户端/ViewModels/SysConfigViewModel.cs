using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 学比邻老师客户端.ViewModels.@base;
using 学比邻老师客户端.ViewModels.SysConfig;

namespace 学比邻老师客户端.ViewModels
{
    public class SysConfigViewModel : BaseWindowVM
    {
        #region 私有字段
        /// <summary>
        /// 基本设置viewmodel对象
        /// </summary>
        [Inject] private BaseConfigViewModel _baseConfigViewModel { get; set; }

        /// <summary>
        /// 音频设置viewmodel对象
        /// </summary>
        [Inject] private VoiceConfigViewModel _voiceConfigViewModel { get; set; }

        /// <summary>
        /// 视频设置viewmodel对象
        /// </summary>
        [Inject] private VideoConfigViewModel _videoConfigViewModel { get; set; }
        #endregion

        #region 公共属性
        /// <summary>
        /// 窗口标题
        /// </summary>
        public override string DisplayName => "乐比邻老师端-设置";

        /// <summary>
        /// 当前显示区域视图对象
        /// </summary>
        public BaseViewModel CurrentViewModel { get; set; }
        #endregion

        #region 公共方法
        /// <summary>
        /// 选择“基本设置”视图时
        /// </summary>
        public void OnBaseConfigBtn_Checked()
        {
            CurrentViewModel = _baseConfigViewModel;
        }

        /// <summary>
        /// 选择“音频设置”视图时
        /// </summary>
        public void OnVoiceConfigBtn_Checked()
        {
            CurrentViewModel = _voiceConfigViewModel;
        }

        /// <summary>
        /// 选择“视频设置”视图时
        /// </summary>
        public void OnVideoConfigBtn_Checked()
        {
            CurrentViewModel = _videoConfigViewModel;
        }

        /// <summary>
        /// view关联到viewmodel时，即初始状态
        /// </summary>
        protected override void OnViewLoaded()
        {
            base.OnViewLoaded();

            // 初始为“基本设置”视图
            CurrentViewModel = _baseConfigViewModel;
        }
        #endregion
    }
}
