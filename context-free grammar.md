    program                 →   binding_list
                            |   ε ;
    
    binding_list            →   binding_list binding
                            |   binding ;
    
    binding                 →   statement
                            |   declaration ;
    
    statement               →   expr_stmt
                            |   if_stmt
                            |   while_stmt
                            |   for_stmt
                            |   block_stmt
                            |   return_stmt
                            |   assignment_stmt 
                            |   print_stmt
                            |   comment_stmt;
    
    declaration             →   function_declaration
                            |   constructor_declaration
                            |   const_declaration
                            |   variable_declaration
                            |   class_declaration ;
    
    expr_stmt               →   expression SEMICOLON ;
    
    if_stmt                 →   if_clause
                            |   if_clause else_if_clause else_clause
                            |   if_clause else_clause ;
    
    while_stmt              →   WHILE OPEN_PAREN expression CLOSE_PAREN statement ;
    
    for_stmt                →   FOR OPEN_PAREN declaration expression SEMICOLON expression CLOSE_PAREN block_stmt ;
    
    block_stmt              →   OPEN_BRACE binding_list CLOSE_BRACE ;
    
    return_stmt             →   RETURN expression SEMICOLON ;
    
    assignment_stmt         →   ID EQUAL expression SEMICOLON ;
    
    print_stmt              →   PRINT OPEN_PAREN expression CLOSE_PAREN SEMICOLON ;
    
    parameter_list          →   expr_list
                            |   ε ;
    
    function_declaration    →   FUNC ID OPEN_PAREN parameter_list CLOSE_PAREN block_stmt ;

    constructor_declaration →   CONSTRUCTOR OPEN_PAREN parameter_list CLOSE_PAREN block_stmt ;

    const_declaration       →   CONST type ID EQUAL expression SEMICOLON ;

    variable_declaration    →   VAR type ID SEMICOLON
                            |   VAR type ID EQUAL expression SEMICOLON ;
    
    class_declaration       →   CLASS ID block_stmt ;
    
    type                    →   STRING
                            |   NUMBER
                            |   BOOL
                            |   ID ;
    
    if_clause               →   IF OPEN_PAREN expression CLOSE_PAREN statement ;
    
    else_if_clause          →   ELSE if_clause ;
    
    else_clause             →   ELSE statement ;
    
    expression              →   call_expr
                            |   instance_field_expr
                            |   instant_expr
                            |   oper_expr
                            |   to_str_expr
                            |   to_number_expr
                            |   to_bool_expr
                            |   type_expr
                            |   primitive 
                            |   OPEN_PAREN expression CLOSE_PAREN ;
    
    expr_list               →   expr_list COMMA expression
                            |   expression ;
    
    call_expr               →   ID DOT call_expr
                            |   ID OPEN_PAREN parameter_list CLOSE_PAREN SEMICOLON ;

    instance_field_expr     →   ID DOT instance_field_expr
                            |   ID DOT ID
    
    instant_expr            →   NEW ID OPEN_PAREN parameter_List CLOSE_PAREN ;
    
    to_str_expr             →   STRING OPEN_PAREN expression CLOSE_PAREN SEMICOLON ;
    
    to_number_expr          →   NUMBER OPEN_PAREN expression CLOSE_PAREN SEMICOLON ;
    
    to_bool_expr            →   BOOL OPEN_PAREN expression CLOSE_PAREN SEMICOLON ;
    
    type_stmt               →   TYPEOF OPEN_PAREN expression CLOSE_PAREN SEMICOLON ;
    
    oper_expr               →   binary_expr
                            |   unary_expr
                            |   assignment_expr ;

    binary_expr             →   expression PLUS expression
                            |   expression DASH expression
                            |   expression STAR expression
                            |   expression SLASH expression
                            |   expression AND expression
                            |   expression OR expression
                            |   expression EQUAL_EQUAL expression
                            |   expression GREATER_THAN expression
                            |   expression GREATER_EQUAL expression
                            |   expression LESS_THAN expression
                            |   expression LESS_EQUAL expression
                            |   expression BANG_EQUAL expression ;

    unary_expr              →   BANG expression
                            |   DASH expression
                            |   ID PLUS_PLUS
                            |   ID DASH_DASH
                            |   PLUS_PLUS ID
                            |   DASH_DASH ID ;
    
    assignment_expr         →   ID PLUS_EQUAL expression
                            |   ID DASH_EQUAL expression
                            |   ID STAR_EQUAL expression
                            |   ID SLASH_EQUAL expression ;
    
    primitive               →   NUMBER_CONST
                            |   STRING_CONST
                            |   TRUE
                            |   FALSE
                            |   NULL
                            |   ID ;
    