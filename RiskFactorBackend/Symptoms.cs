namespace RiskFactorBackend;

public enum SymptomPriority { HighPriority, MediumPriority, NonPriority, RiskFactor, NonFactor }

public record Symptom(
    string Name, // unique
    string Description = "",
    string[] DialogueOptions = null!
);

public record SymptomSelect(
    string Name,
    string Dialogue = ""
);

public class SymptomBank
{
    private readonly Random _random = new();
    private readonly Dictionary<SymptomPriority, List<Symptom>> _symptoms = new()
        {
            // Ordered by day unlocked: indices 0-1 = day 1, 2-3 = day 2, 4-5 = day 3
            [SymptomPriority.HighPriority] = new()
            {
                new Symptom("Trouble breathing",
                    "Trouble with breathing is a high priority symptom, especially with minimal or light activity. In women, shortness of breath without chest pain is more common than in men and is frequently overlooked as a cardiac warning sign.",
                    new [] {
                        "This morning, I got out of bed, and I felt like I could barely breathe!",
                        "Yesterday, I struggled with breathing after just a short walk.",
                    }),
                new Symptom("Chest pain",
                    "Women are less likely to experience sharp chest pain - instead it may feel like pressure, squeezing, or tightness. Any chest discomfort during or after pregnancy should be taken seriously and evaluated immediately.",
                    new [] {
                        "My chest hurts a lot.",
                        "My chest feels really tight right now.",
                    }),
                new Symptom("Heart rate over 100bpm",
                    "A resting heart rate consistently above 100bpm is called tachycardia and can indicate the heart is under stress. During the postpartum period, this can be an early sign of peripartum cardiomyopathy, a serious but treatable condition.",
                    new [] {
                        "I measured my heart rate, and it was 120bpm.",
                        "I measured my heart rate, and it was 140bpm.",
                    }),
                new Symptom("Extreme swelling",
                    "Sudden or severe swelling in the feet, ankles, or legs can signal that the heart is not pumping efficiently, causing fluid to build up. This is especially concerning postpartum as it can indicate heart failure or severe preeclampsia.",
                    new [] {
                        "My feet are swelling up a lot…",
                        "My ankles are swelling up a lot…",
                    }),
                new Symptom("Dizziness or fainting",
                    "Dizziness or fainting can indicate that the brain isn't receiving enough blood flow, which may point to a cardiac issue. Women often attribute this to exhaustion or dehydration postpartum, which can delay critical diagnosis.",
                    new [] {
                        "I feel really dizzy right now.",
                        "I fainted earlier today.",
                    }),
                new Symptom("Higher than 130/80 mmHg BP",
                    "Blood pressure above 130/80 mmHg is classified as Stage 1 hypertension and puts extra strain on the heart and blood vessels. Postpartum hypertension is common and can persist or even appear for the first time after delivery.",
                    new [] {
                        "I measured my blood pressure, and it was 135/83 mmHg.",
                    }),
            },
            // Ordered by day unlocked: indices 0-2 = day 2, 3-5 = day 3, 6-8 = day 4, 9-10 = day 5
            [SymptomPriority.MediumPriority] = new()
            {
                new Symptom("Overwhelming tiredness",
                    "While fatigue is common postpartum, cardiac-related tiredness feels different - sudden, extreme, and described as 'hitting a wall' even without physical exertion. Women are more likely than men to experience fatigue as a primary cardiac symptom.",
                    new [] {
                        "I feel super tired, I can barely keep my eyes open.",
                    }),
                new Symptom("A cough that doesn't go away",
                    "A persistent cough can be a sign of fluid accumulating in the lungs due to a weakened heart, a condition called pulmonary edema. It is often mistaken for a common cold or allergies, delaying cardiac evaluation.",
                    new [] {
                        "Koff-koff! I've been coughing for the past few weeks!",
                    }),
                new Symptom("Unusual weight gain",
                    "Rapid unexplained weight gain - such as several pounds in a few days - can signal fluid retention caused by a struggling heart. This is distinct from normal postpartum weight fluctuation and should be monitored closely.",
                    new [] {
                        "I gained 6lbs in a week.",
                    }),
                new Symptom("240+ mg/dL cholesterol",
                    "Total cholesterol above 240 mg/dL significantly increases the risk of plaque buildup in arteries, which can restrict blood flow to the heart. Cholesterol levels can shift during and after pregnancy, making postpartum screening important.",
                    new [] {
                        "I measured my cholesterol, and it was 240 mg.",
                    }),
                new Symptom("Headaches",
                    "Persistent or severe headaches postpartum can be associated with high blood pressure, a key cardiac risk factor. They may also signal preeclampsia, which can develop up to 6 weeks after delivery.",
                    new [] {
                        "My head aches a lot.",
                    }),
                new Symptom("Nausea / Loss of appetite",
                    "Nausea is a frequently overlooked cardiac symptom in women, often mistaken for digestive issues or postpartum hormonal changes. When paired with other symptoms it can indicate a cardiac event.",
                    new [] {
                        "I feel like I could throw up.",
                        "I can barely eat, nothing seems appetizing.",
                    }),
                new Symptom("Blurred vision",
                    "Intermittent blurred vision can be a sign of elevated blood pressure affecting blood flow to the eyes and brain. In postpartum women, this warrants prompt evaluation as it may accompany dangerously high BP.",
                    new [] {
                        "My vision sometimes gets really blurry for a few seconds.",
                    }),
                new Symptom("Feeling weak",
                    "General weakness or a sudden loss of strength can indicate that the heart is not circulating blood effectively to muscles and organs. Women often dismiss this as normal postpartum recovery, which can delay diagnosis.",
                    new [] {
                        "I've been feeling weak lately.",
                    }),
                new Symptom("Trouble sleeping",
                    "Waking up suddenly short of breath - known as orthopnea - is a specific cardiac warning sign often disguised as general insomnia. If sleep disruption is accompanied by breathlessness or discomfort lying flat, it should be flagged urgently.",
                    new [] {
                        "I keep waking up in the middle of the night.",
                        "I toss and turn, all night.",
                    }),
                new Symptom("Jaw/Neck/Back pain",
                    "Unexplained jaw, neck, or upper back pain is especially prominent in women as an atypical cardiac symptom, frequently mistaken for muscle tension or stress. Women are significantly more likely than men to experience these non-chest symptoms during a cardiac event.",
                    new [] {
                        "Ouch! My back hurts.",
                        "Ouch! My jaw hurts.",
                        "Ouch! My neck hurts.",
                    }),
                new Symptom("Cold sweats",
                    "Cold sweats without an obvious cause like fever or heat can indicate the body is under cardiovascular stress. Women are more likely than men to experience cold sweats as a standalone cardiac symptom.",
                    new [] {
                        "I've been having cold sweats.",
                    }),
            },
            [SymptomPriority.NonPriority] = new()
            {
                new Symptom("Sneezing", "",
                    new [] { "My allergies are acting up." }),
                new Symptom("Normal heart rate (below 100bpm)", "",
                    new [] { "I measured my heart rate, and it was 70 bpm.", "I measured my heart rate, and it was 80 bpm." }),
                new Symptom("Sore throat", "",
                    new [] { "My throat feels scratchy." }),
                new Symptom("Acne", "",
                    new [] { "My face is breaking out." }),
                new Symptom("Rash", "",
                    new [] { "My arm is looking a bit red from a rash." }),
                new Symptom("Tooth Pain", "",
                    new [] { "I have a tooth ache." }),
                new Symptom("Mild Cuts & Bruises", "",
                    new [] { "I got a paper cut.", "I hit my knee on the table and it's bruised a bit.", "I stubbed my toe and it hurts." }),
                new Symptom("Perinereal pain", "",
                    new [] { "My perineum hurts." }),
                new Symptom("Mood swings", "",
                    new [] { "I've been having stressful mood swings." }),
                new Symptom("Constipation", "",
                    new [] { "I've been pretty constipated." }),
            },
            // Ordered by day unlocked: indices 0-1 = day 3, 2-4 = day 4, 5-8 = day 5
            [SymptomPriority.RiskFactor] = new()
            {
                new Symptom("Family history of related diseases",
                    "A family history of heart disease, hypertension, diabetes, or preeclampsia significantly raises personal risk, as many cardiovascular conditions have a strong genetic component. Having a first-degree relative (parent or sibling) with these conditions is particularly significant.",
                    new [] {
                        "I have a family history of hypertension.",
                        "I have a family history of coronary artery disease.",
                        "I have a family history of diabetes.",
                        "I have a family history of preeclampsia.",
                        "I have a family history of chemotherapy.",
                        "I have a family history of kidney disease.",
                        "I have a family history of autoimmune diseases.",
                    }),
                new Symptom("Over 40 years of age",
                    "Pregnancy after 40 carries a higher baseline cardiovascular risk, as the heart and blood vessels are naturally less resilient with age. Women over 40 are more likely to have pre-existing conditions like hypertension or high cholesterol that complicate pregnancy.",
                    new [] {
                        "I'm 42.",
                    }),
                new Symptom("Black, American Indian, Alaska Native",
                    "Black, American Indian, and Alaska Native women experience pregnancy-related heart complications and mortality at 2–3 times the rate of white women. This disparity is largely driven by systemic barriers in healthcare access and quality of care.",
                    new [] {
                        "I'm Black.",
                    }),
                new Symptom("Pregnancy with more than one baby",
                    "Carrying multiples puts significantly more strain on the heart, as it must pump more blood to support multiple babies. This increases the risk of developing peripartum cardiomyopathy and gestational hypertension.",
                    new [] {
                        "I just gave birth to two beautiful twins.",
                    }),
                new Symptom("Have had a premature birth",
                    "Preterm birth is associated with higher long-term cardiovascular risk for the mother and may indicate underlying vascular issues like preeclampsia. Women who have had a premature birth are more likely to develop heart disease later in life.",
                    new [] {
                        "My baby was born 5 weeks early.",
                    }),
                new Symptom("Have limited access to healthy meals",
                    "Poor nutrition - particularly diets high in sodium, saturated fat, and processed foods - contributes to high blood pressure, high cholesterol, and obesity, all of which strain the heart. Nutritional access is a social determinant of health that disproportionately affects lower-income communities.",
                    new [] {
                        "I eat fried food basically every day.",
                        "I don't eat much these days.",
                    }),
                new Symptom("Lack of exercise",
                    "Regular physical activity strengthens the heart muscle and helps regulate blood pressure, cholesterol, and weight. A sedentary lifestyle increases cardiovascular risk, especially when combined with other factors like obesity or poor diet.",
                    new [] {
                        "I haven't exercised in months.",
                    }),
                new Symptom("Live in an area with limited access to prenatal care",
                    "Limited access to prenatal care means conditions like hypertension or gestational diabetes may go undetected and untreated. Early and consistent prenatal monitoring is one of the most effective tools for catching cardiac risk during pregnancy.",
                    new [] {
                        "I haven't attended a prenatal appointment yet.",
                    }),
                new Symptom("Tobacco, marijuana, alcohol, or illicit drugs",
                    "Smoking and substance use damage blood vessels, raise heart rate and blood pressure, and significantly increase the risk of heart disease. These substances are particularly harmful during and after pregnancy, affecting both maternal and infant cardiovascular health.",
                    new [] {
                        "I smoke every so often.",
                        "I use marijuana to relax.",
                        "I like to drink with my friends.",
                        "I shot up recently.",
                    }),
            },
            [SymptomPriority.NonFactor] = new()
            {
                new Symptom("Gave birth to one baby", "",
                    new [] { "Last week, I gave birth to a beautiful baby boy.", "Last week, I gave birth to a beautiful baby girl." }),
                new Symptom("Exercise regularly", "",
                    new [] { "I usually hit the gym every day.", "I go on a run every morning." }),
                new Symptom("No family history of heart disease", "",
                    new [] { "I don't think I have a history of heart disease.", "My family has a hereditary acne issue." }),
                new Symptom("Eats balanced, nutritious meals regularly", "",
                    new [] { "I usually eat healthy food.", "I take my needed vitamins." }),
                new Symptom("No Smoking/No drugs", "",
                    new [] { "I don't smoke or drink.", "I don't vape or smoke.", "I don't do drugs." }),
                new Symptom("Attends prenatal appointments", "",
                    new [] { "I regularly attend my prenatal appointments." }),
                new Symptom("Miscellaneous", "",
                    new [] { "I put on makeup everyday.", "I go to USC.", "I go to UCI." }),
                new Symptom("Normal birth timeline", "",
                    new [] { "My baby was born on its expected date." }),
            },
        };

