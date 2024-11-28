# RealtimeAI 桌面助手

一个基于实时对话的智能桌面助手项目，通过语音+视觉多模态交互，实现自然、高效的人机交互体验。

演示视频:
[![演示视频](https://github.com/user-attachments/assets/66459cef-8e86-497b-ad8f-78fca30f5443)](https://youtu.be/H4BEF-VSDXQ)

## 环境要求

1. 安装 .NET 9 (`dotnet --version` 可以确认版本)
2. 安装 Ollama (https://ollama.com/download)
3. 拉取所需模型:
```bash
ollama pull llama2
```

### Ollama 配置:

1. 确保 Ollama 服务运行在默认端口 (11434)
2. 验证 Ollama API 是否正常工作:
```bash
curl http://localhost:11434/api/chat/completions \
    -H "Content-Type: application/json" \
    -d '{
        "model": "llama2",
        "messages": [
            {
                "role": "user",
                "content": "你好"
            }
        ]
    }'
```

## 运行方式

从 Visual Studio 或 VS Code 使用 Ctrl+F5 运行,或在控制台中执行:

```bash
cd RealtimeFormApp
dotnet run
```

这将自动在 http://localhost:5174/ 打开浏览器。浏览器会请求麦克风访问权限,请确保允许。

## 语音输出设置

如果你不想听到语音输出(因为可以更快地阅读文本),但如果你想尝试听到音频输出,请在 `RealtimeConversationManager.cs` 中注释掉这行:

```cs
ContentModalities = ConversationContentModalities.Text,
```

现在它将恢复为默认模式(文本+语音)。

如果你想要更多的双向对话,考虑更新 `RealtimeConversationManager.cs` 中的提示,删除短语 `Do not reply to them unless they explicitly ask for your input; just listen`。这样它会更倾向于详细回应而不是仅回复"OK"。

## 故障排除

如果点击麦克风后显示"Connecting..."但没有显示"Connected",可能是遇到了速率限制。`gpt-4o-realtime-preview` 目前每分钟最多允许10个连接,或每6秒一个连接。所以如果你刚刚重新加载页面,请等待几秒钟再重试。

## 工作原理

在 `CarDescriptor.cs` 中定义了一个对象模型。这个模型以 JSON schema 的形式在提示中呈现，这样 AI 就知道允许什么样的数据和编辑。

AI 被告知有一个 JSON 文档需要根据用户的要求进行更新。这个 JSON 文档与 UI 双向绑定，所以 AI 做的任何更改都会显示在 UI 中，用户做的任何更改也会对 AI 可见。

注意 `RealtimeConversationManager` 是泛型类型的，所以同样的逻辑也适用于编辑其他数据模式。

## 技术栈

- Blazor WebAssembly
- SignalR
- .NET 8
- Ollama (本地 LLM)
- YOLO/MediaPipe (视觉识别)
- Web Speech API (语音识别)
- Three.js/Babylon.js (3D渲染)
