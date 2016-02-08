foo: .EQU $ff

.ORG

NOP #hello there
LDA $40 # hi there
LDA [$4000]
LDA [[$4000]]
LDA [[$4000,X]]
LDA [[$4000],X]

INCA
HALT

.END



