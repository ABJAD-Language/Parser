using ABJAD.ParseEngine.Expressions;
using ABJAD.ParseEngine.Shared;
using Ardalis.GuardClauses;

namespace ABJAD.ParseEngine.Statements;

public class ParsePrintStatementStrategy : ParseStatementStrategy
{
    private readonly ITokenConsumer tokenConsumer;
    private readonly ExpressionParser expressionParser;

    public ParsePrintStatementStrategy(ITokenConsumer tokenConsumer, ExpressionParser expressionParser)
    {
        Guard.Against.Null(tokenConsumer);
        Guard.Against.Null(expressionParser);
        this.expressionParser = expressionParser;
        this.tokenConsumer = tokenConsumer;
    }

    public Statement Parse()
    {
        tokenConsumer.Consume(TokenType.PRINT);
        tokenConsumer.Consume(TokenType.OPEN_PAREN);

        var expression = expressionParser.Parse();

        tokenConsumer.Consume(TokenType.CLOSE_PAREN);
        tokenConsumer.Consume(TokenType.SEMICOLON);

        return new PrintStatement(expression);
    }
}