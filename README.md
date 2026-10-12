# game-design-portfolio

Brainstorming ideas for the game:
 
Idea 1 for the game: A cooking game where strange things happen at the kitchen at work
Description: you work as a allround kitchen staff member in the kitchen (ChipCafe) from ChipSoft. You have to complete some tasks for that day. What you don't know is why some weird things are happening around the workplace. Do you want to figure out why or just shake it off?
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
Description: You live in a dorm with a few housemates. One evening, you come home and you see that you don't have sufficient
Genres:
1. The player should experience fear because the game asks them to not get caught while stealing food in the kitchen.
2. The player should commit theft because the game asks them to steal food from housemates.
3. The player should experience distrust because the game asks them to protect food while trying to discover who is the thief.


-----

Concept: Shared fridge:You’re a broke student who has to survive 7 nights until payday by cooking meals from your housemates’ food in the shared fridge, without getting caught.

1. Design claim
The player should feel the tension between greed and the fear of getting caught because the game asks them to cook the best possible meal each night from their housemates’ food, while each housemate notices missing food in a different way that the player has to figure out.

2. Core loop
Night: choose a recipe → take ingredients from the shelves → optionally put back a cheap replacement → cook → Morning: read the notes housemates leave on the fridge → adjust your strategy → next night.
Long loop: survive 7 nights; your score is the total value of the meals you cooked.

3. Core mechanics

Recipe choice: each night the player picks one of three recipes (simple / medium / fancy); fancier meals score more but need more ingredients → greed vs. safety.
Housemate habits: each housemate notices theft differently – one counts items, one only checks expensive items, one only cares about one secret favourite. The habits are never explained; the player learns them from the morning notes → uncertainty and deduction.
Suspicion: a noticed theft makes that housemate more suspicious, shown through the tone of their note (friendly → annoyed → furious). A third strike means they confront you and the game is over. Leaving a housemate alone for a night lowers their suspicion → the player has to spread risk.
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
9. Balans	Hypothese: “We expect players to steal mostly from the housemate who only counts, because replacements fool her.” Risico: dat wordt een dominante strategie. De tegenwicht is dat vervangers geld kosten en het budget klein is.

---

Snapshot (2026-10-12): concise standalone summary

1. Intended player experience / design claim
The game should make the player feel a tension between greed and fear. Players are rewarded for cooking meals but risk confrontation from housemates if theft is detected. Each housemate detects missing food in different ways, and the player must infer 
detection rules from short morning notes.

2. Core loop
Each night the player selects a recipe, takes the required ingredients from the shared fridge and may optionally leave a cheap replacement, then cooks the meal. Each morning the player reads notes from housemates that reveal suspicion levels and 
hint at patterns. The player uses that information to update strategy for the next night. The short loop repeats for seven nights and the goal is to maximize total meal value while avoiding a confrontation that ends the run.

3. Core mechanics and what each contributes
- Recipe selection (simple / medium / hard): creates a risk–reward choice where harder recipes score higher but require more ingredients and therefore increase exposure.
- Hidden housemate detection rules: each housemate inspects the fridge differently and does not state their rule explicitly; this mechanic generates uncertainty and drives deduction and learning across nights.
- Suspicion via notes: housemates communicate changing suspicion through tone rather than meters; escalating tone provides feedback and a soft failure condition (confrontation after repeated notices), which forces the player to spread risk.
- Limited replacements (budgeted cheap substitutes): a small, shared resource that can temporarily fool some detectors and forces players to manage money and bluff selectively.

4. One important constraint
The game is single-screen and mouse-only with no character movement. All tension and gameplay therefore emerge from decision-making, limited information, and resource management.
