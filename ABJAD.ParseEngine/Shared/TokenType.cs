namespace ABJAD.ParseEngine.Shared;

public enum TokenType
{
    /* Operations */
    AND, BANG, BANG_EQUAL, SLASH, EQUAL, EQUAL_EQUAL, GREATER_EQUAL,
    GREATER_THAN, LESS_EQUAL, LESS_THAN, DASH, DASH_DASH, MODULO, OR, PLUS, PLUS_PLUS, STAR, 

    /* Other graphic characters */
    CLOSE_BRACE, CLOSE_PAREN, COMMA, DOT, OPEN_BRACE, OPEN_PAREN, SEMICOLON, DOUBLE_QUOTE, HASH, AMPERSAND, VERTICAL_BAR,

    /* Keywords */
    BOOL, CLASS, CONST, ELSE, FALSE, FOR, FUNC, IF, NEW, NULL, NUMBER, PRINT, RETURN, STRING, TYPEOF, TRUE, WHILE, VAR,

    /* Primitives */
    NUMBER_CONST, ID, STRING_CONST,
    
    WHITE_SPACE, COMMENT
}