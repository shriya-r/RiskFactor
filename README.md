# Risk Factor

## Inspiration

We were inspired to create **Risk Factor** after seeing how dangerous medical symptoms can sometimes be overlooked or dismissed. One personal inspiration came from a family experience involving heart disease, where concerning symptoms were initially underestimated before becoming much more serious. That experience showed us how difficult and important medical decisions can be.

We also wanted to raise awareness about postpartum complications and the challenges pregnant women face when warning signs are mistaken for normal pregnancy or recovery symptoms. Many dangerous symptoms can appear subtle at first, which makes early recognition extremely important.

Our goal was to create a game that is both educational and engaging — helping players learn warning signs through gameplay instead of simply reading informational material.



# What It Does

Risk Factor is a postpartum triage simulation game where players decide whether patients should be:

* Sent to the Hospital
* Safely sent Home

Each patient arrives with randomized:

* Symptoms
* Dialogue
* Risk factors
* Unrelated distractions

Players must determine which patients may be experiencing dangerous postpartum complications.

The game gradually increases in difficulty over multiple in-game days. New symptom categories and risk factors are introduced over time so players can learn warning signs progressively instead of being overwhelmed all at once.

The game teaches players to identify:

* **High Priority Symptoms**
* **Medium Priority Symptoms**
* **Medical Risk Factors**
* **Unrelated Symptoms** meant to distract the player



# Gameplay

## Daily Structure

Each day:

* 10 patients arrive
* Players review their symptoms and dialogue
* Players choose:

  * Send to Hospital
  * Send Home

At the beginning of each day, newly introduced symptoms and categories are explained to the player.



# Win & Loss Conditions

## Points

* Correct decision: **+1 point**
* Sending a healthy patient to the hospital: **-2 points**
* Sending a critical patient home: **Immediate Loss**

## Winning

* Reach 7 points or higher by the end of the day

## Losing

Players lose if:

* They send home a patient in critical condition
* Their score falls below the passing threshold

If too many unnecessary hospital visits occur, the game displays: “Hospital Overcrowded”



# Difficulty Progression

## Day 1

Introduces:

* Concept of High Priority symptoms
* 2 High Priority symptoms

## Day 2

Introduces:

* Medium Priority symptoms
* 2 more High Priority symptoms
* 3 Medium Priority symptoms

## Day 3

Introduces:

* Risk Factors
* Remaining High Priority symptoms
* 3 more Medium Priority symptoms
* 2 Risk Factors

## Day 4

Introduces:

* 3 more Medium Priority symptoms
* 3 more Risk Factors

## Day 5

Introduces:

* Remaining symptoms and factors
* Full difficulty gameplay
* Timer to ensure decisions are made quickly



# Symptoms & Categories

## High Priority Symptoms

These symptoms generally require immediate medical attention.

Examples:

* Trouble breathing
* Chest pain
* Heart rate above 100 BPM
* Extreme swelling
* Dizziness or fainting
* High blood pressure

### Example Dialogue

* “This morning, I got out of bed, and I felt like I could barely breathe!”
* “My chest feels really tight right now.”
* “I measured my heart rate, and it was 140 bpm.”
* “I fainted earlier today.”



## Medium Priority Symptoms

These symptoms may indicate developing complications and should be monitored carefully.

Examples:

* Extreme tiredness
* Persistent coughing
* Rapid weight gain
* Headaches
* Nausea
* Blurred vision
* Trouble sleeping
* Weakness
* Neck, or back pain
* Cold sweats

### Example Dialogue

* “I feel super tired, I can barely keep my eyes open.”
* “Koff-koff! I’ve been coughing for the past few weeks!”
* “My vision sometimes gets really blurry for a few seconds.”



## Risk Factors

These factors increase the likelihood of postpartum complications.

Examples:

* Family history of heart disease or hypertension
* Over 40 years old
* Limited access to prenatal care
* Smoking, alcohol, or drug use
* Premature birth
* Multiple births
* Limited access to healthy food

