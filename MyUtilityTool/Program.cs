using System;
using System.IO;
using Pidgin;
using Scriban; // NuGetから追加
using static Pidgin.Parser;

public class Program
{
    // Pidginのパーサ定義
    private static readonly Parser<char, int> Number = DecimalNum;
    private static readonly Parser<char, char> Plus = Char('+').Between(SkipWhitespaces);
    private static readonly Parser<char, int> AdditionParser = Map(
        (left, right) => left + right, Number, Plus.Then(Number)
    );

    // ★ Scribanのテンプレート定義
    // {{ model.変数名 }} でデータを埋め込める。if文やforループも使えます。
    private static readonly string ReportTemplateText = """
        =====================================
        【解析レポート】 
        =====================================
        入力された数式 : {{ model.formula }}
        計算結果       : {{ model.result }}
        ステータス     : {{ if model.result >= 100 }}[要確認] 値が大きすぎます{{ else }}正常{{ end }}
        =====================================
        """;

    // ユニットテスト可能なコアロジック
    public static void RunTransform(TextReader inputReader, TextWriter outputWriter)
    {
        string? line = inputReader.ReadLine();
        if (line == null) return;

        // 1. パースを実行
        Result<char, int> result = AdditionParser.Parse(line);

        if (result.Success)
        {
            // 2. テンプレートに渡す匿名オブジェクト（データ）を用意
            var data = new { Formula = line, Result = result.Value };

            // 3. Scribanでレンダリング
            var template = Template.Parse(ReportTemplateText);
            // 匿名オブジェクトを渡すときは、第2引数（型チェック等の設定）に model という名前をバインドする
            string renderedText = template.Render(new { model = data });

            // 4. 出力
            outputWriter.Write(renderedText);
        }
        else
        {
            outputWriter.WriteLine($"【エラー】解析に失敗しました: {result.Error}");
        }
    }

    public static void Main(string[] args)
    {
        using TextReader reader = (args.Length > 0 && File.Exists(args[0]))
            ? new StreamReader(args[0])
            : Console.In;

        using TextWriter writer = Console.Out;

        RunTransform(reader, writer);
    }
}