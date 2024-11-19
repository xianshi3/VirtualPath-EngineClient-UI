using System;
using System.IO;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using Avalonia.Threading;
using ReactiveUI;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using VirtualPathCore.Views;

namespace VirtualPathCore.ViewModels
{
    public class CreateProjectViewModel : ReactiveObject
    {
        private string projectName;
        private string projectDescription;
        private string projectPath;

        /// <summary>
        /// 获取或设置项目名称。
        /// </summary>
        public string ProjectName
        {
            get => projectName;
            set => this.RaiseAndSetIfChanged(ref projectName, value);
        }

        /// <summary>
        /// 获取或设置项目描述。
        /// </summary>
        public string ProjectDescription
        {
            get => projectDescription;
            set => this.RaiseAndSetIfChanged(ref projectDescription, value);
        }

        /// <summary>
        /// 获取或设置项目路径。
        /// </summary>
        public string ProjectPath
        {
            get => projectPath;
            set => this.RaiseAndSetIfChanged(ref projectPath, value);
        }

        /// <summary>
        /// 创建项目命令。
        /// </summary>
        public ReactiveCommand<Unit, Unit> CreateProjectCommand { get; }

        /// <summary>
        /// 选择项目路径命令。
        /// </summary>
        public ReactiveCommand<Unit, Unit> SelectProjectPathCommand { get; }

        /// <summary>
        /// CreateProjectViewModel 构造函数，初始化命令。
        /// </summary>
        public CreateProjectViewModel()
        {
            CreateProjectCommand = ReactiveCommand.Create(CreateProject, outputScheduler: AvaloniaScheduler.Instance);
            SelectProjectPathCommand = ReactiveCommand.Create(SelectProjectPath, outputScheduler: AvaloniaScheduler.Instance);
        }

        /// <summary>
        /// 创建项目的方法，负责检查输入并生成项目文件和目录。
        /// </summary>
        private async void CreateProject()
        {
            // 检查 ProjectPath 是否为空
            if (string.IsNullOrEmpty(ProjectPath))
            {
                // 显示错误信息提示用户输入项目路径
                var messageBox = MessageBoxManager.GetMessageBoxStandard("错误", "项目路径不能为空", ButtonEnum.Ok, Icon.Error);
                await messageBox.ShowAsync();
                return;
            }

            // 创建项目目录
            Directory.CreateDirectory(ProjectPath);

            // 检查并设置默认项目名称和描述
            if (string.IsNullOrEmpty(ProjectName))
            {
                ProjectName = "默认项目名称"; // 默认项目名称值
            }
            if (string.IsNullOrEmpty(ProjectDescription))
            {
                ProjectDescription = "默认项目描述"; // 默认项目描述值
            }

            // 在项目目录中创建项目配置文件
            File.WriteAllText(Path.Combine(ProjectPath, "project.config"), $"<?xml version=\"1.0\" encoding=\"utf-8\"?><Project Name=\"{ProjectName}\" Description=\"{ProjectDescription}\" Version=\"1.0\"/>");

            // 这里可以添加更多创建项目的逻辑，比如创建目录结构、文件等

            // 关闭当前窗口并返回主窗口
            var mainWindow = Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;
            mainWindow?.MainWindow?.Close();

            // 重新打开主窗口
            if (mainWindow?.MainWindow == null)
            {
                mainWindow.MainWindow = new MainWindow();
                mainWindow.MainWindow.Show();
            }
        }

        /// <summary>
        /// 选择项目保存路径的方法，允许用户选择文件夹。
        /// </summary>
        private async void SelectProjectPath()
        {
            Console.WriteLine("SelectProjectPath command triggered");
            var dialog = new OpenFolderDialog
            {
                Title = "选择项目保存路径",
                Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) // 默认目录为我的文档
            };

            var mainWindow = Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;
            var result = await dialog.ShowAsync(mainWindow?.MainWindow);
            if (result != null)
            {
                ProjectPath = result; // 更新项目路径
            }
        }
    }
}
