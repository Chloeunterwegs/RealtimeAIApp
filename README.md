# RealtimeAI 桌面助手

一个基于实时对话的智能桌面助手项目，通过语音+视觉多模态交互，实现自然、高效的人机交互体验。基于 RealtimeFormApp 项目改造。

## 路线图 🗺️

- [x] 基础框架搭建
- [x] 本地 LLM 集成
- [ ] 中文语音交互
- [ ] 系统操作控制
- [ ] 屏幕内容理解
- [ ] 手势识别支持
- [ ] 3D 虚拟形象
- [ ] 工作流系统

## 环境要求

1. .NET 9 (`dotnet --version` 确认)
2. [Ollama](https://ollama.com/download)
3. 中文 LLM 模型 (推荐 Qwen 2.5)

### 模型准备

#### 方式一：在线拉取（网络通畅时）
```bash
ollama pull qwen
```

#### 方式二：离线导入
1. 下载 Qwen 2.5 模型文件
2. 导入到 Ollama：
```bash
ollama create qwen -f ./path/to/modelfile
```

### 验证配置

确保 Ollama API 正常工作：
```bash
curl http://localhost:11434/api/chat/completions \
    -H "Content-Type: application/json" \
    -d '{
        "model": "qwen",
        "messages": [
            {
                "role": "user",
                "content": "你好"
            }
        ]
    }'
```

## 快速开始

```bash
git clone https://github.com/your-username/RealtimeAI-Assistant.git
cd RealtimeAI-Assistant/RealtimeFormApp
dotnet run
```

浏览器会自动打开 http://localhost:5174/。首次使用需要允许麦克风访问权限。

## 配置说明

### 语音设置

默认仅使用文本模式。如需启用语音输出，在 `RealtimeConversationManager.cs` 中注释：
```cs
ContentModalities = ConversationContentModalities.Text,
```

### 对话模式

默认为单向指令模式。如需启用自由对话，在 `RealtimeConversationManager.cs` 中删除：
```cs
Do not reply to them unless they explicitly ask for your input; just listen
```

## 技术架构

- 前端：Blazor WebAssembly + SignalR
- AI：Ollama + Web Speech API
- 视觉：YOLO/MediaPipe
- 3D：Three.js/WebGL

## 贡献指南

欢迎提交 Issue 和 Pull Request！

## 开源协议

MIT License

## 致谢

- [RealtimeFormApp](https://github.com/original-repo) - 原始项目
- [Qwen](https://github.com/QwenLM/Qwen) - 通义千问开源模型
- [Ollama](https://github.com/ollama/ollama) - 本地 LLM 运行时