    public int Count(SymptomPriority priority) => _symptoms[priority].Count;

    public List<Symptom> GetSymptoms(SymptomPriority priority) => _symptoms[priority];

    public List<Symptom> GetRange(SymptomPriority priority, int from, int to) =>
        _symptoms[priority].GetRange(from, to - from);

    private Symptom PickSymptom(SymptomPriority priority, int upTo) {
        return _symptoms[priority][_random.Next(Math.Min(upTo, _symptoms[priority].Count))];
    }

    private SymptomPriority PickPriority(SymptomPriority[] allowed) =>
        allowed[_random.Next(allowed.Length)];

    public List<Symptom> GetRandom(
            int count,
            HashSet<Symptom> picked,
            Dictionary<SymptomPriority, int> availability,
            SymptomPriority[] allowed
        )
    {
        var available = allowed.Where(p => availability[p] > 0).ToArray();
        while (picked.Count < count)
        {
            var priority = PickPriority(available);
            var symptom = PickSymptom(priority, availability[priority]);
            picked.Add(symptom);
        }

        return picked.ToList();
    }

    public List<Symptom> PickSymptoms(Scenario sc, Dictionary<SymptomPriority, int> availability) {
        HashSet<Symptom> picked = new();
        switch (sc)
        {
            case Scenario.HighPriority:
                picked.Add(PickSymptom(
                    SymptomPriority.HighPriority,
                    availability[SymptomPriority.HighPriority]
                ));
                GetRandom(4, picked, availability, new [] {
                    SymptomPriority.HighPriority,
                    SymptomPriority.MediumPriority, SymptomPriority.NonFactor,
                    SymptomPriority.RiskFactor, SymptomPriority.NonPriority});
                break;
            case Scenario.RiskFactorMedium:
                picked.Add(PickSymptom(
                    SymptomPriority.RiskFactor,
                    availability[SymptomPriority.RiskFactor]
                ));
                picked.Add(PickSymptom(
                    SymptomPriority.MediumPriority,
                    availability[SymptomPriority.MediumPriority]
                ));
                GetRandom(4, picked, availability, new [] {
                    SymptomPriority.MediumPriority, SymptomPriority.NonFactor,
                    SymptomPriority.RiskFactor, SymptomPriority.NonPriority});
                break;
            case Scenario.ThreeMedium:
                GetRandom(3, picked, availability, new [] { SymptomPriority.MediumPriority });
                GetRandom(4, picked, availability, new [] { SymptomPriority.NonFactor, SymptomPriority.NonPriority });
                break;
            case Scenario.Healthy:
                GetRandom(4, picked, availability, new [] { SymptomPriority.NonFactor, SymptomPriority.NonPriority });
                break;
            case Scenario.RiskFactorOnly:
                picked.Add(PickSymptom(
                    SymptomPriority.RiskFactor,
                    availability[SymptomPriority.RiskFactor]
                ));
                GetRandom(4, picked, availability, new [] { SymptomPriority.NonFactor, SymptomPriority.NonPriority });
                break;
            case Scenario.FewMedium:
                GetRandom(_random.Next(1, 3), picked, availability, new [] { SymptomPriority.MediumPriority });
                GetRandom(4, picked, availability, new [] { SymptomPriority.NonFactor, SymptomPriority.NonPriority });
                break;
        }
        return picked.OrderBy(_ => _random.Next()).ToList();
    }
}
