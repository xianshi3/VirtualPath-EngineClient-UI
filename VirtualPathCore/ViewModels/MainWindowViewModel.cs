using Avalonia.ReactiveUI;
using Avalonia.Threading;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using VirtualPathCore.Views;

namespace VirtualPathCore.ViewModels
{
    public class ProjectFolder
    {
        public string Name { get; set; }
        public ObservableCollection<ProjectFolder> SubFolders { get; set; }
        public ObservableCollection<string> Projects { get; }

        public ProjectFolder(string name)
        {
            Name = name;
            SubFolders = new ObservableCollection<ProjectFolder>();
        }
    }

    public class MainWindowViewModel : ReactiveObject
    {
        private ObservableCollection<string> modelList;
        private string selectedModel;
        private string selectedModelPreview;
        private ProjectFolder selectedProjectFolder;

        /// <summary>
        /// 初始化一个新的 <see cref="MainWindowViewModel"/> 实例。
        /// </summary>
        public MainWindowViewModel()
        {
            // 模拟项目文件夹结构
            ProjectFolders = new ObservableCollection<ProjectFolder>
            {
                new ProjectFolder("工程A")
                {
                    SubFolders =
                    {
                        new ProjectFolder("文件夹A1"),
                        new ProjectFolder("文件夹A2"),
                    }
                },
                new ProjectFolder("工程B")
                {
                    SubFolders =
                    {
                        new ProjectFolder("文件夹B1"),
                        new ProjectFolder("文件夹B2")
                        {
                            SubFolders =
                            {
                                new ProjectFolder("文件夹B2-a"),
                                new ProjectFolder("文件夹B2-b")
                            }
                        }
                    }
                }
            };

            // 初始化模型列表
            ModelList = new ObservableCollection<string>
            {
                "模型1",
                "模型2",
                "模型3"
            };

            SelectedModel = ModelList[0]; // 默认选中第一个模型
            UpdateModelPreview();

            // 初始化打开项目窗口的命令
            OpenCreateProjectWindowCommand = ReactiveCommand.Create(OpenCreateProjectWindow, outputScheduler: AvaloniaScheduler.Instance);
        }

        /// <summary>
        /// 获取项目文件夹列表。
        /// </summary>
        public ObservableCollection<ProjectFolder> ProjectFolders { get; } = new ObservableCollection<ProjectFolder>();

        /// <summary>
        /// 获取或设置选中项目文件夹。
        /// </summary>
        public ProjectFolder SelectedProjectFolder
        {
            get => selectedProjectFolder;
            set => this.RaiseAndSetIfChanged(ref selectedProjectFolder, value);
        }

        /// <summary>
        /// 获取或设置模型列表。
        /// </summary>
        public ObservableCollection<string> ModelList
        {
            get => modelList;
            set => this.RaiseAndSetIfChanged(ref modelList, value);
        }

        /// <summary>
        /// 获取或设置选中模型。
        /// </summary>
        public string SelectedModel
        {
            get => selectedModel;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedModel, value);
                UpdateModelPreview(); // 更新预览图
            }
        }

        /// <summary>
        /// 获取或设置选中模型的预览图路径。
        /// </summary>
        public string SelectedModelPreview
        {
            get => selectedModelPreview;
            set => this.RaiseAndSetIfChanged(ref selectedModelPreview, value);
        }

        /// <summary>
        /// 命令，用于打开新建项目窗口。
        /// </summary>
        public ReactiveCommand<Unit, Unit> OpenCreateProjectWindowCommand { get; }

        /// <summary>
        /// 打开新建项目窗口的方法。
        /// </summary>
        private void OpenCreateProjectWindow()
        {
            // 使用Dispatcher确保在UI线程上打开新窗口
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                var createProjectWindow = new CreateProjectWindow
                {
                    DataContext = new CreateProjectViewModel()
                };
                createProjectWindow.Show();
            });
        }

        /// <summary>
        /// 更新模型预览图的方法。
        /// </summary>
        private void UpdateModelPreview()
        {
            // TODO: 确认根据选中模型更新选中模型预览图的路径。
        }
    }
}
