# Vertical Slice

Organiseras efter funktion, typ som separerade bitar av ”programtårtan”.

Kodflödet blir samlat per användarflöde och man kan börja ganska basic och bygga på med abstraktioner allt eftersom de behövs. 

Ger separerade flöden att jobba med - typ: Features -> CreateTodo eller Features -> DeleteTodo osv. 
Ändringar begränsas ofta till en slice.

Om saker ska återanvändas införs det när behov uppstår, man bygger inte som att kod ska kunna återanvändas från början.

+ Passar bra för system med mycket funktioner, många separata use cases.
+ Lätt att särskilja flöden och arbete
+ Bra om krav ändras ofta och det är viktigt med hög utvecklingshastighet
+ Kan kombineras med annan arkitektur - t ex Clean Architecture - där Vertical Slice kan användas för funktioner i kombination med lager eller ports-and-adapters i infrastrukturen.

- Risk för kodupprepning
- Krävs disciplin för att slices inte ska bli för stora eller börja dela för mycket intern logik.
