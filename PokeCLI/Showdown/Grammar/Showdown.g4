grammar Showdown;

team        :   (pokemon NEWLINE?)+ EOF;

pokemon     :   ((nickname '(' specie ')') | specie) ('(' sex ')')? ('@' item)? NEWLINE
                'Ability' COLON ability NEWLINE
                ('Level' COLON level NEWLINE)?
                ('Shiny' COLON shiny NEWLINE)?
                ('Happiness' COLON happiness NEWLINE)?
                (evs NEWLINE)?
                (nature 'Nature' NEWLINE)?
                (ivs NEWLINE)?
                moves;

nickname    :   WORD+;

specie      :   WORD+;

sex         :   'M' | 'F';

item        :   WORD+;

ability     :   WORD+;

level       :   NUMBER;

shiny       :   'Yes';

happiness   :   NUMBER;

evs         :   'EVs' COLON stats;

stats       :   (stat '/'?)+;

stat        :   NUMBER (HP | ATK | DEF | SP_ATK | SP_DEF | SPE);

nature      :   WORD;

ivs         :   'IVs' COLON stats;

moves       :   (DASH move NEWLINE)+;

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
DASH                    :   '-' ;
WORD                    :   (LOWERCASE | UPPERCASE | DIGIT | '-' | '\'' | '[' | ']')+ ;
WHITESPACE              :   ' ' -> channel(HIDDEN);
ANY                     :   . ;
