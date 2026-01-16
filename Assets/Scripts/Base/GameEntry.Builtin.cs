using UnityGameFramework.Runtime;
using GameEntryInternal = UnityGameFramework.Runtime.GameEntry;

/// <summary>
/// 游戏入口。
/// </summary>
public static partial class GameEntry
{
    /// <summary>
    /// 获取游戏基础组件。
    /// </summary>
    public static BaseComponent Base { get; } = GameEntryInternal.GetComponent<BaseComponent>();

    /// <summary>
    /// 获取配置组件。
    /// </summary>
    public static ConfigComponent Config { get; } = GameEntryInternal.GetComponent<ConfigComponent>();


    /// <summary>
    /// 获取数据结点组件。
    /// </summary>
    public static DataNodeComponent DataNode { get; } = GameEntryInternal.GetComponent<DataNodeComponent>();

    /// <summary>
    /// 获取数据表组件。
    /// </summary>
    public static DataTableComponent DataTable { get; } = GameEntryInternal.GetComponent<DataTableComponent>();

    /// <summary>
    /// 获取调试组件。
    /// </summary>
    public static DebuggerComponent Debugger { get; } = GameEntryInternal.GetComponent<DebuggerComponent>();

    /// <summary>
    /// 获取下载组件。
    /// </summary>
    public static DownloadComponent Download { get; } = GameEntryInternal.GetComponent<DownloadComponent>();

    /// <summary>
    /// 获取实体组件。
    /// </summary>
    public static EntityComponent Entity { get; } = GameEntryInternal.GetComponent<EntityComponent>();

    /// <summary>
    /// 获取事件组件。
    /// </summary>
    public static EventComponent Event { get; } = GameEntryInternal.GetComponent<EventComponent>();

    /// <summary>
    /// 获取文件系统组件。
    /// </summary>
    public static FileSystemComponent FileSystem { get; } = GameEntryInternal.GetComponent<FileSystemComponent>();

    /// <summary>
    /// 获取有限状态机组件。
    /// </summary>
    public static FsmComponent Fsm { get; } = GameEntryInternal.GetComponent<FsmComponent>();

    /// <summary>
    /// 获取本地化组件。
    /// </summary>
    public static LocalizationComponent Localization { get; } = GameEntryInternal.GetComponent<LocalizationComponent>();

    /// <summary>
    /// 获取网络组件。
    /// </summary>
    public static NetworkComponent Network { get; } = GameEntryInternal.GetComponent<NetworkComponent>();

    /// <summary>
    /// 获取对象池组件。
    /// </summary>
    public static ObjectPoolComponent ObjectPool { get; } = GameEntryInternal.GetComponent<ObjectPoolComponent>();

    /// <summary>
    /// 获取流程组件。
    /// </summary>
    public static ProcedureComponent Procedure { get; } = GameEntryInternal.GetComponent<ProcedureComponent>();

    /// <summary>
    /// 获取资源组件。
    /// </summary>
    public static ResourceComponent Resource { get; } = GameEntryInternal.GetComponent<ResourceComponent>();

    /// <summary>
    /// 获取场景组件。
    /// </summary>
    public static SceneComponent Scene { get; } = GameEntryInternal.GetComponent<SceneComponent>();

    /// <summary>
    /// 获取配置组件。
    /// </summary>
    public static SettingComponent Setting { get; } = GameEntryInternal.GetComponent<SettingComponent>();

    /// <summary>
    /// 获取声音组件。
    /// </summary>
    public static SoundComponent Sound { get; } = GameEntryInternal.GetComponent<SoundComponent>();

    /// <summary>
    /// 获取界面组件。
    /// </summary>
    public static UIComponent UI { get; } = GameEntryInternal.GetComponent<UIComponent>();

    /// <summary>
    /// 获取网络组件。
    /// </summary>
    public static WebRequestComponent WebRequest { get; } = GameEntryInternal.GetComponent<WebRequestComponent>();
}