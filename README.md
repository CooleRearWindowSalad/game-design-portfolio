# game-design-portfolio

## Brainstorming ideas for the game:
 
Idea 1 for the game: A cooking game where strange things happen at the kitchen at work
Description: you work as an allround kitchen staff member in the kitchen (ChipCafe) from ChipSoft. You have to complete some tasks for that day. What you don't know is why some weird things are happening around the workplace. Do you want to figure out why or just shake it off?
Genres: cooking, choice-based game
1. The player should do work because the game asks them to do tasks to do for that day.
2. The player should experience confusion because the game asks them to look at things that are not feeling right.
3. The player should experience cluelessness because the game asks them to not wonder why something is happening.
 
Idea 2 for the game: Trading tycoon
Description:
Genres: tycoon
1. The player should experience greed because the game asks them to find cheap items and sell them for as much profit as possible.
2. The player should experience uncertainty because the game asks them to decide when to buy, discount or re-advertise an item.
3. The player should do gambling because the game asks them to guess if something gets sold or not.
 
Idea 3 for the game: Housemate simulator where you have to steal each other's food
Description: You live in a dorm with a few housemates. One evening, you come home and you see that you don't have sufficient ingredients to make dinner.
Genres:
1. The player should experience fear because the game asks them to not get caught while stealing food in the kitchen.
2. The player should commit theft because the game asks them to steal food from housemates.
3. The player should experience distrust because the game asks them to protect food while trying to discover who the thief is.




## Idea game concept

Concept: Shared fridge:You’re a broke student who has to survive 7 nights until payday by cooking meals from your housemates’ food in the shared fridge, without getting caught.

1. Design claim
The player should feel the tension between greed and the fear of getting caught because the game asks them to cook the best possible meal each night from their housemates’ food, while each housemate notices missing food in a different way that the player has to figure out.

2. Core loop
Night: choose a recipe → take ingredients from the shelves → optionally put back a cheap replacement → cook → Morning: read the notes housemates leave on the fridge → adjust your strategy → next night.
Long loop: survive 7 nights; your score is the total value of the meals you cooked.

3. Core mechanics

Recipe choice: each night the player picks one of three recipes (simple / medium / hard). Harder meals score more but need more ingredients.
Housemate habits: each housemate notices theft differently: one counts items, one only checks expensive items, one only cares about one secret favourite. The habits are never explained; the player learns them from the morning notes.
Suspicion: a noticed theft makes that housemate more suspicious, shown through their note. A third strike means they confront you and the game is over. Leaving a housemate alone for a night lowers their suspicion → the player has to spread risk.
Cheap replacements: the player has €10 for the whole week to buy cheap store-brand replacements and put them back. This fools the housemate who only counts, but not the one who checks quality → a gamble with a scarce resource.

4. Constraint
One screen, mouse only, no movement or stealth action: all tension comes from decisions. One night takes about a minute; a full game about 10 minutes. No tutorial text: rules are learned through the notes.

Hoe het aansluit bij de eisen uit de sessies
Sessie	Waar het in het concept zit
1. MDE	Mechanic: huisgenoten merken diefstal op. Dynamic: je spreidt je diefstallen en test hoe ze reageren. Experience: spanning en hebzucht.
2. Claim, verbs, loop	Verbs: kiezen, pakken, vervangen, koken, lezen. Eén claim en een korte loop.
3. Originaliteit en constraint	Combinatie van je drie ideeën. Constraint: één scherm, geen sluipen.
4. Systeem	Geld → vervangers → minder verdenking → meer durven stelen. Regel veranderen: als verdenking nooit daalt, steelt de speler waarschijnlijk alleen nog van de huisgenoot met de laagste verdenking, en verdwijnt het spreiden van risico.
5. Betekenisvolle keuze	Elke nacht: welk recept, en van wie? Geen optie is altijd de beste.
6. Frictie en progressie	Beperkt geld en verdenking zijn nuttige frictie. Je vooruitgang zit in kennis: je leert de gewoontes van je huisgenoten.
7. Communicatie	De briefjes zijn de feedback. Hun toon laat de verdenking zien, zonder meters of tekstuitleg.
8. Leercurve	Nacht 1 is alleen Sanne thuis (zij telt). Nacht 2 komt Mo erbij (hij checkt kwaliteit), nacht 4 Lisa (geheime favoriet). Dat is introduce → practise → combine.
9. Balans	Hypothese: “We expect players to steal mostly from the housemate who only counts, because replacements fool her.” Risico: dat wordt een dominante strategie. Het tegenwicht is dat vervangers geld kosten en het budget klein is.





