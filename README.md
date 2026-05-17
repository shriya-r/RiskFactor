## Inspiration
We were inspired to create Risk Factor after seeing how dangerous medical symptoms can sometimes be overlooked or dismissed. One personal inspiration came from my grandmother, who had heart disease and went to the hospital after experiencing concerning symptoms. She was told it was okay for her to go home, and it turned out that her condition was serious. That experience showed us how difficult and important medical decisions can be.
We also wanted to raise awareness about postpartum complications and the challenges pregnant women face when warning signs are mistaken for normal pregnancy or recovery symptoms. Many dangerous symptoms can appear subtle at first, which makes early recognition extremely important.

## What It Does
Risk Factor is a postpartum triage simulation game where players decide whether patients should be sent to the hospital or safely sent home. We created this project so that women who should be aware of the risks would have a fun game to play that simultaneously taught them the symptoms and factors they should be aware of. This game provides a stress-free method of learning the concerns while also being a fun game to play, which may help raise awareness more than just reading a brochure.
Each patient arrives with randomized symptoms, dialogue, and risk factors. The game becomes harder over multiple days as more symptoms and risk factors are introduced. We increase the number of symptoms and factors that they need to consider each level (or day) so that users can slowly learn the symptoms by memorizing them in smaller segments.
Players must identify dangerous cases using clues such as:
* High priority symptoms
* Medium priority symptoms
* Medical risk factors
* Unrelated symptoms meant to distract the player

## How We Built It
We organized symptoms into categories (High Priority, Medium Priority, Risk Factors, Non-Risk Factors, Unrelated Symptoms). Patients are procedurally generated using weighted probabilities. Healthy patients mostly receive harmless symptoms, while dangerous patients receive combinations of symptoms and risk factors. We also ensured that the healthy and unhealthy patients would be generated randomly so that the user would have to learn the symptoms to win the game. We also created multiple dialogue variations for symptoms to make conversations feel more realistic and less repetitive. We ensured that players would only win and move onto the next level if they correctly sorted the patients between who needed the hospital and who could go home. If the user sent a patient home when they needed medical attention, they immediately lose the game. If the user sent a healthy patient to the hospital, then there is a little bit of room for error but they lose points because we wanted to also mention the issue of hospital overcrowding. By correctly sorting the patients that come in for the day, the user can move onto the next level and sort patients with a wider range of symptoms.

The game includes:
* Progressive difficulty by level
* A point-based triage system
* Win/loss conditions based on hospital overcrowding and saved patients
* ASP.NET API to connect the backend to the frontend
* HTML/CSS/JS to create a dynamic application
* Figma to create an interactive and engaging UI
* C# to program the backend with randomized patient generation

## Challenges
One challenge was ensuring that all of our medical information and warning signs were accurate. We researched postpartum symptoms and risk factors using data from the California Department of Public Health’s Maternal, Child, and Adolescent Health resources.
Another challenge was deciding how to classify symptoms and risk factors into categories like high priority, medium priority, and unrelated symptoms while still keeping the game balanced and educational.
We also had difficulty integrating the front-end HTML and Figma-based interface with the JavaScript gameplay systems that were developed separately. Connecting the UI with the randomized patient generation and scoring logic required a lot of debugging and restructuring.

## Accomplishments
We are proud of creating a system that combines education and gameplay in a meaningful way. The randomized symptom generator makes every playthrough different, and the dialogue system helps patients feel more realistic.
We are also proud of designing a progression system that gradually teaches players how to recognize increasingly complex symptom combinations.

## What We Learned
We learned how to integrate a C# backend with out HTML/CSS/JS frontend and learned how to use ASP.NET to create an API for our backend that could be called by our frontend. We also learned a lot about balancing educational gameplay. Introducing symptoms gradually across multiple in-game days made the game easier to learn without overwhelming players.

## What's Next For Risk Factor
In the future, we want to add:
* More symptom dialogue variations
* Dynamic patient reactions
* Difficulty modes
* Audio and voice acting
* Additional postpartum complications
* More advanced AI-driven patient behavior
We also want to expand the educational aspect of the game while keeping it engaging and enjoyable.
