namespace Tiny11Builder.App;

/// <summary>将核心引擎的稳定英文进度文案转换为简体中文；技术标识、路径和 DISM 原始输出保持不变。</summary>
internal static class UiText
{
    private static readonly Dictionary<string, string> Exact = new(StringComparer.Ordinal)
    {
        ["Prepare"] = "准备",
        ["Copy media"] = "复制介质",
        ["Export edition"] = "导出版本",
        ["Mount"] = "挂载",
        ["Inventory"] = "清点组件",
        ["Custom servicing"] = "自定义维护",
        ["Remove apps"] = "移除应用",
        ["Optional features"] = "可选功能",
        ["Windows settings"] = "Windows 设置",
        ["Component cleanup"] = "组件清理",
        ["Advanced payloads"] = "高级负载",
        ["Core pruning"] = "Core 裁剪",
        ["Redundant data"] = "冗余数据",
        ["Commit"] = "提交",
        ["Check saved progress"] = "检查保存的进度",
        ["Setup image"] = "安装程序映像",
        ["Compress"] = "压缩",
        ["Create ISO"] = "创建 ISO",
        ["Verify output"] = "验证输出",
        ["Bundled apps"] = "捆绑应用",
        ["Optional features"] = "可选功能",
        ["Windows settings"] = "Windows 设置",
        ["Advanced / original builder"] = "高级 / 原版构建器",
        ["Not present in this image"] = "此映像中不存在",
        ["Payload already removed"] = "负载已被移除",
        ["No matching installed capability"] = "没有匹配的已安装功能包",
        ["Apply and verify offline Windows settings"] = "应用并验证离线 Windows 设置",
        ["Verify the saved Windows image"] = "验证保存的 Windows 映像",
        ["Verify the saved setup files"] = "验证保存的安装文件",
        ["Save verified progress so an interrupted build can resume"] = "保存已验证的进度，以便中断后继续构建",
        ["Save verified compressed-image progress"] = "保存已验证的压缩映像进度",
        ["Validate optimized mount"] = "验证优化挂载"
    };

    private static readonly (string English, string Chinese)[] Phrases =
    [
        ("Copying setup media, excluding the original multi-edition installation image.", "正在复制安装介质，不包含原始多版本安装映像。"),
        ("Exporting only the selected edition into a writable WIM.", "仅将所选版本导出到可写 WIM。"),
        ("Mounting the working copy. Cancellation waits for active DISM operations.", "正在挂载工作副本。取消操作会等待正在运行的 DISM 操作完成。"),
        ("Revalidating expert actions against the actual mounted image.", "正在根据实际挂载的映像重新验证高级操作。"),
        ("Applying selected package, app, capability and feature actions.", "正在应用所选程序包、应用、功能包和功能操作。"),
        ("Removing selected provisioned apps by exact identity.", "正在按精确标识移除所选预配应用。"),
        ("Detecting actual features and capabilities; unavailable choices are reported, not guessed.", "正在检测实际功能和功能包；会报告不可用选项，不进行猜测。"),
        ("Enabling .NET 3.5 from matching source media, without Windows Update.", "正在从匹配的源介质启用 .NET 3.5，不使用 Windows 更新。"),
        ("Applying selected registry settings to the offline image.", "正在将所选注册表设置应用到离线映像。"),
        ("Applying original-builder and expert payload removals to the offline copy only.", "正在仅对离线副本应用原版构建器和高级负载移除。"),
        ("Trimming Core component payloads and recovery files.", "正在裁剪 Core 组件负载和恢复文件。"),
        ("Removing offline cache, archived logs and crash reports.", "正在移除离线缓存、归档日志和崩溃报告。"),
        ("Committing the modified working image.", "正在提交修改后的工作映像。"),
        ("Exporting the final single-edition image with integrity checking.", "正在导出最终单版本映像并检查完整性。"),
        ("Creating a UEFI-bootable ISO using Microsoft's oscdimg.", "正在使用 Microsoft oscdimg 创建可通过 UEFI 启动的 ISO。"),
        ("Hashing the completed ISO and publishing it without overwriting existing files.", "正在计算已完成 ISO 的哈希，并在不覆盖现有文件的情况下发布。"),
        ("Verifying the saved image, setup files and settings before continuing.", "继续之前，正在验证保存的映像、安装文件和设置。")
    ];

    public static string Translate(string text)
    {
        if (string.IsNullOrEmpty(text)) return text;
        if (Exact.TryGetValue(text, out var translated)) return translated;
        foreach (var (english, chinese) in Phrases)
            if (text.Contains(english, StringComparison.Ordinal)) text = text.Replace(english, chinese, StringComparison.Ordinal);
        if (text.StartsWith("Remove optional feature: ", StringComparison.Ordinal)) return "移除可选功能：" + text[25..];
        if (text.StartsWith("Remove capability: ", StringComparison.Ordinal)) return "移除功能包：" + text[19..];
        if (text.StartsWith("Remove ", StringComparison.Ordinal)) return "移除 " + text[7..];
        if (text.StartsWith("Clean ", StringComparison.Ordinal)) return "清理 " + text[6..];
        return text;
    }

