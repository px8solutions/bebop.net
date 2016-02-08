foo: .EQU $ff

.ORG $4000

NOP #hello there
LDA $40 # hi there
LDA [$4000]
LDA [[$4000]]
LDA [[$4000,X]]
LDA [[$4000],X]

STA [$0A0D]

INCA
HALT

.END



