namespace MyUtilityTool.Tests;

public class UnitTest1
{
    [Fact]
    public void 正しい計算式が渡されたとき_Scribanテンプレートを通じて出力されること()
    {
        // Arrange
        var input = new StringReader("50 + 60"); // 合計が110になるので、if文の条件に引っかかる
        var output = new StringWriter();

        // Act
        Program.RunTransform(input, output);

        // Assert
        string actual = output.ToString();
        Assert.Contains("計算結果       : 110", actual);
        Assert.Contains("[要確認] 値が大きすぎます", actual); // テンプレート内のif文が通ったか検証
    }
}
