using System;
using ABJAD.ParseEngine.Declarations;
using ABJAD.ParseEngine.Shared;
using ABJAD.ParseEngine.Statements;
using Moq;
using Xunit;

namespace ABJAD.ParseEngine.Test.Declarations;

public class ParseClassDeclarationStrategyTest
{
    private readonly Mock<ITokenConsumer> tokenConsumer = new();
    private readonly Mock<ParseBlockStatementStrategy> blockStatementParser = new();

    public ParseClassDeclarationStrategyTest()
    {
        tokenConsumer.Setup(c => c.Consume(TokenType.ID)).Returns(new Token { Content = "className" });
        blockStatementParser.Setup(p => p.Parse()).Returns(new Mock<BlockStatement>().Object);
    }

    [Fact]
    private void ThrowsExceptionIfTokenConsumerIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new ParseClassDeclarationStrategy(null, blockStatementParser.Object));
    }

    [Fact]
    private void ThrowsExceptionIfBlockStatementParserIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new ParseClassDeclarationStrategy(tokenConsumer.Object, null));
    }

    [Fact]
    private void ConsumesClassToken()
    {
        GetStrategy().Parse();
        tokenConsumer.Verify(c => c.Consume(TokenType.CLASS));
    }

    [Fact]
    private void ConsumesNameIdInOrder()
    {
        var order = 1;
        tokenConsumer.Setup(c => c.Consume(TokenType.CLASS)).Callback(() => Assert.Equal(1, order++));
        tokenConsumer.Setup(c => c.Consume(TokenType.ID)).Returns(new Token { Content = "className" })
            .Callback(() => Assert.Equal(2, order++));

        GetStrategy().Parse();
        tokenConsumer.Verify(c => c.Consume(TokenType.CLASS));
        tokenConsumer.Verify(c => c.Consume(TokenType.ID));
    }

    [Fact]
    private void ParsesBlockStatementInOrder()
    {
        var order = 1;
        tokenConsumer.Setup(c => c.Consume(TokenType.CLASS)).Callback(() => Assert.Equal(1, order++));
        tokenConsumer.Setup(c => c.Consume(TokenType.ID)).Returns(new Token { Content = "className" })
            .Callback(() => Assert.Equal(2, order++));
        blockStatementParser.Setup(c => c.Parse()).Returns(new Mock<BlockStatement>().Object)
            .Callback(() => Assert.Equal(3, order++));

        GetStrategy().Parse();
        blockStatementParser.Verify(p => p.Parse());
    }

    [Fact]
    private void ReturnsClassDeclarationOnHappyPath()
    {
        var blockStatement = new Mock<BlockStatement>();
        blockStatementParser.Setup(p => p.Parse()).Returns(blockStatement.Object);

        tokenConsumer.Setup(c => c.Consume(TokenType.ID)).Returns(new Token { Content = "className" });

        var declaration = GetStrategy().Parse();
        Assert.True(declaration is ClassDeclaration);

        var classDeclaration = declaration as ClassDeclaration;
        Assert.Equal("className", classDeclaration.Name);
        Assert.Equal(blockStatement.Object, classDeclaration.Body);
    }

    private ParseClassDeclarationStrategy GetStrategy()
    {
        return new ParseClassDeclarationStrategy(tokenConsumer.Object, blockStatementParser.Object);
    }
}