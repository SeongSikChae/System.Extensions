grammar RelativeTimeExpression;

relativeTimeExpression : nowPart? modifierPart? snapPart?;
nowPart : 'now';
modifierPart : operator factor? timeUnit;
operator : '+' | '-';
factor : DIGIT+;
DIGIT : '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9';
timeUnit : 'mon' | 's' | 'm' | 'h' | 'd' | 'w' | 'q' | 'y';
snapPart : '@' snapTimeUnit modifierPart?;
snapTimeUnit : 
    'mon' |
    'w' ( '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' )? |
    's' |
    'm' |
    'h' |
    'd' |
    'w' |
    'q' |
    'y';

WS : [ \t\n\r]+ -> skip;