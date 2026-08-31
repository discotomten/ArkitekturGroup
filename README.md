# Vertical Slice

## Vilket problem försöker arkitekturen lösa?
Underlättar för system med mycket funktioner, många separata use cases. Försöker särskilja flöden och på lätt sätt hantera om krav ändras. Kan hantera hög utvecklingshastighet.

## Vilka är de huvudsakliga komponenterna i den här arkitekturen?
Skapar en komponent utifrån en feature, finns inga definitiva/obligatoriska komponenter. Varje funktion organiseras som en "slice" där all kod som rör ett specific use case samlas. T ex (i fallet TodoApp):

Features --> Todos --> UpdateTodo:
- Endpoint.cs
- UpdateTodoRequest.cs
- Handler.cs
- Validator.cs

## Vilket ansvar har varje komponent?
**Slicen** samlar all kod för ett specifik use case
**Endpointen** tar emot HTTP-anrop och return HTTP-svar
**Request**(el likn) beskriver indata
**Handler** utför logiken för use case
**Validator** kontrollerar att indata är giltig (i mindre projekt kan logiken läggas direkt i endpoint/handler)
**Response/DTO** bestämmer vilken data som skickas in/ut
**Domain** innehåller domänmodeller och regler (t ex TodoItem)
**Infrastructure** hanterar tekniska detaljer och externa beroenden (t ex databas)
**Cross-cutting services** hanterar gemensamma tekniska funktioner (t ex loggning).

## Samspelar denna arkitektur extra bra med ett eller flera designmönster?
Funkar nog bra med mycket! Vi har t ex använt DI. 
Kan också kombineras med annan arkitektur enl the Internets, t ex i kombo med Clean Architecture (VS kan användas för funktioner i kombination med lager eller ports-and-adapters i infrastrukturen.)

## Hur flödar data genom systemet? Från ett klick eller en HTTP-request till dataförändring och att det syns igen på skärmen, vilka steg tar koden?

1. Klick i webbläsaren
2. JS - event handler
3. fetch() anrop
4. HTTP-request till ASP.NET Core
5. Endpoint
6. Handler anropas (om finns - hanterar logik)
7. TodoStore (här finns lista för lagring av data)
8. Data läggs till/uppdateras
9. HTTP-response tillbaka
10. JS tar emot response
11. DOM uppdateras
12. Ändring syns på skärmen

## Vilka saker blir svårare med denna arkitektur?
- Kodupprepningsrisk deluxe!
- Krävs disciplin för att slices inte ska bli för stora eller börja dela för mycket intern logik.

## Tänk tillbaka på något eller några av de största projekten ni arbetat med. Hur hade det blivit om denna arkitektur hade använts där?
Ja, det tror vi! Mer av ett "hela-vägen-perspektiv", lätt att bygga på allteftersom nya behov uppstår.