### Example Dialogue

* “I have a family history of hypertension.”
* “I smoke every so often.”
* “I haven’t attended a prenatal appointment yet.”



## Non-Risk Factors

These are healthy or neutral indicators meant to balance gameplay.

Examples:

* Regular exercise
* Healthy eating
* No smoking or drug use
* Attending prenatal appointments
* Young age

### Example Dialogue

* “I usually hit the gym every day.”
* “I regularly attend my prenatal appointments.”
* “I don’t smoke or drink.”



## Unrelated Symptoms

These symptoms are included to distract players and simulate realistic patient conversations.

Examples:

* Sneezing
* Acne
* Rash
* Tooth pain
* Mild bruises
* Mood swings
* Constipation

### Example Dialogue

* “My allergies are acting up.”
* “I have a tooth ache.”
* “I got a paper cut.”



# Core Rules

Patients should be sent to the hospital if they have:

## 1. A High Priority Symptom

Example:

* Chest pain
* Trouble breathing

## 2. One Risk Factor + One Medium Priority Symptom

Example:

* Family history of hypertension
* Persistent headaches

## 3. Three Medium Priority Symptoms

Example:

* Trouble sleeping
* Nausea
* Weakness



# Procedural Patient Generation

The game uses weighted random generation to create realistic patients.

## Healthy Patients

Randomly Chosen Symptoms:

* Non-Risk Factors
* Unrelated Symptoms



## Unhealthy Patients

The game randomly selects one of three dangerous patient types:

### Type 1 — High Priority

Includes:

* 1 guaranteed High Priority symptom

Additional symptoms may include:

* More High Priority symptoms
* Medium symptoms
* Risk factors
* Unrelated symptoms



### Type 2 — Risk Factor + Medium Symptom

Includes:

* 1 Risk Factor
* 1 Medium Priority symptom

Additional symptoms may include:

* More Medium symptoms
* More Risk factors
* Unrelated symptoms



### Type 3 — Three Medium Symptoms

Includes:

* 3 guaranteed Medium Priority symptoms

Additional symptoms:

* Mostly unrelated or non-risk symptoms



# Technical Details

## Built With

* **ASP.NET API**
* **C#**
* **HTML**
* **CSS**
* **JavaScript**
* **Figma**



# How We Built It

We organized symptoms into several categories:

* High Priority
* Medium Priority
* Risk Factors
* Non-Risk Factors
* Unrelated Symptoms

Patients are procedurally generated using weighted probabilities. Healthy patients mostly receive harmless symptoms, while dangerous patients receive combinations that require careful decision-making.

We also:

* Added multiple dialogue variations for realism
* Created a progressive learning system
* Connected a C# backend API to the frontend
* Built randomized gameplay systems



# Challenges

Some major challenges included:

* Researching medically accurate postpartum symptoms
* Properly balancing educational gameplay
* Categorizing symptoms appropriately
* Integrating frontend systems with backend APIs
* Connecting randomized patient generation with UI logic

We used resources from the California Department of Public Health’s Maternal, Child, and Adolescent Health resources to improve accuracy.



# Accomplishments

We are proud of:

* Combining education with gameplay
* Building a procedural dialogue system
* Designing progressive difficulty
* Creating replayable randomized scenarios
* Raising awareness about postpartum complications



# What We Learned

During development, we learned:

* How to integrate ASP.NET APIs with frontend systems
* How to use C# for procedural gameplay generation
* How to structure scalable randomized systems
* How to balance educational content with fun gameplay



# Future Plans

We plan to add:

* More symptom dialogue variations
* Dynamic patient reactions
* Difficulty modes
* Audio and voice acting
* Additional postpartum complications
* Feature to customize amount of new features to learn per level
* More advanced AI-driven patient behavior

We also want to continue improving the educational side of the game while keeping it engaging and approachable.