    public static string OptionTitle(string id, string fallback) => id switch
    {
        "copilot-app" => "Copilot 应用", "outlook" => "新版 Outlook 和邮件", "teams" => "Teams",
        "xbox" => "Xbox 和游戏覆盖层", "news-weather" => "新闻、天气和必应应用", "office-promos" => "Microsoft 365 推广",
        "clipchamp" => "Clipchamp", "solitaire" => "纸牌游戏", "phone" => "手机连接和跨设备应用",
        "feedback" => "反馈、提示和帮助", "devhome" => "开发人员主页和 Power Automate", "social" => "人脉、待办、家庭和 Skype",
        "maps" => "地图和混合现实", "media" => "媒体播放器和电影", "utilities" => "时钟、录音机和便笺",
        "quickassist" => "快速助手", "paint" => "画图、3D 查看器和 OneNote", "camera" => "相机",
        "terminal" => "Windows 终端", "oem" => "OEM 推广应用", "edge-files" => "移除 Edge 和 WebView2",
        "onedrive-files" => "移除 OneDrive 安装文件", "language-extras" => "语音、OCR 和手写负载",
        "legacy-capabilities" => "旧版附件和壁纸负载", "xps" => "XPS 打印", "workfolders" => "工作文件夹",
        "legacy" => "旧版 Internet Explorer", "recall-feature" => "Recall 可选功能",
        "ads" => "广告、推荐和赞助应用", "privacy" => "可选诊断和个性化", "copilot" => "禁用 Copilot 和 Recall",
        "widgets" => "小组件和任务栏资讯", "search" => "Web 搜索和搜索亮点", "onedrive" => "OneDrive 同步和备份提示",
        "edge" => "Edge 首次运行和推广界面", "oobe" => "安装隐私和完成设置提示", "cleanup" => "组件清理",
        "hardware-bypass" => "绕过安装硬件要求", "reserved-storage" => "禁用保留存储",
        "device-encryption" => "禁用自动设备加密", _ => fallback
    };

    public static string OptionDescription(string id, string fallback) => id switch
    {
        "copilot-app" => "移除预装的 Copilot 应用，保留共享运行库和 Shell 组件。",
        "outlook" => "移除 Outlook 以及已停用的邮件/日历应用。", "teams" => "移除个人版 Teams 客户端。",
        "xbox" => "移除 Xbox 应用和游戏栏。游戏登录和录制功能可能不可用。",
        "news-weather" => "移除打包的资讯应用，保留本地 Windows 搜索。", "office-promos" => "移除 Office 中心和 Office 推送通知推广应用。",
        "clipchamp" => "移除捆绑的视频编辑器。", "solitaire" => "移除捆绑游戏。",
        "phone" => "移除手机集成应用。跨设备功能可能停止工作。", "feedback" => "移除反馈中心、获取帮助和入门应用。",
        "devhome" => "移除开发人员主页和 Power Automate Desktop。", "social" => "移除可选的组织和通信应用。",
        "maps" => "移除已停用的地图和混合现实客户端。", "media" => "移除捆绑媒体播放应用，保留编解码器和共享框架。",
        "utilities" => "移除可选个人实用工具。", "quickassist" => "移除 Microsoft 远程协助客户端。",
        "paint" => "移除画图、3D 查看器和 OneNote；不勾选则保留。", "camera" => "移除相机应用，不移除相机驱动程序。",
        "terminal" => "移除终端，保留 PowerShell 和命令提示符。", "oem" => "移除 Intel 管理状态和 Dolby 推广应用，不移除驱动程序。",
        "edge-files" => "删除 Edge 和 WebView2 文件。依赖 WebView2 的应用可能停止工作，更新也可能重新安装 Edge。",
        "onedrive-files" => "从离线映像中移除两个体系结构对应的 OneDrive 安装程序。",
        "language-extras" => "移除映像中所有语言的可选语音、OCR 和手写功能包，保留基本语言支持。",
        "legacy-capabilities" => "移除已安装的写字板、步骤记录器、数学识别器、旧版媒体播放器和扩展壁纸。",
        "xps" => "禁用可选 XPS 打印并移除其负载。", "workfolders" => "禁用企业工作文件夹同步并移除其负载。",
        "legacy" => "禁用已停用的 Internet Explorer 可选功能。", "recall-feature" => "仅在映像向 DISM 提供 Recall 时禁用并移除其负载。",
        "ads" => "禁止消费者内容、设置建议、资源管理器推广和欢迎提示。",
        "privacy" => "保留必需的诊断数据；禁用广告 ID、个性化建议和输入收集。",
        "copilot" => "应用策略以禁用 Copilot 和 Recall；支持情况因版本而异。", "widgets" => "通过策略禁用小组件并隐藏其任务栏入口。",
        "search" => "关闭 Web 建议、云搜索和动态搜索亮点；保留本地搜索。",
        "onedrive" => "通过策略禁用 OneDrive 同步，保留其二进制文件；需要同步时请勿选择。",
        "edge" => "禁止首次运行、侧栏和推荐，保留 Edge 和 WebView2 以兼容应用。",
        "oobe" => "禁止隐私设置和登录后完成设置建议，不创建帐户或接受 EULA。",
        "cleanup" => "常规模式保留维护能力；Core 会在不可逆组件裁剪前重置更新基线。",
        "hardware-bypass" => "设置 CPU、内存、TPM、存储和安全启动绕过值。不受支持的硬件可能无法工作。",
        "reserved-storage" => "停止为更新保留磁盘空间，可能导致维护时可用空间不足。",
        "device-encryption" => "阻止自动 BitLocker 设备加密；如需默认加密请勿使用。", _ => fallback
    };
}
