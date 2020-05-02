grammar Showdown;

team        :   (pokemon NEWLINE?)+ EOF;

pokemon     :   ((nickname '(' name ')') | name) ('(' sex ')')? item? NEWLINE
                'Ability' COLON ability NEWLINE
                ('Level' COLON NUMBER NEWLINE)?
                ('Shiny' COLON shiny NEWLINE)?
                ('Happiness' COLON happiness NEWLINE)?
                (evs NEWLINE)?
                (nature 'Nature' NEWLINE)?
                (ivs NEWLINE)?
                moves;

nickname    :   WORD;

name        :   WORD;

sex         :   'M' | 'F';

item        :   '@'? WORD+;

ability     :   WORD+;

shiny       :   'Yes';

happiness   :   NUMBER;

evs         :   'EVs' COLON stats;

stats       :   (stat '/'?)+;

stat        :   NUMBER (HP | ATK | DEF | SP_ATK | SP_DEF | SPE);

nature      :   WORD;

ivs         :   'IVs' COLON stats;

moves       :   ('-' move NEWLINE)+;

move        :   WORD+;

fragment LOWERCASE      :   [a-z];
fragment UPPERCASE      :   [A-Z];
fragment DIGIT          :   [0-9];

HP                      :   'HP';
ATK                     :   'Atk';
DEF                     :   'Def';
SP_ATK                  :   'SpA';
SP_DEF                  :   'SpD';
SPE                     :   'Spe';
COLON                   :   ':' ;
NEWLINE                 :   '\r' '\n' | '\n' | '\r' ;
NUMBER                  :   DIGIT+;
WORD                    :   (LOWERCASE | UPPERCASE | '-' | '\'' | '[' | ']')+ ;
WHITESPACE              :   ' ' -> skip;
ANY                     :   . ;
