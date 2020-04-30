grammar Showdown;

team        :   (pokemon NEWLINE?)+ EOF;

pokemon     :   ((nickname '(' name ')') | name) ('(' sex ')')? item? NEWLINE
                'Ability' COLON ability NEWLINE
                ('Level' COLON NUMBER NEWLINE)?
                ('Shiny' COLON shiny NEWLINE)?
                ('Happiness' COLON happyness NEWLINE)?
                ('EVs' COLON stat NEWLINE)?
                (nature 'Nature' NEWLINE)?
                ('IVs' COLON stat NEWLINE)?
                ('-' move NEWLINE)+;

nickname    :   WORD;

name        :   WORD;

sex         :   'M' | 'F';

item        :   '@'? WORD+;

ability     :   WORD+;

shiny       :   'Yes';

happyness   :   NUMBER;

stat        :   (NUMBER ('HP' | 'Atk' | 'Def' | 'SpA' | 'SpD' | 'Spe') '/'?)+;

nature      :   WORD;

move        :   WORD+;

fragment LOWERCASE      :   [a-z];
fragment UPPERCASE      :   [A-Z] ;
fragment DIGIT          :   '0'..'9' ;

COLON                   :   ':' ;
NEWLINE                 :   '\r' '\n' | '\n' | '\r' ;
NUMBER                  :   DIGIT+;
WORD                    :   (LOWERCASE | UPPERCASE | '-' | '\'' | '[' | ']')+ ;
WHITESPACE              :   ' ' -> skip;
ANY                     :   . ;
