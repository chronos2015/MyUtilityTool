# MyUtilityTool
[![Build Status](https://github.com/chronos2015/MyUtilityTool/actions/workflows/main.yml/badge.svg)](https://github.com/chronos2015/MyUtilityTool/actions)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
![Coverage](https://img.shields.io/badge/dynamic/json?color=brightgreen&label=coverage&query=%24.lineResponse&url=https%3A%2F%2Fraw.githubusercontent.com%2Fchronos2015%2FMyUtilityTool%2Ffeature%2FPidgin%2Fcoveragereport%2Fsummary.json)

Windows環境での開発効率を最大化するために設計された、高性能なユーティリティツールです。

## 特徴
- **自動化**: 反復的な作業を自動化し、開発者の生産性を向上させます。
- **CI/CD対応**: GitHub Actionsとの統合を考慮し、品質と安定性を担保します。
- **軽量**: .NETを活用し、Windows環境で最小限のリソースで動作するように最適化されています。

## 前提条件
- .NET 8.0 SDK 以上

## インストールと実行
以下のコマンドを使用して、プロジェクトのビルドと実行を行えます。

```bash
# リポジトリのクローンとビルド
git clone https://github.com/chronos2015/MyUtilityTool.git
cd MyUtilityTool
dotnet build

# 実行
dotnet run --project MyUtilityTool/MyUtilityTool.csproj
```

## テスト
以下のコマンドでテストスイートを実行できます。

```bash
dotnet test
```

## ライセンス
本プロジェクトは [MIT License](LICENSE) の下で公開されています。
