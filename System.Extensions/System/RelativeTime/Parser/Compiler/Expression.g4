grammar Expression;

expression : nowPart? modifierPart? snapPart?;
nowPart : 'now';
modifierPart : operator factor? timeUnit;
operator : '+' | '-';
factor : ( '0' | '1' | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' )+;
timeUnit : 'mon' | 's' | 'm' | 'h' | 'd' | 'w' | 'q' | 'y';
snapPart : '@' snapTimeUnit modifierPart?;
snapTimeUnit: 'mon' | 's' | 'm' | 'h' | 'd' | 'w' | 'w0' | 'w1' | 'w2' | 'w3' | 'w4' | 'w5' | 'w6' | 'w7' | 'q' | 'y';

WS : [ \t\n\r]+ -> skip;