## Assignment 1

1. Intended player experience / design claim
The player should feel the tension between greed and the fear of getting caught because the game asks them to cook the best possible meal each night from their housemates’ food, while each housemate possibly notices the missing food.

2. Core loop in a few sentences or simple diagram
At night, the player chooses a recipe. Then they have to take the ingredients from the housemates’ shelves, eventually put back a cheap replacement (only adding when there’s time) and cook it. The next morning, you can read the notes from your housemates that are on the fridge. If you get suspected by your housemates or the same person notices a pattern, you have to adjust your strategy for the next night. The loop repeats for 7 nights. The goal is to get the highest meal score without being confronted by housemates.

3. Core mechanics and what each contributes
- Suspicion through notes: every noticed theft raises the housemate’s suspicion, shown only by their morning note (friendly –> annoyed --> suspicion --> confrontation = game over). Leaving a housemate’s food alone lowers their suspicion. 
- Hidden housemate detection rules: each housemate notices theft in their own way. So for example, one person counts items, one only checks expensive items and one only cares about their favorite item. The rules are not explained in the game itself, you only notice it through the notes they hang up on the fridge. 
- Recipe selection (simple / medium / hard): Harder recipes score more points but need more ingredients, so the player must steal more for more points. 
- Limited replacements: with 10 euro for the whole week, the player can buy items from the supermarket and put them back. This can fool some housemates, but not everyone every time. (only adding when there’s time.

4. One important constraint (chosen or imposed)
The game is built in Visual Studio (C# and WinForms) without a game engine. There’s only a usage of images, mouse clicks and simple movement.This game will be a game without much character movement, so that means tension has to come from decisions and limited information.







## Assignment 2

1. Current design claim — one sentence describing the intended player behaviour/experience.
The player should feel the tension between greed and the fear of getting caught because the game asks them to cook the best possible meal each night from their housemates’ food without getting caught.

2. Playable core — provide the current playable/testable prototype. Visual polish and technical completeness are not required.

3. One important design decision — what you chose (A), one plausible alternative (B), why you chose the current solution (C), and the trade-off accepted (D).
What you chose (A): I chose a single-screen game. 
One plausible alternative (B): a game in which the player sneaks through the house at night to the fridge without waking the housemates up.
Why I chose the current solution (C): I’m not using a game engine because that’s what I hate with every piece of my life. I will not touch it with a 20 meter pole, so keep it far away from me. 
The trade-off accepted (D): The player has no immediate tension of almost getting caught. They learn the consequences the next morning (the notes on the fridge). My game relies on morning notes that create fear (hopefully). 

4. One communication/learning decision — something the player must understand and how the prototype communicates or teaches it.
Housemates are introduced one at a time. The player must understand that the housemates notice theft in a different way. One person counts items, the other one only cares about the favourite item. The prototype communicates it through notes in the morning. Suspicion is shown by the tone on the notes, for example friendly or confrontation. 

5. One balance hypothesis — for example: 'We expect players to choose/do X when Y because Z.'
We expect players to steal most of their ingredients from the person who only counts items, because replacements make the theft invisible. Because replacements are cheap and the budget for the week is low, we expect the player to steal the food from this specific person for half of the time. 

6. Current design risk — identify the assumption about player behaviour you are least certain about.
The players will read the notes probably as clues rather than as a random punishment. If players notice the theft notes as luck, they won’t form hypotheses and the game becomes guessing which shelf is safe. This risk is the highest for the person who only checks for the favorite item, because the nerve is unavoidable and may feel unfair. 
